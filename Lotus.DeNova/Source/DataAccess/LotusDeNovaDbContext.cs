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
		public class DeNovaDbContext : CAccountDbContext
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
			public DbSet<CampaignSetting> CampaignSettings { get; set; } = default!;

			/// <summary>
			/// Расы
			/// </summary>
			public DbSet<Race> Races { get; set; } = default!;

			/// <summary>
			/// Астралогия
			/// </summary>
			public DbSet<Astrology> Astrologies { get; set; } = default!;

			/// <summary>
			/// Астралогия
			/// </summary>
			public DbSet<Image> Images { get; set; } = default!;

			//
			// ИГРОВОЙ КОНТЕКСТ
			//
			/// <summary>
			/// Игры
			/// </summary>
			public DbSet<GameContext> GameContexts { get; set; } = default!;

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

			//
			// ДИНАМИЧЕСКИЕ ДАННЫЕ
			//
			/// <summary>
			/// Список информации о рождении персонажа
			/// </summary>
			public DbSet<BirthdayInfo> BirthdayInfos { get; set; } = default!;

			/// <summary>
			/// Список мест жительств персонажа
			/// </summary>
			public DbSet<AddressInfo> AddressInfos { get; set; } = default!;

			/// <summary>
			/// Список аваторов для персонажа
			/// </summary>
			public DbSet<AvatarInfo> AvatarInfos { get; set; } = default!;

			/// <summary>
			/// Список идентификационных сведений о персонаже
			/// </summary>
			public DbSet<IdentityInfo> IdentityInfos { get; set; } = default!;
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

			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Сохранение всех сущностей укзанного типа поддерживающих сохранение
			/// </summary>
			/// <typeparam name="TEntity">Тип сущности</typeparam>
			/// <param name="gameContextId">Идентификатор контекста игры</param>
			/// <param name="gameSaveId">Идентификатор сохранения</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Задача</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task SaveGameEntity<TEntity>(Guid gameContextId, Guid gameSaveId, CancellationToken token)
				where TEntity : class, ILotusGameEntitySaveable, ILotusDuplicate<TEntity>
			{
				var entities = this.Set<TEntity>();

				// Получаем все актуальные сущности для данного игрового контекста
				var entitiesActual = await entities
					.Where(x => x.GameContextId == gameContextId)
					.Where(x => x.GameSaveId == null)
					.ToArrayAsync(token);
				if (entitiesActual.Length == 0)
				{
					// Сущностей для сохранения нет
					return;
				}

				// Удаляем все сущности под указанным сохранением
				var entitiesDelete = await entities
					.Where(x => x.GameSaveId == gameSaveId)
					.ToArrayAsync(token);
				if (entitiesDelete.Length > 0)
				{
					entities.RemoveRange(entitiesDelete);
					await this.SaveChangesAsync(token);
				}

				// Копируем
				var entitiesSave = entitiesActual.Select(x => x.Duplicate());
				foreach (var entity in entitiesSave)
				{
					entity.GameSaveId = gameSaveId;
				}

				// Сохраняем
				entities.AddRange(entitiesSave);
				await this.SaveChangesAsync(token);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Загрузка всех сущностей укзанного типа поддерживающих сохранение
			/// </summary>
			/// <typeparam name="TEntity">Тип сущности</typeparam>
			/// <param name="gameContextId">Идентификатор контекста игры</param>
			/// <param name="gameSaveId">Идентификатор сохранения</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Задача</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task LoadGameEntity<TEntity>(Guid gameContextId, Guid gameSaveId, CancellationToken token)
				where TEntity : class, ILotusGameEntitySaveable, ILotusDuplicate<TEntity>
			{
				var entities = this.Set<TEntity>();

				// Получаем все сущности под указанным сохранением
				var entitiesSave = await entities
					.Where(x => x.GameSaveId == gameSaveId)
					.ToArrayAsync(token);
				if (entitiesSave.Length == 0)
				{
					// Сущностей для загрузки нет
					return;
				}

				// Получаем все актуальные сущности для данного игрового контекста и удаляем их
				var entitiesActual = await entities
					.Where(x => x.GameContextId == gameContextId)
					.Where(x => x.GameSaveId == null)
					.ToArrayAsync(token);
				if (entitiesActual.Length > 0)
				{
					entities.RemoveRange(entitiesActual);
					await SaveChangesAsync(token);
				}

				// Копируем параметры сохранённых сущностей в текущее состояние
				var entitiesNewActual = entitiesSave.Select(x => x.Duplicate());
				foreach (var entity in entitiesNewActual)
				{
					entity.GameSaveId = null;
				}

				// Сохраняем
				entities.AddRange(entitiesNewActual);
				await SaveChangesAsync(token);
			}
			#endregion
		}
		//-------------------------------------------------------------------------------------------------------------
		/**@}*/
		//-------------------------------------------------------------------------------------------------------------
	}
}
//=====================================================================================================================