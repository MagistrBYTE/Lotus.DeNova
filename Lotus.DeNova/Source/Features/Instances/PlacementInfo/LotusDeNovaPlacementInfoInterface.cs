﻿//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема перемещения персонажа
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaPlacementInfoInterface.cs
*		Определение интерфейса сервиса для работы с местоположением персонажа.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 30.04.2023
//=====================================================================================================================
using Lotus.Repository;
//=====================================================================================================================
namespace Lotus
{
    namespace DeNova
	{
		//-------------------------------------------------------------------------------------------------------------
		/** \addtogroup DeNovaPlacementInfo
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Интерфейс сервиса для работы с местоположением персонажа
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public interface ILotusPlacementInfoService
        {
            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Создание местоположения персонажа по указанным данным
            /// </summary>
            /// <param name="placementInfoCreate">Параметры для создания местоположения персонажа</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Местоположение персонажа</returns>
            //---------------------------------------------------------------------------------------------------------
            Task<Response<PlacementInfoDto>> CreateAsync(PlacementInfoCreateDto placementInfoCreate, CancellationToken token);

            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Обновление данных о местоположении персонажа
            /// </summary>
            /// <param name="placementInfoUpdate">Параметры обновляемого местоположения персонажа</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Местоположение персонажа</returns>
            //---------------------------------------------------------------------------------------------------------
            Task<Response<PlacementInfoDto>> UpdateAsync(PlacementInfoDto placementInfoUpdate, CancellationToken token);

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение указанного местоположения персонажа
			/// </summary>
			/// <param name="placementInfoId">Идентификатор местоположения персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Местоположение персонажа</returns>
			//---------------------------------------------------------------------------------------------------------
			Task<Response<PlacementInfoDto>> GetAsync(Guid placementInfoId, CancellationToken token);

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка местоположений персонажа 
			/// </summary>
			/// <param name="placementInfoRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Список местоположений персонажа</returns>
			//---------------------------------------------------------------------------------------------------------
			Task<ResponsePage<PlacementInfoDto>> GetAllAsync(PlacementInfosDto placementInfoRequest, CancellationToken token);

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Удаление местоположения персонажа
			/// </summary>
			/// <param name="placementInfoId">Идентификатор местоположения персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Статус успешности</returns>
			//---------------------------------------------------------------------------------------------------------
			Task<Response> DeleteAsync(Guid placementInfoId, CancellationToken token);
        }
        //-------------------------------------------------------------------------------------------------------------
        /**@}*/
        //-------------------------------------------------------------------------------------------------------------
    }
}
//=====================================================================================================================