﻿//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема контекста игры
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaGameContextDto.cs
*		Класс контекста игры.
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
		/// Класс контекста игры
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class GameContextDto : IdentifierDtoId<Guid>
        {
			/// <summary>
			/// Идентификатор игрока
			/// </summary>
			public Guid UserId { get; set; }

			/// <summary>
			/// Идентификатор сеттинга игры
			/// </summary>
			public Int32? CampaignSettingId { get; set; }

			/// <summary>
			/// Статус текущего(актуального) контекст игры
			/// </summary>
			/// <remarks>
			/// Для каждого игрока может быть только один актуальный контекст игры
			/// </remarks>
			public Boolean IsCurrent { get; set; }

			/// <summary>
			/// Название игры
			/// </summary>
			public String Name { get; set; } = null!;
		}
        //-------------------------------------------------------------------------------------------------------------
        /**@}*/
        //-------------------------------------------------------------------------------------------------------------
    }
}
//=====================================================================================================================