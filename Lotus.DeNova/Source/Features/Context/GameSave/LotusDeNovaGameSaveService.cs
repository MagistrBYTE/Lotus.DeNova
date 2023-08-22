//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема контекста игры
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaGameSaveService.cs
*		Cервис для сохранения контекста игры.
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
		/// Cервис для сохранения контекста игры
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class GameSaveService : ILotusGameSaveService
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
            public GameSaveService(DeNovaDbContext context)
            {
                _context = context;
            }
			#endregion

			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Сохранение текущего контекста игры
			/// </summary>
			/// <param name="saveCreate">Параметры для создания сохранения</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Сохранение контекста игры</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response<GameSaveDto>> SaveAsync(GameSaveCreateDto saveCreate, CancellationToken token)
			{
				GameSave? entity = null;

				if (saveCreate.GameSaveId.HasValue)
				{
					entity = await _context.GameSaves
						.FirstOrDefaultAsync(x => x.Id == saveCreate.GameSaveId.Value, token);
					if (entity == null)
					{
						return XResponse.Failed<GameSaveDto>(XGameSaveErrors.NotFound);
					}
				}
				if(entity is null)
				{
					entity = saveCreate.Adapt<GameSave>();

					_context.GameSaves.Add(entity);
					await _context.SaveChangesAsync(token);
				}

				GameSaveDto result = entity.Adapt<GameSaveDto>();

				//
				// Сохранение данных
				//
				await _context.SaveGameEntity<AddressInfo>(entity.GameContextId, entity.Id, token);
				await _context.SaveGameEntity<AvatarInfo>(entity.GameContextId, entity.Id, token);
				await _context.SaveGameEntity<IdentityInfo>(entity.GameContextId, entity.Id, token);

				return XResponse.Succeed(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Загрузка указанного сохранения контекста игры
			/// </summary>
			/// <param name="load">Параметры для загрузки сохранения</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Статус успешности</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response> LoadAsync(GameLoadDto load, CancellationToken token)
			{
				//
				// Загрузка данных
				//
				await _context.LoadGameEntity<AddressInfo>(load.GameContextId, load.GameSaveId, token);
				await _context.LoadGameEntity<AvatarInfo>(load.GameContextId, load.GameSaveId, token);
				await _context.LoadGameEntity<IdentityInfo>(load.GameContextId, load.GameSaveId, token);

				return XResponse.Succeed();
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Обновление сохранения контекста игры
			/// </summary>
			/// <param name="saveUpdate">Параметры обновляемого сохранения контекста игры</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Сохранение контекста игры</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response<GameSaveDto>> UpdateAsync(GameSaveDto saveUpdate, CancellationToken token)
			{
				GameSave entity = saveUpdate.Adapt<GameSave>();

				_context.GameSaves.Update(entity);
				await _context.SaveChangesAsync(token);

				GameSaveDto result = entity.Adapt<GameSaveDto>();

				return XResponse.Succeed(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Удаление сохранения контекста игры
			/// </summary>
			/// <param name="id">Идентификатор сохранения контекста игры</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Статус успешности</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response> DeleteAsync(Guid id, CancellationToken token)
			{
				GameSave? entity = await _context.GameSaves.FirstOrDefaultAsync(x => x.Id == id, token);
				if (entity == null)
				{
					return XResponse.Failed(XGameSaveErrors.NotFound);
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