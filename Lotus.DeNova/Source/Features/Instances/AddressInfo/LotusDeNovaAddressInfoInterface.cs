﻿//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема место жительства
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaAddressInfoInterface.cs
*		Определение интерфейса сервиса для работы с местом жительства персонажа.
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
		/** \addtogroup DeNovaAddressInfo
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Интерфейс сервиса для работы с местом жительства персонажа
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public interface ILotusAddressInfoService
        {
            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Создание места жительства персонажа по указанным данным
            /// </summary>
            /// <param name="addressInfoCreate">Параметры для создания места жительства персонажа</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Место жительства персонажа</returns>
            //---------------------------------------------------------------------------------------------------------
            Task<Response<AddressInfoDto>> CreateAsync(AddressInfoCreateDto addressInfoCreate, CancellationToken token);

            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Обновление данных места жительства персонажа
            /// </summary>
            /// <param name="addressInfoUpdate">Параметры обновляемой места жительства персонажа</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Место жительства персонажа</returns>
            //---------------------------------------------------------------------------------------------------------
            Task<Response<AddressInfoDto>> UpdateAsync(AddressInfoDto addressInfoUpdate, CancellationToken token);

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение указанного места жительства персонажа
			/// </summary>
			/// <param name="addressInfoId">Идентификатор места жительства персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Место жительства персонажа</returns>
			//---------------------------------------------------------------------------------------------------------
			Task<Response<AddressInfoDto>> GetAsync(Guid addressInfoId, CancellationToken token);

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка мест жительств персонажа 
			/// </summary>
			/// <param name="addressInfoRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Cписок мест жительств персонажа </returns>
			//---------------------------------------------------------------------------------------------------------
			Task<ResponsePage<AddressInfoDto>> GetAllAsync(AddressInfosDto addressInfoRequest, CancellationToken token);

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Удаление места жительства персонажа
			/// </summary>
			/// <param name="addressInfoId">Идентификатор места жительства персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Статус успешности</returns>
			//---------------------------------------------------------------------------------------------------------
			Task<Response> DeleteAsync(Guid addressInfoId, CancellationToken token);
        }
        //-------------------------------------------------------------------------------------------------------------
        /**@}*/
        //-------------------------------------------------------------------------------------------------------------
    }
}
//=====================================================================================================================