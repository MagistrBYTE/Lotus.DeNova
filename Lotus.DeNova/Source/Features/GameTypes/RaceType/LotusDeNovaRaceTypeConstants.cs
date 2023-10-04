//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема рас
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaRaceTypeConstants.cs
*		Работа с константными и первоначальными данными подсистемы рас.
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
		/** \addtogroup DeNovaRaceType
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Статический класс для определения констант и первоначальных данных подсистемы рас
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public static class XRaceTypeConstants
		{
			#region ======================================= ДАННЫЕ ====================================================
			/// <summary>
			/// Эриец
			/// </summary>
			public static readonly RaceType Erian = new RaceType()
            {
                Id = 1,
                Name = "Erian",
				DisplayName = "Эриец",
				GameSettingTypeId = XGameSettingTypeConstants.Sentra.Id
			};

			/// <summary>
			/// Завротеанен
			/// </summary>
			public static readonly RaceType Zavroteanen = new RaceType()
			{
				Id = 2,
				Name = "Zavroteanen",
				DisplayName = "Завротеанен",
				GameSettingTypeId = XGameSettingTypeConstants.Sentra.Id
			};

			/// <summary>
			/// Леохарт
			/// </summary>
			public static readonly RaceType Leohart = new RaceType()
			{
				Id = 3,
				Name = "Leohart",
				DisplayName = "Леохарт",
				GameSettingTypeId = XGameSettingTypeConstants.Sentra.Id
			};

			/// <summary>
			/// Триб
			/// </summary>
			public static readonly RaceType Tribe = new RaceType()
			{
				Id = 4,
				Name = "Tribe",
				DisplayName = "Триб",
				GameSettingTypeId = XGameSettingTypeConstants.Sentra.Id
			};

			/// <summary>
			/// Гвелл
			/// </summary>
			public static readonly RaceType Gwell = new RaceType()
			{
				Id = 5,
				Name = "Gwell",
				DisplayName = "Гвелл",
				GameSettingTypeId = XGameSettingTypeConstants.Sentra.Id
			};

			/// <summary>
			/// Эль`гоу
			/// </summary>
			public static readonly RaceType Elgou = new RaceType()
			{
				Id = 6,
				Name = "Elgou",
				DisplayName = "Эль`гоу",
				GameSettingTypeId = XGameSettingTypeConstants.Sentra.Id
			};

			/// <summary>
			/// Фергариец
			/// </summary>
			public static readonly RaceType Fergarian = new RaceType()
			{
				Id = 7,
				Name = "Fergarian",
				DisplayName = "Фергариец",
				GameSettingTypeId = XGameSettingTypeConstants.Sentra.Id
			};
			#endregion
		}
        //-------------------------------------------------------------------------------------------------------------
        /**@}*/
        //-------------------------------------------------------------------------------------------------------------
    }
}
//=====================================================================================================================