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

                // Add Windows
                serviceCollection.AddSingleton<AuthWindow>();
                serviceCollection.AddSingleton<MainWindow>();



                #endregion

                return serviceCollection.BuildServiceProvider();
            }
        }
    }
}
