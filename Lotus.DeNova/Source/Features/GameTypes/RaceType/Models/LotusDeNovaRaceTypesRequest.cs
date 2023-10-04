﻿//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема рас
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaRaceTypesRequest.cs
*		Класс для получения списка рас с учетом фильтрации и сортировки.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 30.04.2023
//=====================================================================================================================
using Lotus.Core;
using Lotus.Repository;
//=====================================================================================================================
namespace Lotus
{
    namespace DeNova
	{
        //-------------------------------------------------------------------------------------------------------------
        /** \addtogroup DeNovaRaceType
        *@{*/
        //-------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Класс для получения списка рас с учетом фильтрации и сортировки
        /// </summary>
        //-------------------------------------------------------------------------------------------------------------
        public class RaceTypesRequest : Request
        {
			/// <summary>
			/// Идентификатор сеттинга игры
			/// </summary>
			public Int32? GameSettingTypeId { get; set; }
		}
        //-------------------------------------------------------------------------------------------------------------
        /**@}*/
        //-------------------------------------------------------------------------------------------------------------
    }
}
//=====================================================================================================================