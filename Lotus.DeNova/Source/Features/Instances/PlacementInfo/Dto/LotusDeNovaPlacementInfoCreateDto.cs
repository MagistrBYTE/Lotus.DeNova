﻿//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема перемещения персонажа
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaPlacementInfoCreateDto.cs
*		Класс для создания нового перемещения персонажа.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 30.04.2023
//=====================================================================================================================
using Lotus.Core;
using Lotus.Maths;
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
		/// Класс для создания нового перемещения персонажа
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class PlacementInfoCreateDto
        {
			/// <summary>
			/// Идентификатор контекста игры
			/// </summary>
			public Guid GameContextId { get; set; }

			/// <summary>
			/// Идентификатор персонажа
			/// </summary>
			public Guid PersonId { get; set; }

			/// <summary>
			/// Позиция персонажа по X
			/// </summary>
			public Int32 PositionX { get; set; }

			/// <summary>
			/// Позиция персонажа по Y
			/// </summary>
			public Int32 PositionY { get; set; }

			/// <summary>
			/// Позиция персонажа по Z
			/// </summary>
			public Int32 PositionZ { get; set; }
		}
        //-------------------------------------------------------------------------------------------------------------
        /**@}*/
        //-------------------------------------------------------------------------------------------------------------
    }
}
//=====================================================================================================================