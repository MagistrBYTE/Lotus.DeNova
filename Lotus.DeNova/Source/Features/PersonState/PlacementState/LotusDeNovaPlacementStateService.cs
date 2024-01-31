//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема перемещения персонажа
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaPlacementStateService.cs
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
		/** \addtogroup DeNovaPlacementState
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Cервис для работы с местоположением персонажа
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class PlacementStateService : ILotusPlacementStateService
        {
            #region ======================================= ДАННЫЕ ====================================================
            private readonly ILotusRepositoryDeNova _repository;
            #endregion

            #region ======================================= КОНСТРУКТОРЫ ==============================================
            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Конструктор инициализирует объект класса указанными параметрами
            /// </summary>
            /// <param name="repository">Репозиторий игровой вселенной DeNova</param>
            //---------------------------------------------------------------------------------------------------------
            public PlacementStateService(ILotusRepositoryDeNova repository)
            {
                _repository = repository;
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
            public async Task<Response<PlacementStateDto>> CreateAsync(PlacementStateCreateRequest placementInfoCreate, CancellationToken token)
            {
                PlacementState entity = placementInfoCreate.Adapt<PlacementState>();
				
				entity.PlacementStateId = Guid.NewGuid();

				_repository.Add(entity);
                await _repository.FlushAsync(token);

                PlacementStateDto result = entity.Adapt<PlacementStateDto>();

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
            public async Task<Response<PlacementStateDto>> UpdateAsync(PlacementStateDto placementInfoUpdate, CancellationToken token)
            {
                PlacementState entity = placementInfoUpdate.Adapt<PlacementState>();

                _repository.Update(entity);
                await _repository.FlushAsync(token);

                PlacementStateDto result = entity.Adapt<PlacementStateDto>();

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
			public async Task<Response<PlacementStateDto>> GetAsync(Guid placementInfoId, CancellationToken token)
			{
				PlacementState? entity = await _repository.Query<PlacementState>()
					.FirstOrDefaultAsync(x => (x.PlacementStateId == placementInfoId && x.GameSaveId == null), token);
				if (entity == null)
				{
					return XResponse.Failed<PlacementStateDto>(XPlacementStateErrors.NotFound);
				}

				PlacementStateDto result = entity.Adapt<PlacementStateDto>();

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
			public async Task<ResponsePage<PlacementStateDto>> GetAllAsync(PlacementStatesDto placementInfoRequest, CancellationToken token)
            {
                var query = _repository.Query<PlacementState>();

				query = query
					.Where(x => x.GameId == placementInfoRequest.GameId &&
								x.PersonId == placementInfoRequest.PersonId &&
								x.GameSaveId == null);

				query = query.Filter(placementInfoRequest.Filtering);

				var queryOrder = query.Sort(placementInfoRequest.Sorting, x => x.Id);

				var result = await queryOrder.ToResponsePageAsync<PlacementState, PlacementStateDto>(placementInfoRequest, token);

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
                PlacementState? entity = await _repository.Query<PlacementState>()
					.FirstOrDefaultAsync(x => (x.PlacementStateId == placementInfoId && x.GameSaveId == null), token);
                if (entity == null)
                {
                    return XResponse.Failed(XPlacementStateErrors.NotFound);
                }

                _repository.Remove(entity!);
                await _repository.FlushAsync(token);

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