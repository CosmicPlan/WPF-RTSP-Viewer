   M S B A M L   `   `   `  ����J  FWPF-RTSP-Viewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WPF_RTSP_ViewerWPF_RTSP_Viewer  5           WPF_RTSP_Viewer.MainWindow   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:WPF_RTSP_Viewer     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  
MainWindow��5      $	��800��5	      $	��450��5
      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ 
FrameImage��5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� $��20(�6   .��6"   流地址：6(   �� 5      -   5         ��Name$ RtspPath��5      $��20(�5      $D��>rtsp://admin:D-hisim123@192.168.0.103:554/Streaming/Channels/1��5      5      �� 5   
   $��2��5      $��0,10,0,0q�5      $ 
Horizontal=�5      .+�5      �� -   5         ��Name$ StartRecord��5       $��50��5!      $��25(�5#      .��6   录制5%      �� 5&      -   5        $ 
StopRecord��5'      $��50��5(      $��25(�5*      .��6   停止录制5,      5-      5.      5/      