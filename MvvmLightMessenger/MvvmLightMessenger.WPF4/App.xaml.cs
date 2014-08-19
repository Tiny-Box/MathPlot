using System.Windows;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Messaging;

using MvvmLightMessenger.WPF4.View;
using MvvmLightMessenger.WPF4.ViewModel;

namespace MvvmLightMessenger.WPF4
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            DispatcherHelper.Initialize();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // 首先显示登录控件
            Login login = new Login();
            LoginViewModel loginViewModel = new LoginViewModel();
            login.DataContext = loginViewModel;

            // 将Login设置为主窗体
            this.MainWindow = login;
            MainWindow.Show();

            // 注册消息，接收bool类型的参数，true为登录成功
            Messenger.Default.Register<bool?>(
                this,
                m =>
                {
                    // 登录成功后，显示主页面
                    if (m.HasValue && m.Value)
                    {
                        // 更改主窗体
                        this.MainWindow = new MainWindow();

                        // 关闭登录窗体
                        login.Close();
                        // 清理释放Login资源
                        loginViewModel.Cleanup();
                        login = null;

                        MainWindow.Show();
                    }
                    else if (!m.HasValue)
                    {
                        MainWindow.Close();
                    }
                }
                );
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Messenger.Default.Unregister(this);
            base.OnExit(e);
        }
    }
}
