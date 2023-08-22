//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема место жительства
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaAddressInfoService.cs
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
		/** \addtogroup DeNovaAddressInfo
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Cервис для работы с местом жительства персонажа
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class AddressInfoService : ILotusAddressInfoService
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
            public AddressInfoService(DeNovaDbContext context)
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
            public async Task<Response<AddressInfoDto>> CreateAsync(AddressInfoCreateDto addressInfoCreate, CancellationToken token)
            {
                AddressInfo entity = addressInfoCreate.Adapt<AddressInfo>();

                _context.AddressInfos.Add(entity);
                await _context.SaveChangesAsync(token);

                AddressInfoDto result = entity.Adapt<AddressInfoDto>();

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
            public async Task<Response<AddressInfoDto>> UpdateAsync(AddressInfoDto addressInfoUpdate, CancellationToken token)
            {
                AddressInfo entity = addressInfoUpdate.Adapt<AddressInfo>();

                _context.AddressInfos.Update(entity);
                await _context.SaveChangesAsync(token);

                AddressInfoDto result = entity.Adapt<AddressInfoDto>();

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
			public async Task<Response<AddressInfoDto>> GetAsync(Guid addressInfoId, CancellationToken token)
			{
				AddressInfo? entity = await _context.AddressInfos
					.FirstOrDefaultAsync(x => (x.AddressInfoId == addressInfoId && x.GameSaveId == null), token);
				if (entity == null)
				{
					return XResponse.Failed<AddressInfoDto>(XAddressInfoErrors.NotFound);
				}

				AddressInfoDto result = entity.Adapt<AddressInfoDto>();

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
			public async Task<ResponsePage<AddressInfoDto>> GetAllAsync(AddressInfosDto addressInfoRequest, CancellationToken token)
            {
                var query = _context.AddressInfos.AsQueryable();

				query = query
					.Where(x => x.GameContextId == addressInfoRequest.GameContextId &&
								x.PersonId == addressInfoRequest.PersonId &&
								x.GameSaveId == null);

				query = query.Filter(addressInfoRequest.Filtering);

				var queryOrder = query.Sort(addressInfoRequest.Sorting, x => x.BeginPeriod);

				var result = await queryOrder.ToResponsePageAsync<AddressInfo, AddressInfoDto>(addressInfoRequest, token);

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
                AddressInfo? entity = await _context.AddressInfos
					.FirstOrDefaultAsync(x => (x.AddressInfoId == addressInfoId && x.GameSaveId == null), token);
                if (entity == null)
                {
                    return XResponse.Failed(XAddressInfoErrors.NotFound);
                }

                _context.AddressInfos.Remove(entity!);
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