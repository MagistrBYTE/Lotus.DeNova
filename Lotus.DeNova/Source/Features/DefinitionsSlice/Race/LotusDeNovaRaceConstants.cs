//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема рас
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaRaceConstants.cs
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
		/** \addtogroup DeNovaRace
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Статический класс для определения констант и первоначальных данных подсистемы рас
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public static class XRaceConstants
		{
			#region ======================================= ДАННЫЕ ====================================================
			/// <summary>
			/// Эриец
			/// </summary>
			public static readonly Race Erian = new Race()
            {
                Id = 1,
                Name = "Erian",
				DisplayName = "Эриец",
				CampaignSettingId = XCampaignSettingConstants.Sentra.Id
			};

			/// <summary>
			/// Завротеанен
			/// </summary>
			public static readonly Race Zavroteanen = new Race()
			{
				Id = 2,
				Name = "Zavroteanen",
				DisplayName = "Завротеанен",
				CampaignSettingId = XCampaignSettingConstants.Sentra.Id
			};

			/// <summary>
			/// Леохарт
			/// </summary>
			public static readonly Race Leohart = new Race()
			{
				Id = 3,
				Name = "Leohart",
				DisplayName = "Леохарт",
				CampaignSettingId = XCampaignSettingConstants.Sentra.Id
			};

			/// <summary>
			/// Триб
			/// </summary>
			public static readonly Race Tribe = new Race()
			{
				Id = 4,
				Name = "Tribe",
				DisplayName = "Триб",
				CampaignSettingId = XCampaignSettingConstants.Sentra.Id
			};

			/// <summary>
			/// Гнол
			/// </summary>
			public static readonly Race Gnol = new Race()
			{
				Id = 5,
				Name = "Gnol",
				DisplayName = "Гнол",
				CampaignSettingId = XCampaignSettingConstants.Sentra.Id
			};

			/// <summary>
			/// Эль`гоу
			/// </summary>
			public static readonly Race Elgou = new Race()
			{
				Id = 6,
				Name = "Elgou",
				DisplayName = "Эль`гоу",
				CampaignSettingId = XCampaignSettingConstants.Sentra.Id
			};

			/// <summary>
			/// Фергариец
			/// </summary>
			public static readonly Race Fergarian = new Race()
			{
				Id = 7,
				Name = "Fergarian",
				DisplayName = "Фергариец",
				CampaignSettingId = XCampaignSettingConstants.Sentra.Id
			};
			#endregion
		}
        //-------------------------------------------------------------------------------------------------------------
        /**@}*/
        //-------------------------------------------------------------------------------------------------------------
    }
}
//=====================================================================================================================