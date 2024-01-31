//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Слой данных
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaDbContext.cs
*		Контекс базы данных для хранения данных игровой вселенной DeNova.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 30.04.2023
//=====================================================================================================================
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
//---------------------------------------------------------------------------------------------------------------------
using Lotus.Account;
using Lotus.Repository;
using Lotus.Core;
//=====================================================================================================================
namespace Lotus
{
    namespace DeNova
    {
		//-------------------------------------------------------------------------------------------------------------
		/**
         * \defgroup DeNovaDataAccess Слой данных
         * \ingroup DeNova
         * \brief Слой данных модуля.
         * @{
         */
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Контекс базы данных для хранения данных игровой вселенной DeNova
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class DeNovaDbContext : AccountDbContext
        {
			#region ======================================= СВОЙСТВА ==================================================
			//
			// ТЕРРИТОРИАЛЬНО-АДРЕСНОЕ ХОЗЯЙСТВО
			//
			/// <summary>
			/// Список сельских поселений
			/// </summary>
			public DbSet<AddressVillageSettlement> AddressVillageSettlements { get; set; } = default!;

			/// <summary>
			/// Список населенных пунктов
			/// </summary>
			public DbSet<AddressVillage> AddressVillages { get; set; } = default!;

			/// <summary>
			/// Список улиц
			/// </summary>
			public DbSet<AddressStreet> AddressStreets { get; set; } = default!;

			/// <summary>
			/// Список адресов
			/// </summary>
			public DbSet<AddressElement> AddressElements { get; set; } = default!;

			//
			// ДАННЫЕ
			//
			/// <summary>
			/// Игровые сеттинги
			/// </summary>
			public DbSet<GameSettingType> GameSettingTypes { get; set; } = default!;

			/// <summary>
			/// Расы
			/// </summary>
			public DbSet<RaceType> RaceTypes { get; set; } = default!;

			/// <summary>
			/// Астрология
			/// </summary>
			public DbSet<AstrologyType> AstrologyTypes { get; set; } = default!;

			/// <summary>
			/// Сценарии
			/// </summary>
			public DbSet<ScenarioType> ScenarioTypes { get; set; } = default!;

			/// <summary>
			/// Параметры существ
			/// </summary>
			public DbSet<ParameterType> ParameterTypes { get; set; } = default!;

			/// <summary>
			/// Аспекты параметров существ
			/// </summary>
			public DbSet<ParameterAspectType> ParameterAspectTypes { get; set; } = default!;

			//
			// ИГРОВОЙ КОНТЕКСТ
			//
			/// <summary>
			/// Игры
			/// </summary>
			public DbSet<Game> Games { get; set; } = default!;

			/// <summary>
			/// Игры
			/// </summary>
			public DbSet<GameSave> GameSaves { get; set; } = default!;

			//
			// ПЕРСОНАЖ
			//
			/// <summary>
			/// Список персонажей
			/// </summary>
			public DbSet<Person> Persons { get; set; } = default!;

			/// <summary>
			/// Список параметров персонажей
			/// </summary>
			public DbSet<PersonParameter> PersonParameters { get; set; } = default!;

			/// <summary>
			/// Список аспектов параметров персонажей
			/// </summary>
			public DbSet<PersonParameterAspect> PersonParameterAspects { get; set; } = default!;

			//
			// ДИНАМИЧЕСКИЕ ДАННЫЕ
			//
			/// <summary>
			/// Список информации о рождении персонажа
			/// </summary>
			public DbSet<BirthdayState> BirthdayStates { get; set; } = default!;

			/// <summary>
			/// Список мест жительств персонажа
			/// </summary>
			public DbSet<AddressState> AddressStates { get; set; } = default!;

			/// <summary>
			/// Список аваторов для персонажа
			/// </summary>
			public DbSet<AvatarState> AvatarStates { get; set; } = default!;

			/// <summary>
			/// Список идентификационных сведений о персонаже
			/// </summary>
			public DbSet<IdentityState> IdentityStates { get; set; } = default!;

			/// <summary>
			/// Список местоположений персонажа
			/// </summary>
			public DbSet<PlacementState> PlacementStates { get; set; } = default!;
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор по умолчанию инициализирует объект класса предустановленными значениями
			/// </summary>
			//---------------------------------------------------------------------------------------------------------
			public DeNovaDbContext()
            {
            }

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="options">Параметры конфигурации</param>
			//---------------------------------------------------------------------------------------------------------
			public DeNovaDbContext(DbContextOptions<DeNovaDbContext> options)
				: base(options)
			{
			}
			#endregion

			#region ======================================= ПЕРЕГРУЖЕННЫЕ МЕТОДЫ ======================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конфигурирование моделей
			/// </summary>
			/// <param name="modelBuilder">Интерфейс для построения моделей</param>
			//---------------------------------------------------------------------------------------------------------
			protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
				base.OnModelCreating(modelBuilder);

                XDbConfiguration.ConfigurationDenovaDatabase(modelBuilder);
            }
			#endregion
		}
		//-------------------------------------------------------------------------------------------------------------
		/**@}*/
		//-------------------------------------------------------------------------------------------------------------
	}
}
//=====================================================================================================================