using EngMasterWPF.Views;
using Microsoft.Extensions.DependencyInjection;
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
            var services = Installer.InstallServices.Instance;
            AuthWindow authWindow = services.serviceProvider.GetRequiredService<AuthWindow>()!;
            authWindow.ShowDialog();
        }
    }

}
