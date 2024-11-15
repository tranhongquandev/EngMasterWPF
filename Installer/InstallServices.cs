using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Configuration;
using System.IO;
using EngMasterWPF.Views;
using EngMasterWPF.ViewModel;
using AutoMapper;
using EngMasterWPF.Helper;
using EngMasterWPF.Utilities;
using EngMasterWPF.Views.HomeView;
using EngMasterWPF.Views.StudentView;

using EngMasterWPF.Views.TeacherView;
using EngMasterWPF.Views.GradeView;
using EngMasterWPF.Views.CourseView;
using EngMasterWPF.Views.NotificationView;
using EngMasterWPF.Views.AccountView;
using EngMasterWPF.Services;

namespace EngMasterWPF.Installer
{
    public  class InstallServices
    {
        private static InstallServices? _instance;

        public static InstallServices Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InstallServices();
                }
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        public IServiceProvider serviceProvider { get; set; } = ConfigureServices;

        private static IServiceProvider ConfigureServices
        {
            get
            {
                // Add appsettings.json
                //var configuration = new ConfigurationBuilder()
                //    .SetBasePath(AppContext.BaseDirectory)
                //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                //    .Build();

                // Add Denpendency Injection

                IServiceCollection serviceCollection = new ServiceCollection();

                #region InstallerServices

                
                serviceCollection.AddSingleton<MainWindow>();

                //Add Services
                serviceCollection.AddScoped<StudentService>();

                serviceCollection.AddScoped<TeacherService>();

                serviceCollection.AddScoped<CourseService>();

                serviceCollection.AddScoped<GradeService>();

                //Add AutoMapper
                var configurationMapper = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new MapperProfile());

                });

                var mapper = configurationMapper.CreateMapper();
                serviceCollection.AddSingleton(mapper);

                #endregion

                serviceCollection.AddSingleton<HomeViewModel>();
                serviceCollection.AddSingleton<StudentViewModel>();
                serviceCollection.AddSingleton<TeacherViewModel>();
                serviceCollection.AddSingleton<GradeViewModel>();
                serviceCollection.AddSingleton<CourseViewModel>();
                serviceCollection.AddSingleton<NotificationViewModel>();
                serviceCollection.AddSingleton<MainWindowViewModel>();

                serviceCollection.AddSingleton<MainViewModel>();
                serviceCollection.AddScoped<AuthViewModel>();






               

                return serviceCollection.BuildServiceProvider();
            }
        }
    }
}
