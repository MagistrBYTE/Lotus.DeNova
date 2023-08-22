//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема аватара персонажа
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaAvatarInfoService.cs
*		Cервис для работы с аватаром персонажа.
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
		/** \addtogroup DeNovaAvatarInfo
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Cервис для работы с аватаром персонажа
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class AvatarInfoService : ILotusAvatarInfoService
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
            public AvatarInfoService(DeNovaDbContext context)
            {
                _context = context;
            }
            #endregion

            #region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Создание аватара персонажа по указанным данным
            /// </summary>
            /// <param name="avatarInfoCreate">Параметры для создания аватара персонажа</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Аватар персонажа</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response<AvatarInfoDto>> CreateAsync(AvatarInfoCreateDto avatarInfoCreate, CancellationToken token)
            {
                AvatarInfo entity = avatarInfoCreate.Adapt<AvatarInfo>();

                _context.AvatarInfos.Add(entity);
                await _context.SaveChangesAsync(token);

                AvatarInfoDto result = entity.Adapt<AvatarInfoDto>();

                return XResponse.Succeed(result);
            }

            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Обновление данных указанного аватара персонажа
            /// </summary>
            /// <param name="avatarInfoUpdate">Параметры обновляемой аватара персонажа</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Аватар персонажа</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response<AvatarInfoDto>> UpdateAsync(AvatarInfoDto avatarInfoUpdate, CancellationToken token)
            {
                AvatarInfo entity = avatarInfoUpdate.Adapt<AvatarInfo>();

                _context.AvatarInfos.Update(entity);
                await _context.SaveChangesAsync(token);

                AvatarInfoDto result = entity.Adapt<AvatarInfoDto>();

                return XResponse.Succeed(result);
            }

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение указанного аватара персонажа
			/// </summary>
			/// <param name="avatarInfoId">Идентификатор аватара персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Аватар персонажа</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response<AvatarInfoDto>> GetAsync(Guid avatarInfoId, CancellationToken token)
			{
				AvatarInfo? entity = await _context.AvatarInfos
					.FirstOrDefaultAsync(x => (x.AvatarInfoId == avatarInfoId && x.GameSaveId == null), token);
				if (entity == null)
				{
					return XResponse.Failed<AvatarInfoDto>(XAvatarInfoErrors.NotFound);
				}

				AvatarInfoDto result = entity.Adapt<AvatarInfoDto>();

				return XResponse.Succeed(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка мест жительств персонажа 
			/// </summary>
			/// <param name="avatarInfoRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Список аватаров персонажа </returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<ResponsePage<AvatarInfoDto>> GetAllAsync(AvatarInfosDto avatarInfoRequest, CancellationToken token)
            {
                var query = _context.AvatarInfos.AsQueryable();

				query = query
					.Where(x => x.GameContextId == avatarInfoRequest.GameContextId &&
								x.PersonId == avatarInfoRequest.PersonId &&
								x.GameSaveId == null);

				query = query.Filter(avatarInfoRequest.Filtering);

				var queryOrder = query.Sort(avatarInfoRequest.Sorting, x => x.BeginPeriod);

				var result = await queryOrder.ToResponsePageAsync<AvatarInfo, AvatarInfoDto>(avatarInfoRequest, token);

                return result;
            }

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Удаление аватара персонажа
			/// </summary>
			/// <param name="avatarInfoId">Идентификатор аватара персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Статус успешности</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response> DeleteAsync(Guid avatarInfoId, CancellationToken token)
            {
                AvatarInfo? entity = await _context.AvatarInfos
					.FirstOrDefaultAsync(x => (x.AvatarInfoId == avatarInfoId && x.GameSaveId == null), token);
                if (entity == null)
                {
                    return XResponse.Failed(XAvatarInfoErrors.NotFound);
                }

                _context.AvatarInfos.Remove(entity!);
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