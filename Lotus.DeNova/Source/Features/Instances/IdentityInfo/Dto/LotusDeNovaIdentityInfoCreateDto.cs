﻿//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема идентификации персонажа
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaIdentityInfoCreateDto.cs
*		Класс для создания новых сведений о персонаже.
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
        /// Класс для создания новых сведений о персонаже
        /// </summary>
        //-------------------------------------------------------------------------------------------------------------
        public class IdentityInfoCreateDto
        {
			/// <summary>
			/// Идентификатор контекста игры
			/// </summary>
			public Guid GameContextId { get; set; }

			/// <summary>
			/// Идентификатор персонажа
			/// </summary>
			public Int32 PersonId { get; set; }

			/// <summary>
			/// Имя персонажа
			/// </summary>
			public String Name { get; set; } = null!; 

			/// <summary>
			/// Фамилия персонажа
			/// </summary>
			public String? Surname { get; set; }

			/// <summary>
			/// Отчество персонажа
			/// </summary>
			public String? FatherName { get; set; }

			/// <summary>
			/// Дата начала
			/// </summary>
			public DateTime BeginPeriod { get; set; }

			/// <summary>
			/// Дата окончания
			/// </summary>
			public DateTime? EndPeriod { get; set; }
		}
        //-------------------------------------------------------------------------------------------------------------
        /**@}*/
        //-------------------------------------------------------------------------------------------------------------
    }
}
//=====================================================================================================================