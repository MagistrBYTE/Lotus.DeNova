//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема персонажа
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaPersonService.cs
*		Cервис для работы с персонажами.
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
		/** \addtogroup DeNovaPerson
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Cервис для работы с персонажами
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class PersonService : ILotusPersonService
        {
            #region ======================================= ДАННЫЕ ====================================================
            private readonly ILotusRepositoryDeNova _repository;
			private readonly ILotusResourceFileService _imageService;
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="repository">Контекст</param>
			/// <param name="imageService">Интерфейс сервиса для работы с файлами</param>
			//---------------------------------------------------------------------------------------------------------
			public PersonService(ILotusRepositoryDeNova repository, ILotusResourceFileService imageService)
            {
                _repository = repository;
				_imageService = imageService;
            }
            #endregion

            #region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Создание персонажа по указанным данным
            /// </summary>
            /// <param name="personCreate">Параметры для создания персонажа</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Персонаж</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response<PersonDto>> CreateAsync(PersonCreateRequest personCreate, CancellationToken token)
            {
                Person entity = personCreate.Adapt<Person>();

				if(personCreate.AvatarId.HasValue && personCreate.IsLocalAvatar.GetValueOrDefault())
				{
					var imageDto = new FileCreateLocalRequest()
					{
						Id = personCreate.AvatarId.Value,
					};
					await _imageService.CreateAsync(imageDto, token);
				}

				_repository.Add(entity);

				_repository.Add(entity.PhysicalStrength);
				_repository.Add(entity.Dexterity);
				_repository.Add(entity.Endurance);
				_repository.Add(entity.Physique);

				_repository.Add(entity.Perception);
				_repository.Add(entity.Mind);
				_repository.Add(entity.Willpower);
				_repository.Add(entity.Spirituality);

				_repository.Add(entity.Appearance);
				_repository.Add(entity.Charisma);
				_repository.Add(entity.Influence);
				_repository.Add(entity.Status);

				await _repository.FlushAsync(token);

				entity.SetPersonId();

				_repository.Update(entity.PhysicalStrength);
				_repository.Update(entity.Dexterity);
				_repository.Update(entity.Endurance);
				_repository.Update(entity.Physique);

				_repository.Update(entity.Perception);
				_repository.Update(entity.Mind);
				_repository.Update(entity.Willpower);
				_repository.Update(entity.Spirituality);

				_repository.Update(entity.Appearance);
				_repository.Update(entity.Charisma);
				_repository.Update(entity.Influence);
				_repository.Update(entity.Status);

				await _repository.FlushAsync(token);

				PersonDto result = entity.Adapt<PersonDto>();

                return XResponse.Succeed(result);
            }

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Обновление данных указанного персонажа
			/// </summary>
			/// <param name="personUpdate">Параметры обновляемой персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Персонаж</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response<PersonDto>> UpdateAsync(PersonDto personUpdate, CancellationToken token)
            {
                Person entity = personUpdate.Adapt<Person>();

				if (personUpdate.AvatarId.HasValue && personUpdate.IsLocalAvatar.GetValueOrDefault())
				{
					var imageDto = new FileCreateLocalRequest()
					{
						Id = personUpdate.AvatarId.Value,

					};
					await _imageService.CreateAsync(imageDto, token);
				}

				_repository.Update(entity);
                await _repository.FlushAsync(token);

				PersonDto result = entity.Adapt<PersonDto>();

                return XResponse.Succeed(result);
            }

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение указанного персонажа
			/// </summary>
			/// <param name="id">Идентификатор персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Персонаж</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response<PersonDto>> GetAsync(Guid id, CancellationToken token)
			{
				Person? entity = await _repository.Query<Person>()
					.Include(x => x.Avatar)
					.FirstOrDefaultAsync(x => x.Id == id, token);
					
				if (entity == null)
				{
					return XResponse.Failed<PersonDto>(XPersonErrors.NotFound);
				}

				PersonDto result = entity.Adapt<PersonDto>();

				return XResponse.Succeed(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка персонажей
			/// </summary>
			/// <param name="personRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Cписок персонажей</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<ResponsePage<PersonDto>> GetAllAsync(PersonsRequest personRequest, CancellationToken token)
            {
                var query = _repository.Query<Person>();

                query = query
					.Include(x => x.Avatar)
					.Filter(personRequest.Filtering);

				var queryOrder = query.Sort(personRequest.Sorting, x => x.Id);

				var result = await queryOrder.ToResponsePageAsync<Person, PersonDto>(personRequest, token);

                return result;
            }

            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Удаление персонажа
            /// </summary>
            /// <param name="id">Идентификатор персонажа</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Статус успешности</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response> DeleteAsync(Guid id, CancellationToken token)
            {
                Person? entity = await _repository.GetByIdAsync<Person, Guid>(id, token);
                if (entity == null)
                {
                    return XResponse.Failed(XPersonErrors.NotFound);
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