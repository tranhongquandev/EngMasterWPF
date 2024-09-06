using EngMasterWPF.Views;
using System.Configuration;
using System.Data;
using System.Windows;


namespace EngMasterWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var installServices = new Installer.InstallServices();
            AuthWindow authWindow = new AuthWindow();
            authWindow.ShowDialog();
        }
    }

}
