﻿//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема сценария
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaScenarioTypeErrors.cs
*		Работа с ошибками подсистемы работы со сценариями.
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
		/** \addtogroup DeNovaScenarioType
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Статический класс для определения ошибок подсистемы сценария
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public static class XScenarioTypeErrors
        {
            #region ======================================= ДАННЫЕ ====================================================
            /// <summary>
            /// Сценарий не найден
            /// </summary>
            public static readonly Result NotFound = new()
            {
                Code = 1000,
                Message = "Сценарий не найден",
                Succeeded = false,
            };

            /// <summary>
            /// Нельзя удалить константный сценарий
            /// </summary>
            public static readonly Result NotDeleteConst = new()
            {
                Code = 1002,
                Message = "Нельзя удалить константный сценарий",
                Succeeded = false,
            };
            #endregion
        }
        //-------------------------------------------------------------------------------------------------------------
        /**@}*/
        //-------------------------------------------------------------------------------------------------------------
    }
}
//=====================================================================================================================