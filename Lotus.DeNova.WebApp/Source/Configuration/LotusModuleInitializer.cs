using Microsoft.EntityFrameworkCore;

namespace Lotus.DeNova
{
    /**
     * \defgroup DeNovaWebAppConfiguration Подсистема конфигурации и инициализации
     * \ingroup DeNovaWebApp
     * \brief Подсистема конфигурации и инициализации.
     * @{
     */
    /// <summary>
    /// Инициализация модуль WebApi учетной записи пользователя.
    /// </summary>
    public static class XModuleInitializer
    {
        /// <summary>
        /// Настройка сервисов модуля игровой вселенной DeNova.
        /// </summary>
        /// <param name="services">Коллекция сервисов.</param>
        /// <returns>Коллекция сервисов.</returns>
        public static IServiceCollection AddLotusDeNovaServices(this IServiceCollection services)
        {
            services.AddScoped<ILotusDataStorageDeNova, DataStorageDeNova>();

            services.AddScoped<ILotusAstrologyTypeService, AstrologyTypeService>();
            services.AddScoped<ILotusRaceTypeService, RaceTypeService>();
            services.AddScoped<ILotusScenarioTypeService, ScenarioTypeService>();
            services.AddScoped<ILotusParameterTypeService, ParameterTypeService>();
            services.AddScoped<ILotusParameterAspectTypeService, ParameterAspectTypeService>();

            services.AddScoped<ILotusGameService, GameService>();
            services.AddScoped<ILotusPersonService, PersonService>();
            services.AddScoped<ILotusPersonParameterService, PersonParameterService>();
            services.AddScoped<ILotusPersonParameterAspectService, PersonParameterAspectService>();

            services.AddScoped<ILotusAddressStateService, AddressStateService>();
            services.AddScoped<ILotusAvatarStateService, AvatarStateService>();
            services.AddScoped<ILotusIdentityStateService, IdentityStateService>();
            services.AddScoped<ILotusPlacementStateService, PlacementStateService>();

            XMapping.Init();

            return services;
        }

        /// <summary>
        /// Добавление в коллекцию сервисов базы данных.
        /// </summary>
        /// <param name="services">Коллекция сервисов.</param>
        /// <param name="configuration">Конфигурация.</param>
        /// <returns>Коллекция сервисов.</returns>
        public static IServiceCollection AddLotusDeNovaDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Добавление DeNovaDbContext для взаимодействия с базой данных
            services.AddDbContext<DeNovaDbContext>(options =>
            {
                options.UseOpenIddict();
                options.UseNpgsql(configuration.GetConnectionString(XDbConstants.ConnectingDenovaDb),
                            optionsBuilder =>
                            {
                                optionsBuilder.MigrationsHistoryTable(XDbConstants.MigrationHistoryTableName,
                                    XDbConstants.SchemeName);
                            });
            });

            return services;
        }

        /// <summary>
        /// Инициализация базы данных.
        /// </summary>
        /// <param name="application">Построитель web-приложения.</param>
        /// <returns>Задача.</returns>
        public static async Task InitLotusDeNovaDatabaseAsync(this IApplicationBuilder application)
        {
            ArgumentNullException.ThrowIfNull(nameof(application));

            using var service_scope = application!.ApplicationServices!.GetService<IServiceScopeFactory>()!.CreateScope();
            using var context = service_scope.ServiceProvider.GetRequiredService<DeNovaDbContext>();

            try
            {
                await context.Database.MigrateAsync();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
        }
    }
    /**@}*/
}