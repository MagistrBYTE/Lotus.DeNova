//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема параметров существ
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaParameterAspectTypeService.cs
*		Cервис для работы с аспектов параметров существами.
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
		/** \addtogroup DeNovaCreatureParameter
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Cервис для работы с аспектов параметров существами
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class ParameterAspectTypeService : ILotusParameterAspectTypeService
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
            public ParameterAspectTypeService(ILotusRepositoryDeNova repository)
            {
                _repository = repository;
            }
			#endregion

			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Создание аспекта параметра существа по указанным данным
			/// </summary>
			/// <param name="parameterAspectCreate">Данные для создания аспекта параметра существа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Аспект параметра существа</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response<ParameterAspectTypeDto>> CreateAsync(ParameterAspectTypeCreateRequest parameterAspectCreate, CancellationToken token)
            {
                ParameterAspectType entity = parameterAspectCreate.Adapt<ParameterAspectType>();

                _repository.Add(entity);
                await _repository.FlushAsync(token);

                ParameterAspectTypeDto result = entity.Adapt<ParameterAspectTypeDto>();

                return XResponse.Succeed(result);
            }

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Обновление данных указанного аспекта параметра существа
			/// </summary>
			/// <param name="parameterAspectUpdate">Данные обновляемого аспекта параметра существа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Аспект параметра существа</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response<ParameterAspectTypeDto>> UpdateAsync(ParameterAspectTypeDto parameterAspectUpdate, CancellationToken token)
            {
                ParameterAspectType entity = parameterAspectUpdate.Adapt<ParameterAspectType>();

                _repository.Update(entity);
                await _repository.FlushAsync(token);

                ParameterAspectTypeDto result = entity.Adapt<ParameterAspectTypeDto>();

                return XResponse.Succeed(result);
            }

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение указанного аспекта параметра существа
			/// </summary>
			/// <param name="id">Идентификатор аспекта параметра существа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Аспект параметра существа</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response<ParameterAspectTypeDto>> GetAsync(Int32 id, CancellationToken token)
			{
				ParameterAspectType? entity = await _repository.GetByIdAsync<ParameterAspectType, Int32>(id, token);
				if (entity == null)
				{
					return XResponse.Failed<ParameterAspectTypeDto>(XParameterAspectTypeErrors.NotFound);
				}

				ParameterAspectTypeDto result = entity.Adapt<ParameterAspectTypeDto>();

				return XResponse.Succeed(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка аспектов параметров существ
			/// </summary>
			/// <param name="parameterAspectRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Cписок аспектов параметров существ</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<ResponsePage<ParameterAspectTypeDto>> GetAllAsync(ParameterAspectTypesRequest parameterAspectRequest, CancellationToken token)
            {
                var query = _repository.Query<ParameterAspectType>();

				if (parameterAspectRequest.GameSettingTypeId.HasValue)
				{
					query = query.Where(x => x.GameSettingTypeId == parameterAspectRequest.GameSettingTypeId);
				}

				query = query.Filter(parameterAspectRequest.Filtering);

				var queryOrder = query.Sort(parameterAspectRequest.Sorting, x => x.Id);

				var result = await queryOrder.ToResponsePageAsync<ParameterAspectType, ParameterAspectTypeDto>(parameterAspectRequest, token);

                return result;
            }

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Удаление аспекта параметра существа
			/// </summary>
			/// <param name="id">Идентификатор аспекта параметра существа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Статус успешности</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response> DeleteAsync(Int32 id, CancellationToken token)
            {
                ParameterAspectType? entity = await _repository.GetByIdAsync<ParameterAspectType, Int32>(id, token);
                if (entity == null)
                {
                    return XResponse.Failed(XParameterAspectTypeErrors.NotFound);
                }

                if (entity.Id < 8)
                {
                    return XResponse.Failed(XParameterAspectTypeErrors.NotDeleteConst);
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