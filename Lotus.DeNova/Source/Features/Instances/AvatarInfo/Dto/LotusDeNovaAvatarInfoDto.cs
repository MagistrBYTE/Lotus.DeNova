﻿//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема аватара персонажа
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaAvatarInfoDto.cs
*		Класс для определения аватара персонажа.
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
		/** \addtogroup DeNovaAvatarInfo
        *@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Класс для определения аватара персонажа
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class AvatarInfoDto : IdentifierDtoId<Guid>
        {
			/// <summary>
			/// Идентификатор сущности
			/// </summary>
			public Guid AvatarInfoId { get; set; }

			/// <summary>
			/// Идентификатор контекста игры
			/// </summary>
			public Guid GameContextId { get; set; }

			/// <summary>
			/// Идентификатор персонажа
			/// </summary>
			public Guid PersonId { get; set; }

			/// <summary>
			/// Идентификатор изображения
			/// </summary>
			public Int32? ImageId { get; set; }

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