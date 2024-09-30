using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf.Ui.Abstractions;

namespace EngMasterWPF.Utilities
{
    public class PageService : IPageService
    {
        private readonly IServiceProvider _serviceProvider = Installer.InstallServices.Instance.serviceProvider;

        public PageService()
        {
            
        }

         T? GetPage<T>() where T : class
        {
            if (!typeof(FrameworkElement).IsAssignableFrom(typeof(T)))
            {
                throw new InvalidOperationException("The page should be a WPF control.");
            }

            return (T?)_serviceProvider.GetService(typeof(T));
        }

        FrameworkElement? GetPage(Type pageType)
        {
            if (!typeof(FrameworkElement).IsAssignableFrom(pageType))
            {
                throw new InvalidOperationException("The page should be a WPF control.");
            }

            return _serviceProvider.GetService(pageType) as FrameworkElement;
        }

        object? INavigationViewPageProvider.GetPage(Type pageType)
        {
            throw new NotImplementedException();
        }
    }
}
