﻿//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема рас
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaRaceInterface.cs
*		Определение интерфейса сервиса для работы с расами.
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
		/** \addtogroup DeNovaRace
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Интерфейс сервиса для работы с расами
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public interface ILotusRaceService
        {
            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Создание расы по указанным данным
            /// </summary>
            /// <param name="raceCreate">Параметры для создания расы</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Раса</returns>
            //---------------------------------------------------------------------------------------------------------
            Task<Response<RaceDto>> CreateAsync(RaceCreateDto raceCreate, CancellationToken token);

            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Обновление данных указанной расы
            /// </summary>
            /// <param name="raceUpdate">Параметры обновляемой расы</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Раса</returns>
            //---------------------------------------------------------------------------------------------------------
            Task<Response<RaceDto>> UpdateAsync(RaceDto raceUpdate, CancellationToken token);

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение указанной расы
			/// </summary>
			/// <param name="id">Идентификатор расы</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Раса</returns>
			//---------------------------------------------------------------------------------------------------------
			Task<Response<RaceDto>> GetAsync(Int32 id, CancellationToken token);

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка рас
			/// </summary>
			/// <param name="raceRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Cписок рас</returns>
			//---------------------------------------------------------------------------------------------------------
			Task<ResponsePage<RaceDto>> GetAllAsync(RacesDto raceRequest, CancellationToken token);

            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Удаление расы
            /// </summary>
            /// <param name="id">Идентификатор расы</param>
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