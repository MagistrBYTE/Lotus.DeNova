﻿//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема данных астрологии
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaAstrologyTypesRequest.cs
*		Класс для получения списка данных по астрологии с учетом фильтрации и сортировки.
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
		/** \addtogroup DeNovaAstrologyType
        *@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Класс для получения списка данных по астрологии с учетом фильтрации и сортировки
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class AstrologyTypesRequest : Request
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