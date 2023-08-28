//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема конфигурации и инициализации
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaDbConfiguration.cs
*		Статический класс для конфигурации и инициализации базы данных.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 30.04.2023
//=====================================================================================================================
using Microsoft.EntityFrameworkCore;
//=====================================================================================================================
namespace Lotus
{
    namespace DeNova
    {
        //-------------------------------------------------------------------------------------------------------------
        /**
         * \defgroup DeNovaConfiguration Подсистема конфигурации и инициализации
         * \ingroup DeNova
         * \brief Подсистема конфигурации и инициализации.
         * @{
         */
        //-------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Статический класс для конфигурации и инициализации базы данных
        /// </summary>
        //-------------------------------------------------------------------------------------------------------------
        public static class XDbConfiguration
        {
            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Конфигурация и первоначальная инициализация базы данных
            /// </summary>
            /// <remarks>
            /// Вызывается в <see cref="DeNovaDbContext.OnModelCreating(ModelBuilder)"/>
            /// </remarks>
            /// <param name="modelBuilder">Интерфейс для построения моделей</param>
            //---------------------------------------------------------------------------------------------------------
            public static void ConfigurationDenovaDatabase(ModelBuilder modelBuilder)
            {
				//
				// ТЕРРИТОРИАЛЬНО-АДРЕСНОЕ ХОЗЯЙСТВО
				//
				AddressElement.ModelCreating(modelBuilder);
				AddressStreet.ModelCreating(modelBuilder);
				AddressVillage.ModelCreating(modelBuilder);
				AddressVillageSettlement.ModelCreating(modelBuilder);

				//
				// ДАННЫЕ
				//
				CampaignSetting.ModelCreating(modelBuilder);
				Race.ModelCreating(modelBuilder);
				Astrology.ModelCreating(modelBuilder);
				Image.ModelCreating(modelBuilder);
				Person.ModelCreating(modelBuilder);

				//
				// ИГРОВОЙ КОНТЕКСТ
				//
				GameContext.ModelCreating(modelBuilder);
				GameSave.ModelCreating(modelBuilder);

				//
				// ДИНАМИЧЕСКИЕ ДАННЫЕ
				//
				BirthdayInfo.ModelCreating(modelBuilder);
				AddressInfo.ModelCreating(modelBuilder);
				AvatarInfo.ModelCreating(modelBuilder);
				IdentityInfo.ModelCreating(modelBuilder);
				PlacementInfo.ModelCreating(modelBuilder);

				// Первоначальная инициализация через миграцию
				XDbSeed.Create(modelBuilder);
			}
        }
        //-------------------------------------------------------------------------------------------------------------
        /**@}*/
        //-------------------------------------------------------------------------------------------------------------
    }
}
//=====================================================================================================================