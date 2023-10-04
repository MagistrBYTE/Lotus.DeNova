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
            private readonly DeNovaDbContext _context;
			private readonly ILotusResourceFileService _imageService;
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="context">Контекст</param>
			/// <param name="imageService">Интерфейс сервиса для работы с файлами</param>
			//---------------------------------------------------------------------------------------------------------
			public PersonService(DeNovaDbContext context, ILotusResourceFileService imageService)
            {
                _context = context;
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

				_context.Persons.Add(entity);

				_context.PersonParameters.Add(entity.PhysicalStrength);
				_context.PersonParameters.Add(entity.Dexterity);
				_context.PersonParameters.Add(entity.Endurance);
				_context.PersonParameters.Add(entity.Physique);

				_context.PersonParameters.Add(entity.Perception);
				_context.PersonParameters.Add(entity.Mind);
				_context.PersonParameters.Add(entity.Willpower);
				_context.PersonParameters.Add(entity.Spirituality);

				_context.PersonParameters.Add(entity.Appearance);
				_context.PersonParameters.Add(entity.Charisma);
				_context.PersonParameters.Add(entity.Influence);
				_context.PersonParameters.Add(entity.Status);

				await _context.SaveChangesAsync(token);

				entity.SetPersonId();

				_context.PersonParameters.Update(entity.PhysicalStrength);
				_context.PersonParameters.Update(entity.Dexterity);
				_context.PersonParameters.Update(entity.Endurance);
				_context.PersonParameters.Update(entity.Physique);

				_context.PersonParameters.Update(entity.Perception);
				_context.PersonParameters.Update(entity.Mind);
				_context.PersonParameters.Update(entity.Willpower);
				_context.PersonParameters.Update(entity.Spirituality);

				_context.PersonParameters.Update(entity.Appearance);
				_context.PersonParameters.Update(entity.Charisma);
				_context.PersonParameters.Update(entity.Influence);
				_context.PersonParameters.Update(entity.Status);

				await _context.SaveChangesAsync(token);

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

				_context.Persons.Update(entity);
                await _context.SaveChangesAsync(token);

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
				Person? entity = await _context.Persons
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
                var query = _context.Persons.AsQueryable();

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
                Person? entity = await _context.Persons.FirstOrDefaultAsync(x => x.Id == id, token);
                if (entity == null)
                {
                    return XResponse.Failed(XPersonErrors.NotFound);
                }

                _context.Persons.Remove(entity!);
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