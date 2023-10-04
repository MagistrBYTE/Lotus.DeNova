﻿//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема параметров персонажа
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaPersonParameterDto.cs
*		Класс параметра персонажа.
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
        /// Класс параметра персонажа
        /// </summary>
        //-------------------------------------------------------------------------------------------------------------
        public class PersonParameterDto : IdentifierDtoId<Guid>
        {
			/// <summary>
			/// Идентификатор типа параметра
			/// </summary>
			public Int32 ParameterTypeId { get; set; }

			/// <summary>
			/// Значение параметра
			/// </summary>
			public Single BaseValue { get; set; }

			/// <summary>
			/// Идентификатор персонажа
			/// </summary>
			public Guid PersonId { get; set; }
		}
        //-------------------------------------------------------------------------------------------------------------
        /**@}*/
        //-------------------------------------------------------------------------------------------------------------
    }
}
//=====================================================================================================================