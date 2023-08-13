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
		/// Статический класс для определения констант и первоначальных данных типа <see cref="CAddressVillageSettlement"/>
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public static class XAddressConstantsVillageSettlement
		{
			/// <summary>
			/// Андреевское сельское поселение
			/// </summary>
			public static readonly CAddressVillageSettlement Andreyevskoye = new()
			{
				Id = 1,
				Name = "Андреевское сельское поселение",
				ShortName = "Андреевское СП",
				VillageSettlementType = "Cельское поселение"
			};

			/// <summary>
			/// Атамановское сельское поселение
			/// </summary>
			public static readonly CAddressVillageSettlement Atamanovskoye = new()
			{
				Id = 2,
				Name = "Атамановское сельское поселение",
				ShortName = "Атамановское СП",
				VillageSettlementType = "Cельское поселение"
			};

			/// <summary>
			/// Белокаменское сельское поселение
			/// </summary>
			public static readonly CAddressVillageSettlement Belokamenskoye = new()
			{
				Id = 3,
				Name = "Белокаменское сельское поселение",
				ShortName = "Белокаменское СП",
				VillageSettlementType = "Cельское поселение"
			};

			/// <summary>
			/// Боровское сельское поселение
			/// </summary>
			public static readonly CAddressVillageSettlement Borovskoye = new()
			{
				Id = 4,
				Name = "Боровское сельское поселение",
				ShortName = "Боровское СП",
				VillageSettlementType = "Cельское поселение"
			};

			/// <summary>
			/// Брединское сельское поселение
			/// </summary>
			public static readonly CAddressVillageSettlement Bredinskoye = new()
			{
				Id = 5,
				Name = "Брединское сельское поселение",
				ShortName = "Брединское СП",
				VillageSettlementType = "Cельское поселение"
			};

			/// <summary>
			/// Калининское сельское поселение
			/// </summary>
			public static readonly CAddressVillageSettlement Kalininskoye = new()
			{
				Id = 6,
				Name = "Калининское сельское поселение",
				ShortName = "Калининское СП",
				VillageSettlementType = "Cельское поселение"
			};

			/// <summary>
			/// Княженское сельское поселение
			/// </summary>
			public static readonly CAddressVillageSettlement Knyazhenskoye = new()
			{
				Id = 7,
				Name = "Княженское сельское поселение",
				ShortName = "Княженское СП",
				VillageSettlementType = "Cельское поселение"
			};

			/// <summary>
			/// Комсомольское сельское поселение
			/// </summary>
			public static readonly CAddressVillageSettlement Komsomolskoye = new()
			{
				Id = 8,
				Name = "Комсомольское сельское поселение",
				ShortName = "Комсомольское СП",
				VillageSettlementType = "Cельское поселение"
			};

			/// <summary>
			/// Наследницкое сельское поселение
			/// </summary>
			public static readonly CAddressVillageSettlement Naslednitskoye = new()
			{
				Id = 9,
				Name = "Наследницкое сельское поселение",
				ShortName = "Наследницкое СП",
				VillageSettlementType = "Cельское поселение"
			};

			/// <summary>
			/// Павловское сельское поселение
			/// </summary>
			public static readonly CAddressVillageSettlement Pavlovskoye = new()
			{
				Id = 10,
				Name = "Павловское сельское поселение",
				ShortName = "Павловское СП",
				VillageSettlementType = "Cельское поселение"
			};

			/// <summary>
			/// Рымникское сельское поселение
			/// </summary>
			public static readonly CAddressVillageSettlement Rymnikskoye = new()
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
