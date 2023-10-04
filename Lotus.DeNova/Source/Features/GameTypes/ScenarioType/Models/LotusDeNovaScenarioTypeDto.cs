﻿//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема сценария
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaScenarioTypeDto.cs
*		Класс сценария.
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
        /// Класс сценария
        /// </summary>
        //-------------------------------------------------------------------------------------------------------------
        public class ScenarioTypeDto : IdentifierDtoId<Int32>
        {
			/// <summary>
			/// Идентификатор сеттинга игры
			/// </summary>
			public Int32? GameSettingTypeId { get; set; }

			/// <summary>
			/// Название сценария
			/// </summary>
			public String Name { get; set; } = null!;

			/// <summary>
			/// Название сценария для отображения
			/// </summary>
			public String? DisplayName { get; set; }

			/// <summary>
			/// Дополнительная информация
			/// </summary>
			public String? AdditionalInfo { get; set; }
		}
        //-------------------------------------------------------------------------------------------------------------
        /**@}*/
        //-------------------------------------------------------------------------------------------------------------
    }
}
//=====================================================================================================================