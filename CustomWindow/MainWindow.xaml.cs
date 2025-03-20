using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomWindow
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
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

    private void Window_StateChanged(object sender, EventArgs e)
    {
      if (WindowState == WindowState.Maximized)
      {
        Padding = new Thickness(8);
        MaxBtn.Content = "\xE923";
      }
      else
      {
        Padding = new Thickness(4, 0, 4, 4);
        MaxBtn.Content = "\xE922";
      }
    }

    private void Window_Close(object sender, RoutedEventArgs e)
    {
      Close();
    }

    private void Window_Min(object sender, RoutedEventArgs e)
    {
      WindowState = WindowState.Minimized;
    }

    private void Window_Max(object sender, RoutedEventArgs e)
    {
      if (WindowState == WindowState.Maximized)
        WindowState = WindowState.Normal;
      else
        WindowState = WindowState.Maximized;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      if (ThemeMode != ThemeMode.Dark)
        ThemeMode = ThemeMode.Dark;
      else
        ThemeMode = ThemeMode.Light;
    }
  }
}