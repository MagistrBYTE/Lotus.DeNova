//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема астрологических данных
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaAstrologyService.cs
*		Cервис для работы с астрологическими данными.
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
		/** \addtogroup DeNovaAstrology
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Cервис для работы с астрологическими данными
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class AstrologyService : ILotusAstrologyService
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
            public AstrologyService(DeNovaDbContext context)
            {
                _context = context;
            }
            #endregion

            #region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Создание астрологических данных по указанным данным
            /// </summary>
            /// <param name="astrologyCreate">Параметры для создания астрологических данных</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Астрологические данные</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response<AstrologyDto>> CreateAsync(AstrologyCreateDto astrologyCreate, CancellationToken token)
            {
                Astrology entity = astrologyCreate.Adapt<Astrology>();

                _context.Astrologies.Add(entity);
                await _context.SaveChangesAsync(token);

                AstrologyDto result = entity.Adapt<AstrologyDto>();

                return XResponse.Succeed(result);
            }

            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Обновление данных указанных астрологических данных
            /// </summary>
            /// <param name="astrologyUpdate">Параметры обновляемой астрологических данных</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Астрологические данные</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response<AstrologyDto>> UpdateAsync(AstrologyDto astrologyUpdate, CancellationToken token)
            {
                Astrology entity = astrologyUpdate.Adapt<Astrology>();

                _context.Astrologies.Update(entity);
                await _context.SaveChangesAsync(token);

                AstrologyDto result = entity.Adapt<AstrologyDto>();

                return XResponse.Succeed(result);
            }

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение указанных астрологических данных
			/// </summary>
			/// <param name="id">Идентификатор астрологических данных</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Астрологические данные</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response<AstrologyDto>> GetAsync(Int32 id, CancellationToken token)
			{
				Astrology? entity = await _context.Astrologies.FirstOrDefaultAsync(x => x.Id == id, token);
				if (entity == null)
				{
					return XResponse.Failed<AstrologyDto>(XAstrologyErrors.NotFound);
				}

				AstrologyDto result = entity.Adapt<AstrologyDto>();

				return XResponse.Succeed(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка астрологических данных
			/// </summary>
			/// <param name="astrologyRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Cписок астрологических данных</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<ResponsePage<AstrologyDto>> GetAllAsync(AstrologiesDto astrologyRequest, CancellationToken token)
            {
                var query = _context.Astrologies.AsQueryable();

				if(astrologyRequest.CampaignSettingId.HasValue)
				{
					query = query.Where(x => x.CampaignSettingId == astrologyRequest.CampaignSettingId);
				}

                query = query.Filter(astrologyRequest.Filtering);

				var queryOrder = query.Sort(astrologyRequest.Sorting, x => x.Id);

				var result = await queryOrder.ToResponsePageAsync<Astrology, AstrologyDto>(astrologyRequest, token);

                return result;
            }

            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Удаление астрологических данных
            /// </summary>
            /// <param name="id">Идентификатор астрологических данных</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Статус успешности</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response> DeleteAsync(Int32 id, CancellationToken token)
            {
                Astrology? entity = await _context.Astrologies.FirstOrDefaultAsync(x => x.Id == id, token);
                if (entity == null)
                {
                    return XResponse.Failed(XAstrologyErrors.NotFound);
                }

                if (entity.Id < 4)
                {
                    return XResponse.Failed(XAstrologyErrors.NotDeleteConst);
                }

                _context.Astrologies.Remove(entity!);
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