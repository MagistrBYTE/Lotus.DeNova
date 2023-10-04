﻿//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема место жительства
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaAddressStateErrors.cs
*		Работа с ошибками подсистемы места жительства.
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
		/** \addtogroup DeNovaAddressState
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Статический класс для определения ошибок подсистемы места жительства
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public static class XAddressStateErrors
        {
            #region ======================================= ДАННЫЕ ====================================================
            /// <summary>
            /// Информация не найдена
            /// </summary>
            public static readonly Result NotFound = new()
            {
                Code = 1000,
                Message = "Информация не найдена",
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