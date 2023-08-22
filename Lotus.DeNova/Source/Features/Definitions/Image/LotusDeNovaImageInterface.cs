﻿//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема изображений
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaImageInterface.cs
*		Определение интерфейса сервиса для работы с изображениями.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 30.04.2023
//=====================================================================================================================
using Lotus.Account;
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
		/// Интерфейс сервиса для работы с изображениями
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public interface ILotusImageService
        {
            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Создание изображения по указанным данным
            /// </summary>
            /// <param name="imageCreate">Параметры для создания изображения</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Изображение</returns>
            //---------------------------------------------------------------------------------------------------------
            Task<Response<ImageDto>> CreateAsync(ImageCreateDto imageCreate, CancellationToken token);

            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Обновление данных указанного изображения
            /// </summary>
            /// <param name="imageUpdate">Параметры обновляемой изображения</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Изображение</returns>
            //---------------------------------------------------------------------------------------------------------
            Task<Response<ImageDto>> UpdateAsync(ImageDto imageUpdate, CancellationToken token);

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение указанного изображения
			/// </summary>
			/// <param name="id">Идентификатор изображения</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Изображение</returns>
			//---------------------------------------------------------------------------------------------------------
			Task<Response<ImageDto>> GetAsync(Int32 id, CancellationToken token);

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка изображений
			/// </summary>
			/// <param name="imageRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Cписок изображений</returns>
			//---------------------------------------------------------------------------------------------------------
			Task<ResponsePage<ImageDto>> GetAllAsync(ImagesDto imageRequest, CancellationToken token);

            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Удаление изображения
            /// </summary>
            /// <param name="id">Идентификатор изображения</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Статус успешности</returns>
            //---------------------------------------------------------------------------------------------------------
            Task<Response> DeleteAsync(Int32 id, CancellationToken token);
        }
        //-------------------------------------------------------------------------------------------------------------
        /**@}*/
        //-------------------------------------------------------------------------------------------------------------
    }
}
//=====================================================================================================================