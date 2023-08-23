//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема перемещения персонажа
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaPlacementInfoService.cs
*		Cервис для работы с местоположением персонажа.
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
		/** \addtogroup DeNovaPlacementInfo
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Cервис для работы с местоположением персонажа
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class PlacementInfoService : ILotusPlacementInfoService
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
            public PlacementInfoService(DeNovaDbContext context)
            {
                _context = context;
            }
            #endregion

            #region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Создание местоположения персонажа по указанным данным
            /// </summary>
            /// <param name="placementInfoCreate">Параметры для создания местоположения персонажа</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Местоположение персонажа</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response<PlacementInfoDto>> CreateAsync(PlacementInfoCreateDto placementInfoCreate, CancellationToken token)
            {
                PlacementInfo entity = placementInfoCreate.Adapt<PlacementInfo>();
				
				entity.PlacementInfoId = Guid.NewGuid();

				_context.PlacementInfos.Add(entity);
                await _context.SaveChangesAsync(token);

                PlacementInfoDto result = entity.Adapt<PlacementInfoDto>();

                return XResponse.Succeed(result);
            }

            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Обновление данных указанного местоположения персонажа
            /// </summary>
            /// <param name="placementInfoUpdate">Параметры обновляемого местоположения персонажа</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Местоположение персонажа</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response<PlacementInfoDto>> UpdateAsync(PlacementInfoDto placementInfoUpdate, CancellationToken token)
            {
                PlacementInfo entity = placementInfoUpdate.Adapt<PlacementInfo>();

                _context.PlacementInfos.Update(entity);
                await _context.SaveChangesAsync(token);

                PlacementInfoDto result = entity.Adapt<PlacementInfoDto>();

                return XResponse.Succeed(result);
            }

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение указанного местоположения персонажа
			/// </summary>
			/// <param name="placementInfoId">Идентификатор местоположения персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Местоположение персонажа</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response<PlacementInfoDto>> GetAsync(Guid placementInfoId, CancellationToken token)
			{
				PlacementInfo? entity = await _context.PlacementInfos
					.FirstOrDefaultAsync(x => (x.PlacementInfoId == placementInfoId && x.GameSaveId == null), token);
				if (entity == null)
				{
					return XResponse.Failed<PlacementInfoDto>(XPlacementInfoErrors.NotFound);
				}

				PlacementInfoDto result = entity.Adapt<PlacementInfoDto>();

				return XResponse.Succeed(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка местоположений персонажа 
			/// </summary>
			/// <param name="placementInfoRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Список местоположений персонажа</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<ResponsePage<PlacementInfoDto>> GetAllAsync(PlacementInfosDto placementInfoRequest, CancellationToken token)
            {
                var query = _context.PlacementInfos.AsQueryable();

				query = query
					.Where(x => x.GameContextId == placementInfoRequest.GameContextId &&
								x.PersonId == placementInfoRequest.PersonId &&
								x.GameSaveId == null);

				query = query.Filter(placementInfoRequest.Filtering);

				var queryOrder = query.Sort(placementInfoRequest.Sorting, x => x.Id);

				var result = await queryOrder.ToResponsePageAsync<PlacementInfo, PlacementInfoDto>(placementInfoRequest, token);

                return result;
            }

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Удаление местоположения персонажа
			/// </summary>
			/// <param name="placementInfoId">Идентификатор местоположения персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Статус успешности</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response> DeleteAsync(Guid placementInfoId, CancellationToken token)
            {
                PlacementInfo? entity = await _context.PlacementInfos
					.FirstOrDefaultAsync(x => (x.PlacementInfoId == placementInfoId && x.GameSaveId == null), token);
                if (entity == null)
                {
                    return XResponse.Failed(XPlacementInfoErrors.NotFound);
                }

                _context.PlacementInfos.Remove(entity!);
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