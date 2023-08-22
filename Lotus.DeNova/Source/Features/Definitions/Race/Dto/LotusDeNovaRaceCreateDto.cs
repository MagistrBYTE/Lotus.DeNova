﻿//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема рас
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaRaceCreateDto.cs
*		Класс для создания новой расы.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 30.04.2023
//=====================================================================================================================
using Lotus.Core;
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
        /// Класс для создания новой расы
        /// </summary>
        //-------------------------------------------------------------------------------------------------------------
        public class RaceCreateDto
        {
			/// <summary>
			/// Идентификатор сеттинга игры
			/// </summary>
			public Int32? CampaignSettingId { get; set; }

			/// <summary>
			/// Название расы
			/// </summary>
			public String Name { get; set; } = null!;

			/// <summary>
			/// Название расы для отображения
			/// </summary>
			public String? DisplayName { get; set; }
		}
        //-------------------------------------------------------------------------------------------------------------
        /**@}*/
        //-------------------------------------------------------------------------------------------------------------
    }
}
//=====================================================================================================================