//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема параметров персонажа
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaPersonParameterService.cs
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
		/** \addtogroup DeNovaPersonParameter
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Cервис для работы с параметрами персонажа
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class PersonParameterService : ILotusPersonParameterService
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
            public PersonParameterService(DeNovaDbContext context)
            {
                _context = context;
            }
            #endregion

            #region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Создание параметра персонажа по указанным данным
            /// </summary>
            /// <param name="personParameterCreate">Данные для создания параметра персонажа</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Параметр персонажа</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response<PersonParameterDto>> CreateAsync(PersonParameterCreateRequest personParameterCreate, CancellationToken token)
            {
                PersonParameter entity = personParameterCreate.Adapt<PersonParameter>();

                _context.PersonParameters.Add(entity);
                await _context.SaveChangesAsync(token);

                PersonParameterDto result = entity.Adapt<PersonParameterDto>();

                return XResponse.Succeed(result);
            }

            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Обновление данных указанного параметра персонажа
            /// </summary>
            /// <param name="personParameterUpdate">Данные обновляемого параметра персонажа</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Параметр персонажа</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response<PersonParameterDto>> UpdateAsync(PersonParameterDto personParameterUpdate, CancellationToken token)
            {
                PersonParameter entity = personParameterUpdate.Adapt<PersonParameter>();

                _context.PersonParameters.Update(entity);
                await _context.SaveChangesAsync(token);

                PersonParameterDto result = entity.Adapt<PersonParameterDto>();

                return XResponse.Succeed(result);
            }

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение указанного параметра персонажа
			/// </summary>
			/// <param name="id">Идентификатор параметра персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Параметр персонажа</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response<PersonParameterDto>> GetAsync(Guid id, CancellationToken token)
			{
				PersonParameter? entity = await _context.PersonParameters.FirstOrDefaultAsync(x => x.Id == id, token);
				if (entity == null)
				{
					return XResponse.Failed<PersonParameterDto>(XPersonParameterErrors.NotFound);
				}

				PersonParameterDto result = entity.Adapt<PersonParameterDto>();

				return XResponse.Succeed(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка параметров персонажа
			/// </summary>
			/// <param name="personParameterRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Cписок параметров персонажа</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<ResponsePage<PersonParameterDto>> GetAllAsync(PersonParametersRequest personParameterRequest, CancellationToken token)
            {
                var query = _context.PersonParameters.AsQueryable();

				if (personParameterRequest.PersonId.HasValue)
				{
					query = query.Where(x => x.PersonId == personParameterRequest.PersonId);
				}

				query = query.Filter(personParameterRequest.Filtering);

				var queryOrder = query.Sort(personParameterRequest.Sorting, x => x.Id);

				var result = await queryOrder.ToResponsePageAsync<PersonParameter, PersonParameterDto>(personParameterRequest, token);

                return result;
            }

            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Удаление параметра персонажа
            /// </summary>
            /// <param name="id">Идентификатор параметра персонажа</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Статус успешности</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response> DeleteAsync(Guid id, CancellationToken token)
            {
                PersonParameter? entity = await _context.PersonParameters.FirstOrDefaultAsync(x => x.Id == id, token);
                if (entity == null)
                {
                    return XResponse.Failed(XPersonParameterErrors.NotFound);
                }

                _context.PersonParameters.Remove(entity!);
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