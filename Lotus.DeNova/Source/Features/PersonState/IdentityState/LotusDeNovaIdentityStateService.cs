//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема идентификации персонажа
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaIdentityStateService.cs
*		Cервис для работы с идентификационными сведениями о персонаже.
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
		/** \addtogroup DeNovaIdentityState
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Cервис для работы с идентификационными сведениями о персонаже
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class IdentityStateService : ILotusIdentityStateService
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
            public IdentityStateService(DeNovaDbContext context)
            {
                _context = context;
            }
            #endregion

            #region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Создание идентификационных сведений о персонаже по указанным данным
            /// </summary>
            /// <param name="identityInfoCreate">Параметры для создания идентификационных сведений о персонаже</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Идентификационные сведения о персонаже</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response<IdentityStateDto>> CreateAsync(IdentityStateCreateRequest identityInfoCreate, CancellationToken token)
            {
                IdentityState entity = identityInfoCreate.Adapt<IdentityState>();
				entity.IdentityStateId = Guid.NewGuid();

				_context.IdentityStates.Add(entity);
                await _context.SaveChangesAsync(token);

                IdentityStateDto result = entity.Adapt<IdentityStateDto>();

                return XResponse.Succeed(result);
            }

            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Обновление данных указанных идентификационных сведений о персонаже
            /// </summary>
            /// <param name="identityInfoUpdate">Параметры обновляемых идентификационных сведений о персонаже</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Идентификационные сведения о персонаже</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response<IdentityStateDto>> UpdateAsync(IdentityStateDto identityInfoUpdate, CancellationToken token)
            {
                IdentityState entity = identityInfoUpdate.Adapt<IdentityState>();

                _context.IdentityStates.Update(entity);
                await _context.SaveChangesAsync(token);

                IdentityStateDto result = entity.Adapt<IdentityStateDto>();

                return XResponse.Succeed(result);
            }

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение указанных идентификационных сведений о персонаже
			/// </summary>
			/// <param name="identityInfoId">Идентификатор идентификационных сведений о персонаже</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Идентификационные сведения о персонаже</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response<IdentityStateDto>> GetAsync(Guid identityInfoId, CancellationToken token)
			{
				IdentityState? entity = await _context.IdentityStates
					.FirstOrDefaultAsync(x => (x.IdentityStateId == identityInfoId && x.GameSaveId == null), token);
				if (entity == null)
				{
					return XResponse.Failed<IdentityStateDto>(XIdentityStateErrors.NotFound);
				}

				IdentityStateDto result = entity.Adapt<IdentityStateDto>();

				return XResponse.Succeed(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка идентификационных сведений о персонаже
			/// </summary>
			/// <param name="identityInfoRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Список идентификационных сведений о персонаже</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<ResponsePage<IdentityStateDto>> GetAllAsync(IdentityStatesDto identityInfoRequest, CancellationToken token)
            {
                var query = _context.IdentityStates.AsQueryable();

				query = query
					.Where(x => x.GameId == identityInfoRequest.GameId &&
								x.PersonId == identityInfoRequest.PersonId &&
								x.GameSaveId == null);

				query = query.Filter(identityInfoRequest.Filtering);

				var queryOrder = query.Sort(identityInfoRequest.Sorting, x => x.BeginPeriod);

				var result = await queryOrder.ToResponsePageAsync<IdentityState, IdentityStateDto>(identityInfoRequest, token);

                return result;
            }

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Удаление идентификационных сведений о персонаже
			/// </summary>
			/// <param name="identityInfoId">Идентификатор идентификационных сведений о персонаже</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Статус успешности</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response> DeleteAsync(Guid identityInfoId, CancellationToken token)
            {
                IdentityState? entity = await _context.IdentityStates
					.FirstOrDefaultAsync(x => (x.IdentityStateId == identityInfoId && x.GameSaveId == null), token);
                if (entity == null)
                {
                    return XResponse.Failed(XIdentityStateErrors.NotFound);
                }

                _context.IdentityStates.Remove(entity!);
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