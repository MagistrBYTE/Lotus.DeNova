//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема изображений
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaImageService.cs
*		Cервис для работы с изображениями.
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
		/** \addtogroup DeNovaImage
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Cервис для работы с изображениями
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class ImageService : ILotusImageService
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
            public ImageService(DeNovaDbContext context)
            {
                _context = context;
            }
            #endregion

            #region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Создание изображения по указанным данным
            /// </summary>
            /// <param name="imageCreate">Параметры для создания изображения</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Изображение</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response<ImageDto>> CreateAsync(ImageCreateDto imageCreate, CancellationToken token)
            {
                Image entity = imageCreate.Adapt<Image>();

                _context.Images.Add(entity);
                await _context.SaveChangesAsync(token);

                ImageDto result = entity.Adapt<ImageDto>();

                return XResponse.Succeed(result);
            }

            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Обновление данных указанного изображения
            /// </summary>
            /// <param name="imageUpdate">Параметры обновляемого изображения</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Изображение</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response<ImageDto>> UpdateAsync(ImageDto imageUpdate, CancellationToken token)
            {
                Image entity = imageUpdate.Adapt<Image>();

                _context.Images.Update(entity);
                await _context.SaveChangesAsync(token);

                ImageDto result = entity.Adapt<ImageDto>();

                return XResponse.Succeed(result);
            }

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение указанного изображения
			/// </summary>
			/// <param name="id">Идентификатор изображения</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Изображение</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response<ImageDto>> GetAsync(Int32 id, CancellationToken token)
			{
				Image? entity = await _context.Images.FirstOrDefaultAsync(x => x.Id == id, token);
				if (entity == null)
				{
					return XResponse.Failed<ImageDto>(XImageErrors.NotFound);
				}

				ImageDto result = entity.Adapt<ImageDto>();

				return XResponse.Succeed(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка изображений
			/// </summary>
			/// <param name="imageRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Cписок изображений</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<ResponsePage<ImageDto>> GetAllAsync(ImagesDto imageRequest, CancellationToken token)
            {
                var query = _context.Images.AsQueryable();

				if(imageRequest.CampaignSettingId.HasValue)
				{
					query = query.Where(x => x.CampaignSettingId == imageRequest.CampaignSettingId);
				}

                query = query.Filter(imageRequest.Filtering);

				var queryOrder = query.Sort(imageRequest.Sorting, x => x.Id);

				var result = await queryOrder.ToResponsePageAsync<Image, ImageDto>(imageRequest, token);

                return result;
            }

            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Удаление изображения
            /// </summary>
            /// <param name="id">Идентификатор изображения</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Статус успешности</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response> DeleteAsync(Int32 id, CancellationToken token)
            {
                Image? entity = await _context.Images.FirstOrDefaultAsync(x => x.Id == id, token);
                if (entity == null)
                {
                    return XResponse.Failed(XImageErrors.NotFound);
                }

                if (entity.Id < 4)
                {
                    return XResponse.Failed(XImageErrors.NotDeleteConst);
                }

                _context.Images.Remove(entity!);
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