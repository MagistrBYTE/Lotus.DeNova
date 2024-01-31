//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема данных астрологии
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaAstrologyTypeService.cs
*		Cервис для работы с данными по астрологии.
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
		/** \addtogroup DeNovaAstrologyType
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Cервис для работы с данными по астрологии
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class AstrologyTypeService : ILotusAstrologyTypeService
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
            public AstrologyTypeService(ILotusRepositoryDeNova repository)
            {
                _repository = repository;
            }
            #endregion

            #region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Создание данных по астрологии по указанным данным
            /// </summary>
            /// <param name="astrologyCreate">Параметры для создания данных по астрологии</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Данные по астрологии</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response<AstrologyTypeDto>> CreateAsync(AstrologyTypeCreateRequest astrologyCreate, CancellationToken token)
            {
                AstrologyType entity = astrologyCreate.Adapt<AstrologyType>();

                _repository.Add(entity);
                await _repository.FlushAsync(token);

                AstrologyTypeDto result = entity.Adapt<AstrologyTypeDto>();

                return XResponse.Succeed(result);
            }

            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Обновление данных указанных данных по астрологии
            /// </summary>
            /// <param name="astrologyUpdate">Параметры обновляемых данных по астрологии</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Данные по астрологии</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response<AstrologyTypeDto>> UpdateAsync(AstrologyTypeDto astrologyUpdate, CancellationToken token)
            {
                AstrologyType entity = astrologyUpdate.Adapt<AstrologyType>();

                _repository.Update(entity);
                await _repository.FlushAsync(token);

                AstrologyTypeDto result = entity.Adapt<AstrologyTypeDto>();

                return XResponse.Succeed(result);
            }

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение указанных данных по астрологии
			/// </summary>
			/// <param name="id">Идентификатор данных по астрологии</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Данные по астрологии</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response<AstrologyTypeDto>> GetAsync(Int32 id, CancellationToken token)
			{
				AstrologyType? entity = await _repository.GetByIdAsync<AstrologyType, Int32>(id, token);
				if (entity == null)
				{
					return XResponse.Failed<AstrologyTypeDto>(XAstrologyTypeErrors.NotFound);
				}

				AstrologyTypeDto result = entity.Adapt<AstrologyTypeDto>();

				return XResponse.Succeed(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка данных по астрологии
			/// </summary>
			/// <param name="astrologyRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Cписок данных по астрологии</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<ResponsePage<AstrologyTypeDto>> GetAllAsync(AstrologyTypesRequest astrologyRequest, CancellationToken token)
            {
                var query = _repository.Query<AstrologyType>();

				if(astrologyRequest.GameSettingTypeId.HasValue)
				{
					query = query.Where(x => x.GameSettingTypeId == astrologyRequest.GameSettingTypeId);
				}

                query = query.Filter(astrologyRequest.Filtering);

				var queryOrder = query.Sort(astrologyRequest.Sorting, x => x.Id);

				var result = await queryOrder.ToResponsePageAsync<AstrologyType, AstrologyTypeDto>(astrologyRequest, token);

                return result;
            }

            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Удаление данных по астрологии
            /// </summary>
            /// <param name="id">Идентификатор данных по астрологии</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Статус успешности</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response> DeleteAsync(Int32 id, CancellationToken token)
            {
                AstrologyType? entity = await _repository.GetByIdAsync<AstrologyType, Int32>(id, token);
                if (entity == null)
                {
                    return XResponse.Failed(XAstrologyTypeErrors.NotFound);
                }

                if (entity.Id < 4)
                {
                    return XResponse.Failed(XAstrologyTypeErrors.NotDeleteConst);
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