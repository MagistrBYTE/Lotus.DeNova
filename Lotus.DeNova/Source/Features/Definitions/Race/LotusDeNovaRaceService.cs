//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема рас
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaRaceService.cs
*		Cервис для работы с расами.
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
		/** \addtogroup DeNovaRace
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Cервис для работы с расами
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class RaceService : ILotusRaceService
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
            public RaceService(DeNovaDbContext context)
            {
                _context = context;
            }
            #endregion

            #region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Создание расы по указанным данным
            /// </summary>
            /// <param name="raceCreate">Параметры для создания расы</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Раса</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response<RaceDto>> CreateAsync(RaceCreateDto raceCreate, CancellationToken token)
            {
                Race entity = raceCreate.Adapt<Race>();

                _context.Races.Add(entity);
                await _context.SaveChangesAsync(token);

                RaceDto result = entity.Adapt<RaceDto>();

                return XResponse.Succeed(result);
            }

            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Обновление данных указанной расы
            /// </summary>
            /// <param name="raceUpdate">Параметры обновляемой расы</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Раса</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response<RaceDto>> UpdateAsync(RaceDto raceUpdate, CancellationToken token)
            {
                Race entity = raceUpdate.Adapt<Race>();

                _context.Races.Update(entity);
                await _context.SaveChangesAsync(token);

                RaceDto result = entity.Adapt<RaceDto>();

                return XResponse.Succeed(result);
            }

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение указанной расы
			/// </summary>
			/// <param name="id">Идентификатор расы</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Раса</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response<RaceDto>> GetAsync(Int32 id, CancellationToken token)
			{
				Race? entity = await _context.Races.FirstOrDefaultAsync(x => x.Id == id, token);
				if (entity == null)
				{
					return XResponse.Failed<RaceDto>(XRaceErrors.NotFound);
				}

				RaceDto result = entity.Adapt<RaceDto>();

				return XResponse.Succeed(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка рас
			/// </summary>
			/// <param name="raceRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Cписок рас</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<ResponsePage<RaceDto>> GetAllAsync(RacesDto raceRequest, CancellationToken token)
            {
                var query = _context.Races.AsQueryable();

				if (raceRequest.CampaignSettingId.HasValue)
				{
					query = query.Where(x => x.CampaignSettingId == raceRequest.CampaignSettingId);
				}

				query = query.Filter(raceRequest.Filtering);

				var queryOrder = query.Sort(raceRequest.Sorting, x => x.Id);

				var result = await queryOrder.ToResponsePageAsync<Race, RaceDto>(raceRequest, token);

                return result;
            }

            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Удаление расы
            /// </summary>
            /// <param name="id">Идентификатор расы</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Статус успешности</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response> DeleteAsync(Int32 id, CancellationToken token)
            {
                Race? entity = await _context.Races.FirstOrDefaultAsync(x => x.Id == id, token);
                if (entity == null)
                {
                    return XResponse.Failed(XRaceErrors.NotFound);
                }

                if (entity.Id < 8)
                {
                    return XResponse.Failed(XRaceErrors.NotDeleteConst);
                }

                _context.Races.Remove(entity!);
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