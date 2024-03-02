using Lotus.Repository;

using Mapster;

using Microsoft.EntityFrameworkCore;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaGameContext
	*@{*/
    /// <summary>
    /// Cервис для работы с контекстами игры.
    /// </summary>
    public class GameService : ILotusGameService
    {
        #region Fields
        private readonly ILotusDataStorageDeNova _dataStorage;
        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор инициализирует объект класса указанными параметрами.
        /// </summary>
        /// <param name="dataStorage">Репозиторий игровой вселенной DeNova.</param>
        public GameService(ILotusDataStorageDeNova dataStorage)
        {
            _dataStorage = dataStorage;
        }
        #endregion

        #region ILotusGameService methods
        /// <inheritdoc/>
        public async Task<Response<GameDto>> CreateAsync(GameCreateRequest gameCreate, CancellationToken token)
        {
            var entity = gameCreate.Adapt<Game>();

            // Деактивируем существующие контекст
            var gameContext = await _dataStorage.Query<Game>()
                .Where(x => x.UserId == gameCreate.UserId)
                .Where(x => x.IsCurrent)
                .SingleOrDefaultAsync(token);

            if (gameContext != null)
            {
                gameContext.IsCurrent = false;
                _dataStorage.Update(gameContext);
            }

            // Делаем активной
            entity.IsCurrent = true;
            _dataStorage.Add(entity);

            await _dataStorage.SaveChangesAsync(token);

            var result = entity.Adapt<GameDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<Response<GameSaveDto>> SaveAsync(GameSaveCreateRequest saveCreate, CancellationToken token)
        {
            GameSave? entity = null;

            if (saveCreate.GameSaveId.HasValue)
            {
                entity = await _dataStorage.Query<GameSave>()
                    .FirstOrDefaultAsync(x => x.Id == saveCreate.GameSaveId.Value, token);
                if (entity == null)
                {
                    return XResponse.Failed<GameSaveDto>(XGameErrors.SaveNotFound);
                }
            }
            if (entity is null)
            {
                entity = saveCreate.Adapt<GameSave>();

                _dataStorage.Add(entity);
                await _dataStorage.SaveChangesAsync(token);
            }

            //
            // Сохранение данных
            //
            await _dataStorage.SaveGameEntity<AddressState>(entity.GameId, entity.Id, token);
            await _dataStorage.SaveGameEntity<AvatarState>(entity.GameId, entity.Id, token);
            await _dataStorage.SaveGameEntity<IdentityState>(entity.GameId, entity.Id, token);
            await _dataStorage.SaveGameEntity<PlacementState>(entity.GameId, entity.Id, token);

            var result = entity.Adapt<GameSaveDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<Response> LoadAsync(GameLoadRequest loadRequest, CancellationToken token)
        {
            //
            // Загрузка данных
            //
            await _dataStorage.LoadGameEntity<AddressState>(loadRequest.GameId, loadRequest.GameSaveId, token);
            await _dataStorage.LoadGameEntity<AvatarState>(loadRequest.GameId, loadRequest.GameSaveId, token);
            await _dataStorage.LoadGameEntity<IdentityState>(loadRequest.GameId, loadRequest.GameSaveId, token);
            await _dataStorage.LoadGameEntity<PlacementState>(loadRequest.GameId, loadRequest.GameSaveId, token);
            return XResponse.Succeed();
        }

        /// <inheritdoc/>
        public async Task<Response<GameDto>> GetAsync(Guid id, CancellationToken token)
        {
            var entity = await _dataStorage.GetByIdAsync<Game, Guid>(id, token);
            if (entity == null)
            {
                return XResponse.Failed<GameDto>(XGameErrors.NotFound);
            }

            var result = entity.Adapt<GameDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<Response<GameDto>> GetCurrentAsync(Guid playerId, CancellationToken token)
        {
            var entity = await _dataStorage.Query<Game>()
                .Where(x => x.UserId == playerId)
                .Where(x => x.IsCurrent)
                .SingleOrDefaultAsync(token);

            if (entity == null)
            {
                return XResponse.Failed<GameDto>(XGameErrors.NotFound);
            }

            var result = entity.Adapt<GameDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<ResponsePage<GameDto>> GetAllAsync(GamesRequest gameRequest, CancellationToken token)
        {
            var query = _dataStorage.Query<Game>();

            if (gameRequest.UserId.HasValue)
            {
                query = query.Where(x => x.UserId == gameRequest.UserId.Value);
            }

            query = query.Filter(gameRequest.Filtering);

            var queryOrder = query.Sort(gameRequest.Sorting, x => x.Id);

            var result = await queryOrder.ToResponsePageAsync<Game, GameDto>(gameRequest, token);

            return result;
        }

        /// <inheritdoc/>
        public async Task<ResponsePage<GameSaveDto>> GetAllSaveAsync(GameSavesRequest saveRequest, CancellationToken token)
        {
            var query = _dataStorage.Query<GameSave>();

            query = query.Where(x => x.GameId == saveRequest.GameId);

            query = query.Filter(saveRequest.Filtering);

            var queryOrder = query.Sort(saveRequest.Sorting, x => x.Created);

            var result = await queryOrder.ToResponsePageAsync<GameSave, GameSaveDto>(saveRequest, token);

            return result;
        }

        /// <inheritdoc/>
        public async Task<Response> DeleteAsync(Guid id, CancellationToken token)
        {
            var entity = await _dataStorage.GetByIdAsync<Game, Guid>(id, token);
            if (entity == null)
            {
                return XResponse.Failed(XGameErrors.NotFound);
            }

            _dataStorage.Remove(entity!);
            await _dataStorage.SaveChangesAsync(token);

            return XResponse.Succeed();
        }

        /// <inheritdoc/>
        public async Task<Response> DeleteSaveAsync(Guid id, CancellationToken token)
        {
            var entity = await _dataStorage.GetByIdAsync<GameSave, Guid>(id, token);
            if (entity == null)
            {
                return XResponse.Failed(XGameErrors.SaveNotFound);
            }

            _dataStorage.Remove(entity!);
            await _dataStorage.SaveChangesAsync(token);

            return XResponse.Succeed();
        }
        #endregion
    }
    /**@}*/
}