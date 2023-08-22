using System.Net.Http.Headers;

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Testing;
using Lotus.Account;
using Lotus.Core;

namespace Lotus.DeNova.Test
{
    /// <summary>
    /// Дефолтная фабрика для создания Fixture для интеграционных тестов
    /// </summary>
    public class DeNovaDefaultFactory : WebApplicationFactory<Program>
    {
		/// <summary>
		/// Администратор системы
		/// </summary>
		public static readonly CUser AdminUser = new CUser
		{
			Id = Guid.Parse("e3182c8f-87bc-4e27-a27f-b32e3e2b8018"),
			Login = "DanielDem",
			PasswordHash = XHashHelper.GetHash("!198418dsfA!"),
			Email = "dementevds@gmail.com",
			Name = "Даниил",
			Surname = "Дементьев",
			Patronymic = "Сергеевич",
			RoleId = XRoleConstants.Admin.Id
		};

		/// <summary>
		/// Администратор системы
		/// </summary>
		public static readonly CUser DefaultUser = new CUser
		{
			Id = Guid.Parse("42863dae-924f-4385-9967-fb800f44a984"),
			Login = "DanielDem",
			PasswordHash = XHashHelper.GetHash("123456"),
			Email = "dementevds@gmail.com",
			Name = "Даниил",
			Surname = "Дементьев",
			Patronymic = "Сергеевич",
			RoleId = XRoleConstants.User.Id
		};

		private IServiceScope _scope;
        private bool _disposed;

        /// <summary>
        /// Поставщик сервисов
        /// </summary>
        public IServiceProvider ServiceProvider => Scope.ServiceProvider;

		/// <summary>
		/// База данных
		/// </summary>
		public DeNovaDbContext Context { get; private set; }

		/// <summary>
		/// Фабрика логгера
		/// </summary>
		public ILoggerFactory LoggerCreator { get; private set; }

		/// <summary>
		/// Поставщик сервисов
		/// </summary>
		private IServiceScope Scope => _scope ??= Services.CreateScope();

		/// <summary>
		/// Конструктор по умолчанию
		/// </summary>
		public DeNovaDefaultFactory()
        {
            Initialize();
        }

        /// <summary>
        /// Конфигурация билдера хоста приложения
        /// </summary>
        /// <returns>Хост билдера</returns>
        protected override IHostBuilder CreateHostBuilder()
        {
            var builder = base.CreateHostBuilder();

            builder.ConfigureAppConfiguration((hostingContext, config) =>
            {
                var env = hostingContext.HostingEnvironment;
                config.SetBasePath(env.ContentRootPath);

                // Настройка путей для тестового appsettings 
                var projectDir = Directory.GetCurrentDirectory();

                var applicationName = "Lotus.DeNova.Test";
                int index = projectDir.IndexOf(applicationName) + applicationName.Length;
                projectDir = projectDir.Remove(index);

                var pathAppsettings = Path.Combine(projectDir, "appsettings.json");
                if (File.Exists(pathAppsettings))
                {
                    config.AddJsonFile(pathAppsettings);
                }

                config.AddEnvironmentVariables();
            });

            return builder;
        }

        /// <summary>
        /// Конфигурация хоста приложения
        /// </summary>
        /// <param name="builder">Хост билдера</param>
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.Configure<PostgresDbConnectionOptions>(context.Configuration.GetSection("PostgresDbConnection"));

                var descriptor = services.SingleOrDefault(x => x.ServiceType == typeof(DbContextOptions<DeNovaDbContext>));
                services.Remove(descriptor);

                services.AddDbContext<DeNovaDbContext>(
                    (sp, options) =>
                    {
                        var dbOptions = sp.GetRequiredService<IOptions<PostgresDbConnectionOptions>>().Value;

                        var dbNameSyffix = Math.Abs(Guid.NewGuid().GetHashCode());
                        var dbName = $"denova_{dbNameSyffix}";
                        var connectionString = $"Database={dbName};Port={dbOptions.Port};Uid={dbOptions.UserId};Pwd={dbOptions.Password};Host={dbOptions.Server}";

						options
							.UseNpgsql(connectionString);
                    });

            });

            builder.Configure(app => 
            {

            });
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                DropDatabase();

                _disposed = true;
            }

            base.Dispose(disposing);
        }

        private void Initialize()
        {
	        InitDbContext();
            CreateDatabase();

			InitLogger();
        }

        private void InitLogger()
        {
            LoggerCreator = LoggerFactory.Create(builder =>
            {
                builder.AddDebug();
            });
        }

        private void InitDbContext()
        {
            Context = ServiceProvider.GetRequiredService<DeNovaDbContext>();
        }

        private void CreateDatabase()
        {
            Context.GetService<IMigrator>().Migrate();

			Context.Users.Add(AdminUser);
			Context.Users.Add(DefaultUser);
			Context.SaveChanges();
		}

		private void DropDatabase()
        {
            Context.Database.EnsureDeleted();
        }
    }
}