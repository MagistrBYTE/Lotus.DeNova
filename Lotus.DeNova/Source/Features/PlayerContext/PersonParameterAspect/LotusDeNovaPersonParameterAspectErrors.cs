﻿//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема параметра персонажа
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaPersonParameterAspectErrors.cs
*		Работа с ошибками подсистемы аспектов параметров персонажа.
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
		/** \addtogroup DeNovaPersonParameter
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Статический класс для определения ошибок подсистемы аспектов параметров персонажа
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public static class XPersonParameterAspectErrors
        {
            #region ======================================= ДАННЫЕ ====================================================
            /// <summary>
            /// Аспект параметра персонажа не найдена
            /// </summary>
            public static readonly Result NotFound = new()
            {
                Code = 1000,
                Message = "Аспект параметра персонажа не найдена",
                Succeeded = false,
            };

            /// <summary>
            /// Нельзя удалить константную расу
            /// </summary>
            public static readonly Result NotDeleteConst = new()
            {
                Code = 1002,
                Message = "Нельзя удалить константную расу",
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