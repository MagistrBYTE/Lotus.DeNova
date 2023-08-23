﻿//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема идентификации персонажа
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaIdentityInfoErrors.cs
*		Работа с ошибками подсистемы идентификационных сведений о персонаже.
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
		/** \addtogroup DeNovaIdentityInfo
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Статический класс для определения ошибок подсистемы идентификационных сведений о персонаже
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public static class XIdentityInfoErrors
        {
			#region ======================================= ДАННЫЕ ====================================================
			/// <summary>
			/// Сведения не найдены
			/// </summary>
			public static readonly Result NotFound = new()
            {
                Code = 1000,
                Message = "Сведения не найдены",
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