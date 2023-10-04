﻿//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема контекста игры
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaGameCreateRequest.cs
*		Класс для создания новой игры.
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
		/** \addtogroup DeNovaGameContext
        *@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Класс для создания новой игры
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class GameCreateRequest
		{
			/// <summary>
			/// Идентификатор игрока
			/// </summary>
			public Guid UserId { get; set; }

			/// <summary>
			/// Идентификатор сценария
			/// </summary>
			public Int32 ScenarioId { get; set; }
		}
        //-------------------------------------------------------------------------------------------------------------
        /**@}*/
        //-------------------------------------------------------------------------------------------------------------
    }
}
//=====================================================================================================================