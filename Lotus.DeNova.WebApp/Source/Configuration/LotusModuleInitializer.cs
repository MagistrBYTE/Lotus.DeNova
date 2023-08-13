//=====================================================================================================================
// Проект: Модуль Web приложения игровой вселенной DeNova.
// Раздел: Подсистема конфигурации и инициализации
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusModuleInitializer.cs
*		Инициализация модуля Web приложения игровой вселенной DeNova.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 30.04.2023
//=====================================================================================================================
using System;
using Microsoft.EntityFrameworkCore;
//=====================================================================================================================
namespace Lotus
{
    namespace DeNova
    {
		//-------------------------------------------------------------------------------------------------------------
		/**
         * \defgroup DeNovaWebAppConfiguration Подсистема конфигурации и инициализации
         * \ingroup DeNovaWebApp
         * \brief Подсистема конфигурации и инициализации.
         * @{
         */
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Инициализация модуль WebApi учетной записи пользователя
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public static class XModuleInitializer
        {
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Настройка сервисов модуля игровой вселенной DeNova
			/// </summary>
			/// <param name="services">Коллекция сервисов</param>
			/// <returns>Коллекция сервисов</returns>
			//---------------------------------------------------------------------------------------------------------
			public static IServiceCollection AddLotusDeNovaServices(this IServiceCollection services)
            {
                XMapping.Init();

                return services;
            }

            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Добавление в коллекцию сервисов базы данных
            /// </summary>
            /// <param name="services">Коллекция сервисов</param>
            /// <param name="configuration">Конфигурация</param>
            /// <returns>Коллекция сервисов</returns>
            //---------------------------------------------------------------------------------------------------------
            public static IServiceCollection AddLotusDeNovaDatabaseServices(this IServiceCollection services, IConfiguration configuration)
            {
                // Добавление CDeNovaDbContext для взаимодействия с базой данных
                services.AddDbContext<CDeNovaDbContext>(options =>
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

            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Инициализация базы данных
            /// </summary>
            /// <param name="application">Построитель web-приложения</param>
			/// <returns>Задача</returns>
            //---------------------------------------------------------------------------------------------------------
            public static async Task InitLotusDeNovaDatabase(this IApplicationBuilder application)
            {
                if (application == null)
                {
                    throw new ArgumentNullException(nameof(application));
                }

                if (application is not null)
                {
                    using var service_scope = application!.ApplicationServices!.GetService<IServiceScopeFactory>()!.CreateScope();
                    using var context = service_scope.ServiceProvider.GetRequiredService<CDeNovaDbContext>();

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
        }
        //-------------------------------------------------------------------------------------------------------------
        /**@}*/
        //-------------------------------------------------------------------------------------------------------------
    }
}
//=====================================================================================================================