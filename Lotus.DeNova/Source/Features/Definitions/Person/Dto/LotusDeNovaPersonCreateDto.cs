﻿//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема персонажа
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaPersonCreateDto.cs
*		Класс для создания нового персонажа.
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
        /** \addtogroup DeNovaPerson
        *@{*/
        //-------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Класс для создания нового персонажа
        /// </summary>
        //-------------------------------------------------------------------------------------------------------------
        public class PersonCreateDto
        {
			/// <summary>
			/// Имя персонажа
			/// </summary>
			public String Name { get; set; } = null!;

			/// <summary>
			/// Идентификатор расы
			/// </summary>
			public Int32 RaceId { get; set; }

			/// <summary>
			/// Идентификатор аватара
			/// </summary>
			public Int32? AvatarId { get; set; }

			/// <summary>
			/// Идентификатор информации о астрологических сведениях
			/// </summary>
			public Int32? AstrologyId { get; set; }
		}
        //-------------------------------------------------------------------------------------------------------------
        /**@}*/
        //-------------------------------------------------------------------------------------------------------------
    }
}
//=====================================================================================================================