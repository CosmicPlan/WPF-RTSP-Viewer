using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_RTSP_Viewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {

        private RtspHelpers rtspHelpers = null;


        public MainWindow()
        {
            InitializeComponent();
          
            rtspHelpers = new RtspHelpers(RtspPath.Text);
            Initialize();

        }
        public async void Initialize()
        {
            await rtspHelpers.Preview(a =>
            {

                this.Dispatcher.Invoke(new Action(() =>
                {
                    FrameImage.Source = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(a);
                }));
            });
        }
        private void StartRecord_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("开始录制视频，路径保存在程序目录下");
            rtspHelpers.StartRecord(string.Format("{0}.mp4", DateTime.Now.ToString("yyyyMMddHHmm")));
        }

        private void StopRecord_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("已停止");

            rtspHelpers.StopRecord();
        }


    }
}