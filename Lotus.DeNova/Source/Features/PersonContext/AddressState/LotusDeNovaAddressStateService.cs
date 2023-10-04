//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема место жительства
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaAddressStateService.cs
*		Cервис для работы с местом жительства персонажа.
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
		/** \addtogroup DeNovaAddressState
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Cервис для работы с местом жительства персонажа
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class AddressStateService : ILotusAddressStateService
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
            public AddressStateService(DeNovaDbContext context)
            {
                _context = context;
            }
            #endregion

            #region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Создание места жительства персонажа по указанным данным
            /// </summary>
            /// <param name="addressInfoCreate">Параметры для создания места жительства персонажа</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Место жительства персонажа</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response<AddressStateDto>> CreateAsync(AddressStateCreateRequest addressInfoCreate, CancellationToken token)
            {
                AddressState entity = addressInfoCreate.Adapt<AddressState>();

				entity.AddressStateId = Guid.NewGuid();

				_context.AddressStates.Add(entity);
                await _context.SaveChangesAsync(token);

                AddressStateDto result = entity.Adapt<AddressStateDto>();

                return XResponse.Succeed(result);
            }

            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Обновление данных указанного места жительства персонажа
            /// </summary>
            /// <param name="addressInfoUpdate">Параметры обновляемой места жительства персонажа</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Место жительства персонажа</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response<AddressStateDto>> UpdateAsync(AddressStateDto addressInfoUpdate, CancellationToken token)
            {
                AddressState entity = addressInfoUpdate.Adapt<AddressState>();

                _context.AddressStates.Update(entity);
                await _context.SaveChangesAsync(token);

                AddressStateDto result = entity.Adapt<AddressStateDto>();

                return XResponse.Succeed(result);
            }

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение указанного места жительства персонажа
			/// </summary>
			/// <param name="addressInfoId">Идентификатор места жительства персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Место жительства персонажа</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response<AddressStateDto>> GetAsync(Guid addressInfoId, CancellationToken token)
			{
				AddressState? entity = await _context.AddressStates
					.FirstOrDefaultAsync(x => (x.AddressStateId == addressInfoId && x.GameSaveId == null), token);
				if (entity == null)
				{
					return XResponse.Failed<AddressStateDto>(XAddressStateErrors.NotFound);
				}

				AddressStateDto result = entity.Adapt<AddressStateDto>();

				return XResponse.Succeed(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка мест жительств персонажа 
			/// </summary>
			/// <param name="addressInfoRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Cписок мест жительств персонажа </returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<ResponsePage<AddressStateDto>> GetAllAsync(AddressStatesDto addressInfoRequest, CancellationToken token)
            {
                var query = _context.AddressStates.AsQueryable();

				query = query
					.Where(x => x.GameId == addressInfoRequest.GameId &&
								x.PersonId == addressInfoRequest.PersonId &&
								x.GameSaveId == null);

				query = query.Filter(addressInfoRequest.Filtering);

				var queryOrder = query.Sort(addressInfoRequest.Sorting, x => x.BeginPeriod);

				var result = await queryOrder.ToResponsePageAsync<AddressState, AddressStateDto>(addressInfoRequest, token);

                return result;
            }

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Удаление места жительства персонажа
			/// </summary>
			/// <param name="addressInfoId">Идентификатор места жительства персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Статус успешности</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response> DeleteAsync(Guid addressInfoId, CancellationToken token)
            {
                AddressState? entity = await _context.AddressStates
					.FirstOrDefaultAsync(x => (x.AddressStateId == addressInfoId && x.GameSaveId == null), token);
                if (entity == null)
                {
                    return XResponse.Failed(XAddressStateErrors.NotFound);
                }

                _context.AddressStates.Remove(entity!);
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