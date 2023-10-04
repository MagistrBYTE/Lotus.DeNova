//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема адресного хозяйства
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaAddressConstantsVillageSettlement.cs
*		Работа с константными и первоначальными данными подсистемы адресного хозяйства.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 30.04.2023
//=====================================================================================================================
using System;
//=====================================================================================================================
namespace Lotus
{
	namespace DeNova
	{
		//-------------------------------------------------------------------------------------------------------------
		/** \addtogroup DeNovaAddress
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Статический класс для определения констант и первоначальных данных типа <see cref="AddressVillageSettlement"/>
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public static class XAddressConstantsVillageSettlement
		{
			/// <summary>
			/// Андреевское сельское поселение
			/// </summary>
			public static readonly AddressVillageSettlement Andreyevskoye = new()
			{
				Id = 1,
				Name = "Андреевское сельское поселение",
				ShortName = "Андреевское СП",
				VillageSettlementType = "Cельское поселение"
			};

			/// <summary>
			/// Атамановское сельское поселение
			/// </summary>
			public static readonly AddressVillageSettlement Atamanovskoye = new()
			{
				Id = 2,
				Name = "Атамановское сельское поселение",
				ShortName = "Атамановское СП",
				VillageSettlementType = "Cельское поселение"
			};

			/// <summary>
			/// Белокаменское сельское поселение
			/// </summary>
			public static readonly AddressVillageSettlement Belokamenskoye = new()
			{
				Id = 3,
				Name = "Белокаменское сельское поселение",
				ShortName = "Белокаменское СП",
				VillageSettlementType = "Cельское поселение"
			};

			/// <summary>
			/// Боровское сельское поселение
			/// </summary>
			public static readonly AddressVillageSettlement Borovskoye = new()
			{
				Id = 4,
				Name = "Боровское сельское поселение",
				ShortName = "Боровское СП",
				VillageSettlementType = "Cельское поселение"
			};

			/// <summary>
			/// Брединское сельское поселение
			/// </summary>
			public static readonly AddressVillageSettlement Bredinskoye = new()
			{
				Id = 5,
				Name = "Брединское сельское поселение",
				ShortName = "Брединское СП",
				VillageSettlementType = "Cельское поселение"
			};

			/// <summary>
			/// Калининское сельское поселение
			/// </summary>
			public static readonly AddressVillageSettlement Kalininskoye = new()
			{
				Id = 6,
				Name = "Калининское сельское поселение",
				ShortName = "Калининское СП",
				VillageSettlementType = "Cельское поселение"
			};

			/// <summary>
			/// Княженское сельское поселение
			/// </summary>
			public static readonly AddressVillageSettlement Knyazhenskoye = new()
			{
				Id = 7,
				Name = "Княженское сельское поселение",
				ShortName = "Княженское СП",
				VillageSettlementType = "Cельское поселение"
			};

			/// <summary>
			/// Комсомольское сельское поселение
			/// </summary>
			public static readonly AddressVillageSettlement Komsomolskoye = new()
			{
				Id = 8,
				Name = "Комсомольское сельское поселение",
				ShortName = "Комсомольское СП",
				VillageSettlementType = "Cельское поселение"
			};

			/// <summary>
			/// Наследницкое сельское поселение
			/// </summary>
			public static readonly AddressVillageSettlement Naslednitskoye = new()
			{
				Id = 9,
				Name = "Наследницкое сельское поселение",
				ShortName = "Наследницкое СП",
				VillageSettlementType = "Cельское поселение"
			};

			/// <summary>
			/// Павловское сельское поселение
			/// </summary>
			public static readonly AddressVillageSettlement Pavlovskoye = new()
			{
				Id = 10,
				Name = "Павловское сельское поселение",
				ShortName = "Павловское СП",
				VillageSettlementType = "Cельское поселение"
			};

			/// <summary>
			/// Рымникское сельское поселение
			/// </summary>
			public static readonly AddressVillageSettlement Rymnikskoye = new()
			{
				Id = 11,
				Name = "Рымникское сельское поселение",
				ShortName = "Рымникское СП",
				VillageSettlementType = "Cельское поселение"
			};

			/// <summary>
			/// Краткие названия сельских поселений
			/// </summary>
			public static readonly String[] ShortNames = new String[]
			{
				"Андреевское СП",
				"Атамановское СП",
				"Белокаменское СП",
				"Боровское СП",
				"Брединское СП",
				"Калининское СП",
				"Княженское СП",
				"Комсомольское СП",
				"Наследницкое СП",
				"Павловское СП",
				"Рымникское СП"
			};
		}
		//-------------------------------------------------------------------------------------------------------------
		/**@}*/
		//-------------------------------------------------------------------------------------------------------------
	}
}
//=====================================================================================================================
