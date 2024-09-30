using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngMasterWPF.Model.Context;
using EngMasterWPF.Repository;
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
using EngMasterWPF.Model.Entities;
using EngMasterWPF.Views.TeacherView;
using EngMasterWPF.Views.GradeView;
using EngMasterWPF.Views.CourseView;
using EngMasterWPF.Views.NotificationView;
using EngMasterWPF.Views.AccountView;

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
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                // Add Denpendency Injection

                IServiceCollection serviceCollection = new ServiceCollection();

                #region InstallerServices

                serviceCollection.AddDbContext<EngMasterDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
                serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
                serviceCollection.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
                serviceCollection.AddScoped<IAuthRepository, AuthRepository>();
                serviceCollection.AddScoped<IStudentRepository, StudentRepository>();
                serviceCollection.AddSingleton<MainWindow>();


                serviceCollection.AddSingleton<IPageService, PageService>();

                serviceCollection.AddSingleton<HomeViewModel>();
                serviceCollection.AddSingleton<MainWindowViewModel>();


                //HomeView
                serviceCollection.AddSingleton<HomeView>();

                //StudentView
                serviceCollection.AddSingleton<StudentView>();

                //TeacherView
                serviceCollection.AddSingleton<TeacherView>();

                //GradeView
                serviceCollection.AddSingleton<GradeView>();

                //CourseView
                serviceCollection.AddSingleton<CourseView>();

                //NotificationView
                serviceCollection.AddSingleton<NotificationView>();

                //AccountView
                serviceCollection.AddSingleton<AccountView>();





                //Add AutoMapper
                var configurationMapper = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new MapperProfile());

                });
                
                var mapper = configurationMapper.CreateMapper();
                serviceCollection.AddSingleton(mapper);

                #endregion

                return serviceCollection.BuildServiceProvider();
            }
        }
    }
}
