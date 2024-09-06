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

namespace EngMasterWPF.Installer
{
    public class InstallServices
    {
        public IServiceProvider ConfigureServices()
        {
            // Add appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Add Denpendency Injection
            var services = new ServiceCollection();

            #region InstallerServices

            services.AddDbContext<EngMasterDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IAuthRepository, AuthRepository>();



            #endregion

            return services.BuildServiceProvider();
        }
    }
}
