//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема параметров существ
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaParameterTypeService.cs
*		Cервис для работы с параметрами персонажа.
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
		/// Cервис для работы с параметрами персонажа
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class ParameterTypeService : ILotusParameterTypeService
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
            public ParameterTypeService(DeNovaDbContext context)
            {
                _context = context;
            }
			#endregion

			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Создание параметра существа по указанным данным
			/// </summary>
			/// <param name="personParamsCreate">Данные для создания параметра существа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Параметр существа</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response<ParameterTypeDto>> CreateAsync(ParameterTypeCreateRequest personParamsCreate, CancellationToken token)
            {
                ParameterType entity = personParamsCreate.Adapt<ParameterType>();

                _context.ParameterTypes.Add(entity);
                await _context.SaveChangesAsync(token);

                ParameterTypeDto result = entity.Adapt<ParameterTypeDto>();

                return XResponse.Succeed(result);
            }

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Обновление данных указанного параметра существа
			/// </summary>
			/// <param name="personParamsUpdate">Данные обновляемого параметра</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Параметр существа</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response<ParameterTypeDto>> UpdateAsync(ParameterTypeDto personParamsUpdate, CancellationToken token)
            {
                ParameterType entity = personParamsUpdate.Adapt<ParameterType>();

                _context.ParameterTypes.Update(entity);
                await _context.SaveChangesAsync(token);

                ParameterTypeDto result = entity.Adapt<ParameterTypeDto>();

                return XResponse.Succeed(result);
            }

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение указанного параметра существа
			/// </summary>
			/// <param name="id">Идентификатор параметра</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Параметр существа</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response<ParameterTypeDto>> GetAsync(Int32 id, CancellationToken token)
			{
				ParameterType? entity = await _context.ParameterTypes.FirstOrDefaultAsync(x => x.Id == id, token);
				if (entity == null)
				{
					return XResponse.Failed<ParameterTypeDto>(XParameterTypeErrors.NotFound);
				}

				ParameterTypeDto result = entity.Adapt<ParameterTypeDto>();

				return XResponse.Succeed(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка параметров существ
			/// </summary>
			/// <param name="personParamsRequest">Запрос для получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Cписок параметров существ</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<ResponsePage<ParameterTypeDto>> GetAllAsync(ParameterTypesRequest personParamsRequest, CancellationToken token)
            {
                var query = _context.ParameterTypes.AsQueryable();

				if (personParamsRequest.GameSettingTypeId.HasValue)
				{
					query = query.Where(x => x.GameSettingTypeId == personParamsRequest.GameSettingTypeId);
				}

				query = query.Filter(personParamsRequest.Filtering);

				var queryOrder = query.Sort(personParamsRequest.Sorting, x => x.Id);

				var result = await queryOrder.ToResponsePageAsync<ParameterType, ParameterTypeDto>(personParamsRequest, token);

                return result;
            }

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Удаление параметра существа
			/// </summary>
			/// <param name="id">Идентификатор параметра</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Статус успешности</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response> DeleteAsync(Int32 id, CancellationToken token)
            {
                ParameterType? entity = await _context.ParameterTypes.FirstOrDefaultAsync(x => x.Id == id, token);
                if (entity == null)
                {
                    return XResponse.Failed(XParameterTypeErrors.NotFound);
                }

                if (entity.Id < 12)
                {
                    return XResponse.Failed(XParameterTypeErrors.NotDeleteConst);
                }

                _context.ParameterTypes.Remove(entity!);
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