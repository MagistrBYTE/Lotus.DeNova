//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема параметра персонажа
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaPersonParameterAspectService.cs
*		Cервис для работы с аспектами параметров персонажа.
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
		/// Cервис для работы с аспектами параметров персонажа
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class PersonParameterAspectService : ILotusPersonParameterAspectService
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
            public PersonParameterAspectService(ILotusRepositoryDeNova repository)
            {
                _repository = repository;
            }
            #endregion

            #region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Создание аспекта параметра персонажа по указанным данным
            /// </summary>
            /// <param name="personParameterAspectCreate">Данные для создания аспекта параметра персонажа</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Аспект параметра персонажа</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response<PersonParameterAspectDto>> CreateAsync(PersonParameterAspectCreateRequest personParameterAspectCreate, 
				CancellationToken token)
            {
                PersonParameterAspect entity = personParameterAspectCreate.Adapt<PersonParameterAspect>();

                _repository.Add(entity);
                await _repository.FlushAsync(token);

                PersonParameterAspectDto result = entity.Adapt<PersonParameterAspectDto>();

                return XResponse.Succeed(result);
            }

            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Обновление данных указанного аспекта параметра персонажа
            /// </summary>
            /// <param name="personParameterAspectUpdate">Данные обновляемого аспекта параметра персонажа</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Аспект параметра персонажа</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response<PersonParameterAspectDto>> UpdateAsync(PersonParameterAspectDto personParameterAspectUpdate,
				CancellationToken token)
            {
                PersonParameterAspect entity = personParameterAspectUpdate.Adapt<PersonParameterAspect>();

                _repository.Update(entity);
                await _repository.FlushAsync(token);

                PersonParameterAspectDto result = entity.Adapt<PersonParameterAspectDto>();

                return XResponse.Succeed(result);
            }

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение указанного аспекта параметра персонажа
			/// </summary>
			/// <param name="id">Идентификатор аспекта параметра</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Аспект параметра персонажа</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response<PersonParameterAspectDto>> GetAsync(Guid id, CancellationToken token)
			{
				PersonParameterAspect? entity = await _repository.GetByIdAsync<PersonParameterAspect, Guid>(id, token);
				if (entity == null)
				{
					return XResponse.Failed<PersonParameterAspectDto>(XPersonParameterAspectErrors.NotFound);
				}

				PersonParameterAspectDto result = entity.Adapt<PersonParameterAspectDto>();

				return XResponse.Succeed(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка аспектов параметров персонажа
			/// </summary>
			/// <param name="personParameterAspectRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Cписок аспектов параметров персонажа</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<ResponsePage<PersonParameterAspectDto>> GetAllAsync(PersonParameterAspectsRequest personParameterAspectRequest,
				CancellationToken token)
            {
                var query = _repository.Query<PersonParameterAspect>();

				if (personParameterAspectRequest.PersonId.HasValue)
				{
					query = query.Where(x => x.PersonId == personParameterAspectRequest.PersonId);
				}

				query = query.Filter(personParameterAspectRequest.Filtering);

				var queryOrder = query.Sort(personParameterAspectRequest.Sorting, x => x.Id);

				var result = await queryOrder.ToResponsePageAsync<PersonParameterAspect, PersonParameterAspectDto>(personParameterAspectRequest, token);

                return result;
            }

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Удаление аспекта параметра персонажа
			/// </summary>
			/// <param name="id">Идентификатор аспекта параметра персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Статус успешности</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response> DeleteAsync(Guid id, CancellationToken token)
            {
                PersonParameterAspect? entity = await _repository.GetByIdAsync<PersonParameterAspect, Guid>(id, token);
                if (entity == null)
                {
                    return XResponse.Failed(XPersonParameterAspectErrors.NotFound);
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