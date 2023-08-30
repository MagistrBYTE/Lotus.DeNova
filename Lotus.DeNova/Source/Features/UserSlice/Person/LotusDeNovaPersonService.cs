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
			private readonly ILotusImageService _imageService;
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="context">Контекст</param>
			/// <param name="imageService">Интерфейс сервиса для работы с изображениями</param>
			//---------------------------------------------------------------------------------------------------------
			public PersonService(DeNovaDbContext context, ILotusImageService imageService)
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
            public async Task<Response<PersonDto>> CreateAsync(PersonCreateDto personCreate, CancellationToken token)
            {
                Person entity = personCreate.Adapt<Person>();

				if(personCreate.AvatarId.HasValue && personCreate.IsLocalAvatar.GetValueOrDefault())
				{
					ImageDto imageDto = new ImageDto()
					{
						Id = personCreate.AvatarId.Value,
						IsLocal = true
					};
					await _imageService.AddAsync(imageDto, token);
				}

				_context.Persons.Add(entity);
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
					ImageDto imageDto = new ImageDto()
					{
						Id = personUpdate.AvatarId.Value,
						IsLocal = true
					};
					await _imageService.AddAsync(imageDto, token);
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
			public async Task<Response<PersonDto>> GetAsync(Int32 id, CancellationToken token)
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
			public async Task<ResponsePage<PersonDto>> GetAllAsync(PersonsDto personRequest, CancellationToken token)
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
            public async Task<Response> DeleteAsync(Int32 id, CancellationToken token)
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