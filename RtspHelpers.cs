using OpenCvSharp;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_RTSP_Viewer
{
    public class RtspHelpers
    {

        private readonly VideoCapture _Capture;
        #region 预览
        private bool _previewRunState = false;
        #endregion
        #region 录制
        private VideoWriter? _videoWriter = null;
        private bool _isRunRecord = false;
        #endregion
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="rtsp">rtsp地址</param>
        public RtspHelpers(string rtsp)
        {
            _Capture = new VideoCapture(rtsp);
        }
        /// <summary>
        /// 预览视频流
        /// </summary>
        /// <param name="action">预览回调</param>
        public async Task Preview(Action<Mat>? action = null)
        {
            _previewRunState = true;
            await Task.Run(() =>
            {
                using (Mat image = new Mat())
                {
                    while (_previewRunState)
                    {
                        if (!_Capture.Read(image) || image.Empty())
                        {
                            _previewRunState = false;
                            break;
                        }

                        if (action != null)
                        {
                            action.Invoke(image);
                        }

                        if (_videoWriter != null && _isRunRecord)
                        {
                            _videoWriter.Write(image);
                        }

                        Cv2.WaitKey(30);

                    }
                }
            });
        }

        /// <summary>
        /// 停止预览
        /// </summary>
        public bool StopPreview()
        {
            if (!_previewRunState)
            {
                return false;
            }
            _previewRunState = false;

            return true;
        }
        /// <summary>
        /// 开始录制
        /// </summary>
        /// <param name="path"></param>
        public bool StartRecord(string path)
        {
            if (_Capture == null || _Capture.IsDisposed)
            {
                return false;
            }
            _videoWriter = new VideoWriter(path, FourCC.H264, _Capture.Fps, new OpenCvSharp.Size(_Capture.FrameWidth, _Capture.FrameHeight));
            _isRunRecord = true;
            return true;
        }
        /// <summary>
        /// 停止录制
        /// </summary>
        public void StopRecord()
        {
            _isRunRecord = false;
            if (_videoWriter != null && !_videoWriter.IsDisposed)
            {
                _videoWriter.Dispose();
                _videoWriter = null;
            }

        }
    }
}
