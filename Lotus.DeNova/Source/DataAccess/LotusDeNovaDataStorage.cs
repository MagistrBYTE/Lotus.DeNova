using Lotus.Core;
using Lotus.Repository;

using Microsoft.EntityFrameworkCore;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaDataAccess
	*@{*/
    /// <summary>
    /// Интерфейс репозитория для взаимодействия с контекстом базы данных игровой вселенной DeNova.
    /// </summary>
    public interface ILotusDataStorageDeNova : ILotusDataStorage
    {
        #region Main methods
        /// <summary>
        /// Сохранение всех сущностей укзанного типа поддерживающих сохранение.
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности.</typeparam>
        /// <param name="gameContextId">Идентификатор игры.</param>
        /// <param name="gameSaveId">Идентификатор сохранения.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Задача.</returns>
        Task SaveGameEntity<TEntity>(Guid gameContextId, Guid gameSaveId, CancellationToken token)
            where TEntity : class, ILotusGameEntitySaveable, ILotusDuplicate<TEntity>;

        /// <summary>
        /// Загрузка всех сущностей укзанного типа поддерживающих сохранение.
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности.</typeparam>
        /// <param name="gameContextId">Идентификатор игры.</param>
        /// <param name="gameSaveId">Идентификатор сохранения.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Задача.</returns>
        Task LoadGameEntity<TEntity>(Guid gameContextId, Guid gameSaveId, CancellationToken token)
           where TEntity : class, ILotusGameEntitySaveable, ILotusDuplicate<TEntity>;
        #endregion
    }

    /// <summary>
    /// Репозиторий для взаимодействия с контекстом базы данных игровой вселенной DeNova.
    /// </summary>
    public class DataStorageDeNova : DataStorageContextDb<DeNovaDbContext>, ILotusDataStorageDeNova
    {
        /// <summary>
        /// Конструктор инициализирует объект класса указанными параметрами.
        /// </summary>
        /// <param name="context">Контекс базы данных.</param>
        public DataStorageDeNova(DeNovaDbContext context)
            : base(context)
        {
        }

        #region ILotusDataStorageDeNova methods
        /// <inheritdoc/>
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

        /// <inheritdoc/>
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
    /**@}*/
}