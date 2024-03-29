using Lotus.Account;
using Lotus.Core;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Lotus.DeNova.Test
{
    /// <summary>
    /// Дефолтная фабрика для создания Fixture для интеграционных тестов.
    /// </summary>
    public class DeNovaDefaultFactory : WebApplicationFactory<Program>
    {
        /// <summary>
        /// Пользователь.
        /// </summary>
        public static readonly User DefaultUser = new()
        {
            Id = Guid.Parse("42863dae-924f-4385-9967-fb800f44a984"),
            Login = "DemDaniel",
            PasswordHash = XHashHelper.GetHash("123456"),
            Email = "demdaniel@gmail.com",
            Name = "Даниил",
            Surname = "Дементьев",
            Patronymic = "Сергеевич",
            RoleId = XUserRoleConstants.User.Id
        };

        private IServiceScope _scope;
        private bool _disposed;

        /// <summary>
        /// Поставщик сервисов.
        /// </summary>
        public IServiceProvider ServiceProvider => Scope.ServiceProvider;

        /// <summary>
        /// База данных.
        /// </summary>
        public DeNovaDbContext Context { get; private set; }

        /// <summary>
        /// Фабрика логгера.
        /// </summary>
        public ILoggerFactory LoggerCreator { get; private set; }

        /// <summary>
        /// Поставщик сервисов.
        /// </summary>
        public IServiceScope Scope => _scope ??= Services.CreateScope();

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public DeNovaDefaultFactory()
        {
            Initialize();
        }

        /// <summary>
        /// Конфигурация билдера хоста приложения.
        /// </summary>
        /// <returns>Хост билдера.</returns>
        protected override IHostBuilder CreateHostBuilder()
        {
            var builder = base.CreateHostBuilder()!;

            builder.ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    config.SetBasePath(env.ContentRootPath);

                    // Настройка путей для тестового appsettings 
                    var projectDir = Directory.GetCurrentDirectory();

                    var applicationName = "Lotus.DeNova.Test";
                    var index = projectDir.IndexOf(applicationName) + applicationName.Length;
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
        /// Конфигурация хоста приложения.
        /// </summary>
        /// <param name="builder">Хост билдера.</param>
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.Configure<PostgresDbConnectionOptions>(context.Configuration.GetSection("PostgresDbConnection"));

                var descriptor = services.SingleOrDefault(x => x.ServiceType == typeof(DbContextOptions<DeNovaDbContext>));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

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

            Context.Users.Add(DefaultUser);

            Context.SaveChanges();
        }

        private void DropDatabase()
        {
            Context.Database.EnsureDeleted();
        }
    }
}