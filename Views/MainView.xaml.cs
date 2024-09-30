﻿using EngMasterWPF.Utilities;
using EngMasterWPF.ViewModel;
using EngMasterWPF.Views.HomeView;
using Microsoft.Extensions.DependencyInjection;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.Controls;

namespace EngMasterWPF.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();

            RootNavigationView.SetServiceProvider((IServiceProvider)Installer.InstallServices.Instance.serviceProvider);
            var pageService = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<IPageService>();
            RootNavigationView.SetPageProviderService((Wpf.Ui.Abstractions.INavigationViewPageProvider)pageService);

            // set default navigation page
            Loaded += (_, _) => RootNavigationView.Navigate(typeof(HomeView.HomeView));

        }
    }
}
