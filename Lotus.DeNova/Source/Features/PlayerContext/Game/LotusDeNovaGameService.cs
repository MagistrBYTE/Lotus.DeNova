//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема контекста игры
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaGameService.cs
*		Cервис для работы с контекстом игры.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 30.04.2023
//=====================================================================================================================
using Mapster;
using Microsoft.EntityFrameworkCore;
//---------------------------------------------------------------------------------------------------------------------
using Lotus.Repository;
//=====================================================================================================================
namespace Lotus
{
    namespace DeNova
	{
		//-------------------------------------------------------------------------------------------------------------
		/** \addtogroup DeNovaGameContext
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Cервис для работы с контекстами игры
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class GameService : ILotusGameService
        {
            #region ======================================= ДАННЫЕ ====================================================
            private readonly DeNovaDbContext _context;
            #endregion

            #region ======================================= КОНСТРУКТОРЫ ==============================================
            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Конструктор инициализирует объект класса указанными параметрами
            /// </summary>
            /// <param name="context">Контекст БД</param>
            //---------------------------------------------------------------------------------------------------------
            public GameService(DeNovaDbContext context)
            {
                _context = context;
            }
			#endregion

			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Создание игры по указанным данным
			/// </summary>
			/// <remarks>
			/// Созданный контекст становиться актуальным
			/// </remarks>
			/// <param name="gameCreate">Параметры для создания игры</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Игра</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response<GameDto>> CreateAsync(GameCreateRequest gameCreate, CancellationToken token)
            {
                Game entity = gameCreate.Adapt<Game>();

				// Деактивируем существующие контекст
				var gameContext = await _context.Games
					.Where(x => x.UserId == gameCreate.UserId)
					.Where(x => x.IsCurrent)
					.SingleOrDefaultAsync();

				if(gameContext != null)
				{
					gameContext.IsCurrent = false;
					_context.Update(gameContext);
				}

				// Делаем активной
				entity.IsCurrent = true;
				_context.Games.Add(entity);

				await _context.SaveChangesAsync(token);

				GameDto result = entity.Adapt<GameDto>();

                return XResponse.Succeed(result);
            }

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Сохранение текущей игры
			/// </summary>
			/// <param name="saveCreate">Параметры для создания сохранения</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Сохранение игры</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response<GameSaveDto>> SaveAsync(GameSaveCreateRequest saveCreate, CancellationToken token)
			{
				GameSave? entity = null;

				if (saveCreate.GameSaveId.HasValue)
				{
					entity = await _context.GameSaves
						.FirstOrDefaultAsync(x => x.Id == saveCreate.GameSaveId.Value, token);
					if (entity == null)
					{
						return XResponse.Failed<GameSaveDto>(XGameErrors.SaveNotFound);
					}
				}
				if (entity is null)
				{
					entity = saveCreate.Adapt<GameSave>();

					_context.GameSaves.Add(entity);
					await _context.SaveChangesAsync(token);
				}

				//
				// Сохранение данных
				//
				await _context.SaveGameEntity<AddressState>(entity.GameId, entity.Id, token);
				await _context.SaveGameEntity<AvatarState>(entity.GameId, entity.Id, token);
				await _context.SaveGameEntity<IdentityState>(entity.GameId, entity.Id, token);
				await _context.SaveGameEntity<PlacementState>(entity.GameId, entity.Id, token);

				GameSaveDto result = entity.Adapt<GameSaveDto>();

				return XResponse.Succeed(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Загрузка указанного сохранения игры
			/// </summary>
			/// <param name="loadRequest">Параметры для загрузки сохранения</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Статус успешности</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response> LoadAsync(GameLoadRequest loadRequest, CancellationToken token)
			{
				//
				// Загрузка данных
				//
				await _context.LoadGameEntity<AddressState>(loadRequest.GameId, loadRequest.GameSaveId, token);
				await _context.LoadGameEntity<AvatarState>(loadRequest.GameId, loadRequest.GameSaveId, token);
				await _context.LoadGameEntity<IdentityState>(loadRequest.GameId, loadRequest.GameSaveId, token);
				await _context.LoadGameEntity<PlacementState>(loadRequest.GameId, loadRequest.GameSaveId, token);
				return XResponse.Succeed();
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение игры
			/// </summary>
			/// <param name="id">Идентификатор игры</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Игра</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response<GameDto>> GetAsync(Guid id, CancellationToken token)
			{
				Game? entity = await _context.Games.FirstOrDefaultAsync(x => x.Id == id, token);
				if (entity == null)
				{
					return XResponse.Failed<GameDto>(XGameErrors.NotFound);
				}

				GameDto result = entity.Adapt<GameDto>();

				return XResponse.Succeed(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение текущей (актуальной) игры для указанного игрока
			/// </summary>
			/// <param name="playerId">Идентификатор игрока</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Игра</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response<GameDto>> GetCurrentAsync(Guid playerId, CancellationToken token)
			{
				var entity = await _context.Games
					.Where(x => x.UserId == playerId)
					.Where(x => x.IsCurrent)
					.SingleOrDefaultAsync();

				if (entity == null)
				{
					return XResponse.Failed<GameDto>(XGameErrors.NotFound);
				}

				GameDto result = entity.Adapt<GameDto>();

				return XResponse.Succeed(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка игр
			/// </summary>
			/// <param name="gameRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Cписок игр</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<ResponsePage<GameDto>> GetAllAsync(GamesRequest gameRequest, CancellationToken token)
			{
				var query = _context.Games.AsQueryable();

				if (gameRequest.UserId.HasValue)
				{
					query = query.Where(x => x.UserId == gameRequest.UserId.Value);
				}

				query = query.Filter(gameRequest.Filtering);

				var queryOrder = query.Sort(gameRequest.Sorting, x => x.Id);

				var result = await queryOrder.ToResponsePageAsync<Game, GameDto>(gameRequest, token);

				return result;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка сохранений игры
			/// </summary>
			/// <param name="saveRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Cписок сохранений игры</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<ResponsePage<GameSaveDto>> GetAllSaveAsync(GameSavesRequest saveRequest, CancellationToken token)
			{
				var query = _context.GameSaves.AsQueryable();

				query = query.Where(x => x.GameId == saveRequest.GameId);

				query = query.Filter(saveRequest.Filtering);

				var queryOrder = query.Sort(saveRequest.Sorting, x => x.Created);

				var result = await queryOrder.ToResponsePageAsync<GameSave, GameSaveDto>(saveRequest, token);

				return result;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Удаление игры
			/// </summary>
			/// <param name="id">Идентификатор игры</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Статус успешности</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response> DeleteAsync(Guid id, CancellationToken token)
			{
				Game? entity = await _context.Games.FirstOrDefaultAsync(x => x.Id == id, token);
				if (entity == null)
				{
					return XResponse.Failed(XGameErrors.NotFound);
				}

				_context.Games.Remove(entity!);
				await _context.SaveChangesAsync(token);

				return XResponse.Succeed();
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Удаление сохранения игры
			/// </summary>
			/// <param name="id">Идентификатор сохранения игры</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Статус успешности</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response> DeleteSaveAsync(Guid id, CancellationToken token)
			{
				GameSave? entity = await _context.GameSaves.FirstOrDefaultAsync(x => x.Id == id, token);
				if (entity == null)
				{
					return XResponse.Failed(XGameErrors.SaveNotFound);
				}

				_context.GameSaves.Remove(entity!);
				await _context.SaveChangesAsync(token);

				return XResponse.Succeed();
			}
			#endregion
		}
        //-------------------------------------------------------------------------------------------------------------
        /**@}*/
        //-------------------------------------------------------------------------------------------------------------
    }
}
//=====================================================================================================================