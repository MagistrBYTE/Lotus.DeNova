//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Слой данных
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaRepository.cs
*		Репозиторий для взаимодействия с контекстом базы данных игровой вселенной DeNova.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 30.04.2023
//=====================================================================================================================
using Microsoft.EntityFrameworkCore;
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
		/** \addtogroup DeNovaDataAccess
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Интерфейс репозитория для взаимодействия с контекстом базы данных игровой вселенной DeNova
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public interface ILotusRepositoryDeNova : ILotusRepository
		{
			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Сохранение всех сущностей укзанного типа поддерживающих сохранение
			/// </summary>
			/// <typeparam name="TEntity">Тип сущности</typeparam>
			/// <param name="gameContextId">Идентификатор игры</param>
			/// <param name="gameSaveId">Идентификатор сохранения</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Задача</returns>
			//---------------------------------------------------------------------------------------------------------
			Task SaveGameEntity<TEntity>(Guid gameContextId, Guid gameSaveId, CancellationToken token)
				where TEntity : class, ILotusGameEntitySaveable, ILotusDuplicate<TEntity>;

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Загрузка всех сущностей укзанного типа поддерживающих сохранение
			/// </summary>
			/// <typeparam name="TEntity">Тип сущности</typeparam>
			/// <param name="gameContextId">Идентификатор игры</param>
			/// <param name="gameSaveId">Идентификатор сохранения</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Задача</returns>
			//---------------------------------------------------------------------------------------------------------
			Task LoadGameEntity<TEntity>(Guid gameContextId, Guid gameSaveId, CancellationToken token)
			   where TEntity : class, ILotusGameEntitySaveable, ILotusDuplicate<TEntity>;
			#endregion
		}

		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Репозиторий для взаимодействия с контекстом базы данных игровой вселенной DeNova
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class RepositoryDeNova : RepositoryContextDb<DeNovaDbContext>, ILotusRepositoryDeNova
		{
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// 
			/// </summary>
			/// <param name="context">Контекс базы данных</param>
			//---------------------------------------------------------------------------------------------------------
			public RepositoryDeNova(DeNovaDbContext context)
				: base(context)
			{
			}

			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Сохранение всех сущностей укзанного типа поддерживающих сохранение
			/// </summary>
			/// <typeparam name="TEntity">Тип сущности</typeparam>
			/// <param name="gameContextId">Идентификатор игры</param>
			/// <param name="gameSaveId">Идентификатор сохранения</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Задача</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task SaveGameEntity<TEntity>(Guid gameContextId, Guid gameSaveId, CancellationToken token)
				where TEntity : class, ILotusGameEntitySaveable, ILotusDuplicate<TEntity>
			{
				var entities = Query<TEntity>();

				// Получаем все актуальные сущности для данного игрового контекста
				var entitiesActual = await entities
					.Where(x => x.GameId == gameContextId)
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
					RemoveRange(entitiesDelete);
					await FlushAsync(token);
				}

				// Копируем
				var entitiesSave = entitiesActual.Select(x => x.Duplicate()).ToArray();
				foreach (var entity in entitiesSave)
				{
					entity.GameSaveId = gameSaveId;
				}

				// Сохраняем
				AddRange(entitiesSave);
				await FlushAsync(token);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Загрузка всех сущностей укзанного типа поддерживающих сохранение
			/// </summary>
			/// <typeparam name="TEntity">Тип сущности</typeparam>
			/// <param name="gameContextId">Идентификатор игры</param>
			/// <param name="gameSaveId">Идентификатор сохранения</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Задача</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task LoadGameEntity<TEntity>(Guid gameContextId, Guid gameSaveId, CancellationToken token)
				where TEntity : class, ILotusGameEntitySaveable, ILotusDuplicate<TEntity>
			{
				var entities = Query<TEntity>();

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
					.Where(x => x.GameId == gameContextId)
					.Where(x => x.GameSaveId == null)
					.ToArrayAsync(token);
				if (entitiesActual.Length > 0)
				{
					RemoveRange(entitiesActual);
					await FlushAsync(token);
				}

				// Копируем параметры сохранённых сущностей в текущее состояние
				var entitiesNewActual = entitiesSave.Select(x => x.Duplicate()).ToArray();
				foreach (var entity in entitiesNewActual)
				{
					entity.GameSaveId = null;
				}

				// Сохраняем
				AddRange(entitiesNewActual);
				await FlushAsync(token);
			}
			#endregion
		}
		//-------------------------------------------------------------------------------------------------------------
		/**@}*/
		//-------------------------------------------------------------------------------------------------------------
	}
}
//=====================================================================================================================