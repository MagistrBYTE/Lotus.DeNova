//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема идентификации персонажа
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaIdentityInfoService.cs
*		Cервис для работы с идентификационными сведениями о персонаже.
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
		/** \addtogroup DeNovaIdentityInfo
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Cервис для работы с идентификационными сведениями о персонаже
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class IdentityInfoService : ILotusIdentityInfoService
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
            public IdentityInfoService(DeNovaDbContext context)
            {
                _context = context;
            }
            #endregion

            #region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Создание идентификационных сведений о персонаже по указанным данным
            /// </summary>
            /// <param name="identityInfoCreate">Параметры для создания идентификационных сведений о персонаже</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Идентификационные сведения о персонаже</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response<IdentityInfoDto>> CreateAsync(IdentityInfoCreateDto identityInfoCreate, CancellationToken token)
            {
                IdentityInfo entity = identityInfoCreate.Adapt<IdentityInfo>();

                _context.IdentityInfos.Add(entity);
                await _context.SaveChangesAsync(token);

                IdentityInfoDto result = entity.Adapt<IdentityInfoDto>();

                return XResponse.Succeed(result);
            }

            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Обновление данных указанного идентификационных сведений о персонаже
            /// </summary>
            /// <param name="identityInfoUpdate">Параметры обновляемой идентификационных сведений о персонаже</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Идентификационные сведения о персонаже</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response<IdentityInfoDto>> UpdateAsync(IdentityInfoDto identityInfoUpdate, CancellationToken token)
            {
                IdentityInfo entity = identityInfoUpdate.Adapt<IdentityInfo>();

                _context.IdentityInfos.Update(entity);
                await _context.SaveChangesAsync(token);

                IdentityInfoDto result = entity.Adapt<IdentityInfoDto>();

                return XResponse.Succeed(result);
            }

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение указанного идентификационных сведений о персонаже
			/// </summary>
			/// <param name="identityInfoId">Идентификатор идентификационных сведений о персонаже</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Идентификационные сведения о персонаже</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response<IdentityInfoDto>> GetAsync(Guid identityInfoId, CancellationToken token)
			{
				IdentityInfo? entity = await _context.IdentityInfos
					.FirstOrDefaultAsync(x => (x.IdentityInfoId == identityInfoId && x.GameSaveId == null), token);
				if (entity == null)
				{
					return XResponse.Failed<IdentityInfoDto>(XIdentityInfoErrors.NotFound);
				}

				IdentityInfoDto result = entity.Adapt<IdentityInfoDto>();

				return XResponse.Succeed(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка мест жительств персонажа 
			/// </summary>
			/// <param name="identityInfoRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Список аватаров персонажа </returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<ResponsePage<IdentityInfoDto>> GetAllAsync(IdentityInfosDto identityInfoRequest, CancellationToken token)
            {
                var query = _context.IdentityInfos.AsQueryable();

				query = query
					.Where(x => x.GameContextId == identityInfoRequest.GameContextId &&
								x.PersonId == identityInfoRequest.PersonId &&
								x.GameSaveId == null);

				query = query.Filter(identityInfoRequest.Filtering);

				var queryOrder = query.Sort(identityInfoRequest.Sorting, x => x.BeginPeriod);

				var result = await queryOrder.ToResponsePageAsync<IdentityInfo, IdentityInfoDto>(identityInfoRequest, token);

                return result;
            }

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Удаление идентификационных сведений о персонаже
			/// </summary>
			/// <param name="identityInfoId">Идентификатор идентификационных сведений о персонаже</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Статус успешности</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response> DeleteAsync(Guid identityInfoId, CancellationToken token)
            {
                IdentityInfo? entity = await _context.IdentityInfos
					.FirstOrDefaultAsync(x => (x.IdentityInfoId == identityInfoId && x.GameSaveId == null), token);
                if (entity == null)
                {
                    return XResponse.Failed(XIdentityInfoErrors.NotFound);
                }

                _context.IdentityInfos.Remove(entity!);
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