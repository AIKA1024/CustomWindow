using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CustomWindow
{
  /// <summary>
  /// SecondWindow.xaml 的交互逻辑
  /// </summary>
  public partial class SecondWindow : Window
  {
    public SecondWindow()
    {
      InitializeComponent();
      Chrome.NonClientFrameEdges = System.Windows.Shell.NonClientFrameEdges.Left | System.Windows.Shell.NonClientFrameEdges.Right | System.Windows.Shell.NonClientFrameEdges.Bottom;
      Loaded += MainWindow_Loaded;
    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
      // 获取当前窗口的句柄
      WindowInteropHelper helper = new WindowInteropHelper(this);
      IntPtr hWnd = helper.Handle;

      // 启用暗黑模式
      bool success = DarkModeHelper.EnableDarkModeForWindow(hWnd, true);
      if (success)
      {
        Console.WriteLine("暗黑模式启用成功！");

      }
      else
      {
        Console.WriteLine("暗黑模式启用失败。");
      }
    }

    protected override void OnStateChanged(EventArgs e)
    {
      base.OnStateChanged(e);

      if (WindowState == WindowState.Maximized)
      {
        Padding = new Thickness(8);
      }
      else
      {
        Padding = new Thickness(4, 0, 4, 4);
      }
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        new MainWindow().Show();
    }
  }
}
