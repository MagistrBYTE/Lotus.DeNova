//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема конфигурации и инициализации
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaDbSeed.cs
*		Статический класс для первоначальной инициализации базы данных.
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
        /** \addtogroup DeNovaConfiguration
        *@{*/
        //-------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Статический класс для конфигурации и инициализации базы данных
        /// </summary>
        //-------------------------------------------------------------------------------------------------------------
        public static class XDbSeed
        {
			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Создание сущностей по умолчанию
			/// </summary>
			/// <param name="modelBuilder">Интерфейс для построения моделей</param>
			//---------------------------------------------------------------------------------------------------------
			public static void Create(ModelBuilder modelBuilder)
			{
				CreateGameSettingType(modelBuilder);
				CreateRaceType(modelBuilder);
				CreateAstrologyType(modelBuilder);
				CreateScenarioType(modelBuilder);
				CreateParameterType(modelBuilder);
				CreateParameterAspectType(modelBuilder);
			}
			#endregion

			#region ======================================= ОПРЕДЕЛЕНИЕ ДАННЫХ ========================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Создание сеттингов игры
			/// </summary>
			/// <param name="modelBuilder">Интерфейс для построения моделей</param>
			//---------------------------------------------------------------------------------------------------------
			public static void CreateGameSettingType(ModelBuilder modelBuilder)
			{
				// Определение для таблицы
				var model = modelBuilder.Entity<GameSettingType>();

				// Данные
				model.HasData(XGameSettingTypeConstants.Sentra);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Создание рас
			/// </summary>
			/// <param name="modelBuilder">Интерфейс для построения моделей</param>
			//---------------------------------------------------------------------------------------------------------
			public static void CreateRaceType(ModelBuilder modelBuilder)
			{
				// Определение для таблицы
				var model = modelBuilder.Entity<RaceType>();

				// Данные
				model.HasData(XRaceTypeConstants.Erian, 
					XRaceTypeConstants.Zavroteanen,
					XRaceTypeConstants.Leohart, 
					XRaceTypeConstants.Tribe,
					XRaceTypeConstants.Gwell,
					XRaceTypeConstants.Elgou,
					XRaceTypeConstants.Fergarian);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Создание данных по астрологии
			/// </summary>
			/// <param name="modelBuilder">Интерфейс для построения моделей</param>
			//---------------------------------------------------------------------------------------------------------
			public static void CreateAstrologyType(ModelBuilder modelBuilder)
			{
				// Определение для таблицы
				var model = modelBuilder.Entity<AstrologyType>();

				// Данные
				model.HasData(XAstrologyTypeConstants.Ophiuchus,
					XAstrologyTypeConstants.Quetzalcoatl,
					XAstrologyTypeConstants.Taurus);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Создание сценариев
			/// </summary>
			/// <param name="modelBuilder">Интерфейс для построения моделей</param>
			//---------------------------------------------------------------------------------------------------------
			public static void CreateScenarioType(ModelBuilder modelBuilder)
			{
				// Определение для таблицы
				var model = modelBuilder.Entity<ScenarioType>();

				// Данные
				model.HasData(XScenarioTypeConstants.Sandbox);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Создание типов параметров существ
			/// </summary>
			/// <param name="modelBuilder">Интерфейс для построения моделей</param>
			//---------------------------------------------------------------------------------------------------------
			public static void CreateParameterType(ModelBuilder modelBuilder)
			{
				// Определение для таблицы
				var model = modelBuilder.Entity<ParameterType>();

				// Данные
				model.HasData(
					XParameterTypeConstants.PhysicalStrength,
					XParameterTypeConstants.Dexterity,
					XParameterTypeConstants.Endurance,
					XParameterTypeConstants.Physique,

					XParameterTypeConstants.Perception,
					XParameterTypeConstants.Mind,
					XParameterTypeConstants.Willpower,
					XParameterTypeConstants.Spirituality,

					XParameterTypeConstants.Appearance,
					XParameterTypeConstants.Charisma,
					XParameterTypeConstants.Influence,
					XParameterTypeConstants.Status
					);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Создание типов аспектов параметров существ
			/// </summary>
			/// <param name="modelBuilder">Интерфейс для построения моделей</param>
			//---------------------------------------------------------------------------------------------------------
			public static void CreateParameterAspectType(ModelBuilder modelBuilder)
			{
				// Определение для таблицы
				var model = modelBuilder.Entity<ParameterAspectType>();

				// Данные
				model.HasData(
					XParameterAspectTypeConstants.StrongArms
					);
			}
			#endregion
		}
        //-------------------------------------------------------------------------------------------------------------
        /**@}*/
        //-------------------------------------------------------------------------------------------------------------
    }
}
//=====================================================================================================================