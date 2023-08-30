//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема контекста игры
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaGameContextService.cs
*		Cервис для работы с контекстами игры.
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
		public class GameContextService : ILotusGameContextService
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
            public GameContextService(DeNovaDbContext context)
            {
                _context = context;
            }
			#endregion

			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Создание контекста игры по указанным данным
			/// </summary>
			/// <remarks>
			/// Созданный контекст становиться актуальным
			/// </remarks>
			/// <param name="gameCreate">Параметры для создания контекста игры</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Контекст игры</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response<GameContextDto>> CreateAsync(GameContextCreateDto gameCreate, CancellationToken token)
            {
                GameContext entity = gameCreate.Adapt<GameContext>();

				// Деактивируем существующие контекст
				var gameContext = await _context.GameContexts
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
				_context.GameContexts.Add(entity);

				await _context.SaveChangesAsync(token);

				GameContextDto result = entity.Adapt<GameContextDto>();

                return XResponse.Succeed(result);
            }

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Обновление данных указанного контекста игры
			/// </summary>
			/// <param name="gameUpdate">Параметры обновляемого контекста игры</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Контекст игры</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response<GameContextDto>> UpdateAsync(GameContextDto gameUpdate, CancellationToken token)
            {
				GameContext? entity =  _context.GameContexts.FirstOrDefault(x => x.Id == gameUpdate.Id);
				if(entity != null) 
				{
					if (entity.IsCurrent == false && gameUpdate.IsCurrent)
					{
						// Деактивируем существующие контекст
						var gameContext = await _context.GameContexts
							.Where(x => x.UserId == gameUpdate.UserId)
							.Where(x => x.IsCurrent)
							.SingleOrDefaultAsync();

						if (gameContext != null)
						{
							gameContext.IsCurrent = false;
							_context.Update(gameContext);
						}
					}

					gameUpdate.Adapt<GameContextDto, GameContext>(entity);

					_context.GameContexts.Update(entity);
					await _context.SaveChangesAsync(token);

					GameContextDto result = entity.Adapt<GameContextDto>();

					return XResponse.Succeed(result);
				}

				return XResponse.Failed<GameContextDto>(XGameContextErrors.NotFound);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение указанного контекста игры
			/// </summary>
			/// <param name="id">Идентификатор контекста игры</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Контекст игры</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response<GameContextDto>> GetAsync(Guid id, CancellationToken token)
			{
				GameContext? entity = await _context.GameContexts.FirstOrDefaultAsync(x => x.Id == id, token);
				if (entity == null)
				{
					return XResponse.Failed<GameContextDto>(XGameContextErrors.NotFound);
				}

				GameContextDto result = entity.Adapt<GameContextDto>();

				return XResponse.Succeed(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка контекстов игр
			/// </summary>
			/// <param name="gameRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Cписок контекстов игр</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<ResponsePage<GameContextDto>> GetAllAsync(GameContextsDto gameRequest, CancellationToken token)
            {
                var query = _context.GameContexts.AsQueryable();

				if(gameRequest.UserId.HasValue)
				{
					query = query.Where(x => x.UserId == gameRequest.UserId.Value);
				}

                query = query.Filter(gameRequest.Filtering);

				var queryOrder = query.Sort(gameRequest.Sorting, x => x.Id);

				var result = await queryOrder.ToResponsePageAsync<GameContext, GameContextDto>(gameRequest, token);

                return result;
            }

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Удаление контекста игры
			/// </summary>
			/// <param name="id">Идентификатор контекста игры</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Статус успешности</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response> DeleteAsync(Guid id, CancellationToken token)
            {
                GameContext? entity = await _context.GameContexts.FirstOrDefaultAsync(x => x.Id == id, token);
                if (entity == null)
                {
                    return XResponse.Failed(XGameContextErrors.NotFound);
                }

                _context.GameContexts.Remove(entity!);
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