//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема сценария
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaScenarioTypeService.cs
*		Cервис для работы со сценариями.
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
		/** \addtogroup DeNovaScenarioType
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Cервис для работы со сценариями
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class ScenarioTypeService : ILotusScenarioTypeService
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
            public ScenarioTypeService(DeNovaDbContext context)
            {
                _context = context;
            }
            #endregion

            #region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Создание сценария по указанным данным
            /// </summary>
            /// <param name="scenarioCreate">Параметры для создания сценария</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Сценарий</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response<ScenarioTypeDto>> CreateAsync(ScenarioTypeCreateRequest scenarioCreate, CancellationToken token)
            {
                ScenarioType entity = scenarioCreate.Adapt<ScenarioType>();

                _context.ScenarioTypes.Add(entity);
                await _context.SaveChangesAsync(token);

                ScenarioTypeDto result = entity.Adapt<ScenarioTypeDto>();

                return XResponse.Succeed(result);
            }

            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Обновление данных указанной сценария
            /// </summary>
            /// <param name="scenarioUpdate">Параметры обновляемой сценария</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Сценарий</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response<ScenarioTypeDto>> UpdateAsync(ScenarioTypeDto scenarioUpdate, CancellationToken token)
            {
                ScenarioType entity = scenarioUpdate.Adapt<ScenarioType>();

                _context.ScenarioTypes.Update(entity);
                await _context.SaveChangesAsync(token);

                ScenarioTypeDto result = entity.Adapt<ScenarioTypeDto>();

                return XResponse.Succeed(result);
            }

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение указанной сценария
			/// </summary>
			/// <param name="id">Идентификатор сценария</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Сценарий</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response<ScenarioTypeDto>> GetAsync(Int32 id, CancellationToken token)
			{
				ScenarioType? entity = await _context.ScenarioTypes.FirstOrDefaultAsync(x => x.Id == id, token);
				if (entity == null)
				{
					return XResponse.Failed<ScenarioTypeDto>(XScenarioTypeErrors.NotFound);
				}

				ScenarioTypeDto result = entity.Adapt<ScenarioTypeDto>();

				return XResponse.Succeed(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка сценариев
			/// </summary>
			/// <param name="scenarioRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Cписок рас</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<ResponsePage<ScenarioTypeDto>> GetAllAsync(ScenarioTypesRequest scenarioRequest, CancellationToken token)
            {
                var query = _context.ScenarioTypes.AsQueryable();

				if (scenarioRequest.GameSettingTypeId.HasValue)
				{
					query = query.Where(x => x.GameSettingTypeId == scenarioRequest.GameSettingTypeId);
				}

				query = query.Filter(scenarioRequest.Filtering);

				var queryOrder = query.Sort(scenarioRequest.Sorting, x => x.Id);

				var result = await queryOrder.ToResponsePageAsync<ScenarioType, ScenarioTypeDto>(scenarioRequest, token);

                return result;
            }

            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Удаление сценария
            /// </summary>
            /// <param name="id">Идентификатор сценария</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Статус успешности</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response> DeleteAsync(Int32 id, CancellationToken token)
            {
                ScenarioType? entity = await _context.ScenarioTypes.FirstOrDefaultAsync(x => x.Id == id, token);
                if (entity == null)
                {
                    return XResponse.Failed(XScenarioTypeErrors.NotFound);
                }

                if (entity.Id < 8)
                {
                    return XResponse.Failed(XScenarioTypeErrors.NotDeleteConst);
                }

                _context.ScenarioTypes.Remove(entity!);
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