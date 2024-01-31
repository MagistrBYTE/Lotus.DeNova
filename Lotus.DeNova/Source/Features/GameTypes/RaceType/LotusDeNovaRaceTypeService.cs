//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема рас
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaRaceTypeService.cs
*		Cервис для работы с расами.
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
		/** \addtogroup DeNovaRaceType
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Cервис для работы с расами
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class RaceTypeService : ILotusRaceTypeService
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
            public RaceTypeService(ILotusRepositoryDeNova repository)
            {
                _repository = repository;
            }
            #endregion

            #region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Создание расы по указанным данным
            /// </summary>
            /// <param name="raceCreate">Параметры для создания расы</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Раса</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response<RaceTypeDto>> CreateAsync(RaceTypeCreateRequest raceCreate, CancellationToken token)
            {
                RaceType entity = raceCreate.Adapt<RaceType>();

                _repository.Add(entity);
                await _repository.FlushAsync(token);

                RaceTypeDto result = entity.Adapt<RaceTypeDto>();

                return XResponse.Succeed(result);
            }

            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Обновление данных указанной расы
            /// </summary>
            /// <param name="raceUpdate">Параметры обновляемой расы</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Раса</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response<RaceTypeDto>> UpdateAsync(RaceTypeDto raceUpdate, CancellationToken token)
            {
                RaceType entity = raceUpdate.Adapt<RaceType>();

                _repository.Update(entity);
                await _repository.FlushAsync(token);

                RaceTypeDto result = entity.Adapt<RaceTypeDto>();

                return XResponse.Succeed(result);
            }

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение указанной расы
			/// </summary>
			/// <param name="id">Идентификатор расы</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Раса</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response<RaceTypeDto>> GetAsync(Int32 id, CancellationToken token)
			{
				RaceType? entity = await _repository.GetByIdAsync<RaceType, Int32>(id, token);
				if (entity == null)
				{
					return XResponse.Failed<RaceTypeDto>(XRaceTypeErrors.NotFound);
				}

				RaceTypeDto result = entity.Adapt<RaceTypeDto>();

				return XResponse.Succeed(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка рас
			/// </summary>
			/// <param name="raceRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Cписок рас</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<ResponsePage<RaceTypeDto>> GetAllAsync(RaceTypesRequest raceRequest, CancellationToken token)
            {
                var query = _repository.Query<RaceType>();

				if (raceRequest.GameSettingTypeId.HasValue)
				{
					query = query.Where(x => x.GameSettingTypeId == raceRequest.GameSettingTypeId);
				}

				query = query.Filter(raceRequest.Filtering);

				var queryOrder = query.Sort(raceRequest.Sorting, x => x.Id);

				var result = await queryOrder.ToResponsePageAsync<RaceType, RaceTypeDto>(raceRequest, token);

                return result;
            }

            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Удаление расы
            /// </summary>
            /// <param name="id">Идентификатор расы</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Статус успешности</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response> DeleteAsync(Int32 id, CancellationToken token)
            {
                RaceType? entity = await _repository.GetByIdAsync<RaceType, Int32>(id, token);
                if (entity == null)
                {
                    return XResponse.Failed(XRaceTypeErrors.NotFound);
                }

                if (entity.Id < 8)
                {
                    return XResponse.Failed(XRaceTypeErrors.NotDeleteConst);
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