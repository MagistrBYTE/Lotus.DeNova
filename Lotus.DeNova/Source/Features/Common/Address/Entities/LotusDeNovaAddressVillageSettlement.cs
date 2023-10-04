//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема адресного хозяйства
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaAddressVillageSettlement.cs
*		Класс представляющий собой компонент адреса - сельское поселение.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 30.04.2023
//=====================================================================================================================
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
//---------------------------------------------------------------------------------------------------------------------
#if USE_EFC
using Microsoft.EntityFrameworkCore;
#endif
//---------------------------------------------------------------------------------------------------------------------
using Lotus.Core;
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
		/// Класс представляющий собой компонент адреса - сельское поселение
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		[Serializable]
		[LotusSerializeData]
		public class AddressVillageSettlement : EntityDbNotifyProperty<Int32>, IComparable<AddressVillageSettlement>, 
			ILotusSupportViewInspector
		{
			#region ======================================= КОНСТАНТНЫЕ ДАННЫЕ ========================================
			/// <summary>
			/// Имя таблицы
			/// </summary>
			public const String TABLE_NAME = "AddressVillageSettlement";
			#endregion

			#region ======================================= СТАТИЧЕСКИЕ ДАННЫЕ ========================================
			//
			// Константы для информирования об изменении свойств
			//
			protected static readonly PropertyChangedEventArgs PropertyArgsName = new(nameof(Name));
			protected static readonly PropertyChangedEventArgs PropertyArgsShortName = new(nameof(ShortName));
			protected static readonly PropertyChangedEventArgs PropertyArgsVillageSettlementType = new(nameof(VillageSettlementType));
			#endregion

			#region ======================================= МЕТОДЫ ОПРЕДЕЛЕНИЯ МОДЕЛЕЙ ================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конфигурирование модели для типа <see cref="AddressVillageSettlement"/>
			/// </summary>
			/// <param name="modelBuilder">Интерфейс для построения моделей</param>
			//---------------------------------------------------------------------------------------------------------
			public static void ModelCreating(ModelBuilder modelBuilder)
			{
				// Определение для таблицы
				var model = modelBuilder.Entity<AddressVillageSettlement>();
				model.ToTable(TABLE_NAME, XDbConstants.SchemeName);
			}
			#endregion

			#region ======================================= ДАННЫЕ ====================================================
			// Основные параметры
			protected internal String mName = String.Empty;
			protected internal String? mShortName;
			protected internal String? mVillageSettlementType;
			#endregion

			#region ======================================= СВОЙСТВА ==================================================
			//
			// ОСНОВНЫЕ ПАРАМЕТРЫ
			//
			/// <summary>
			/// Наименование сельского поселения
			/// </summary>
			[DisplayName("Наименование")]
			[Description("Наименование сельского поселения")]
			[Category(XInspectorGroupDesc.ID)]
			[LotusPropertyOrder(2)]
			[MaxLength(XAddressConstantsDb.LengthNameVillageSettlement)]
			public String Name
			{
				get { return (mName); }
				set
				{
					mName = value;
					NotifyPropertyChanged(PropertyArgsName);
				}
			}

			/// <summary>
			/// Краткое наименование
			/// </summary>
			[DisplayName("Краткое наименование")]
			[Description("Краткое наименование")]
			[Category(XInspectorGroupDesc.ID)]
			[LotusPropertyOrder(1)]
			[MaxLength(XAddressConstantsDb.LengthShortName)]
			public String? ShortName
			{
				get { return (mShortName); }
				set
				{
					mShortName = value;
					NotifyPropertyChanged(PropertyArgsShortName);
				}
			}

			/// <summary>
			/// Население
			/// </summary>
			[DisplayName("Тип поселения")]
			[Description("Тип поселения")]
			[Category(XInspectorGroupDesc.ID)]
			[LotusPropertyOrder(3)]
			public String? VillageSettlementType
			{
				get { return (mVillageSettlementType); }
				set
				{
					mVillageSettlementType = value;
					NotifyPropertyChanged(PropertyArgsVillageSettlementType);
				}
			}

			/// <summary>
			/// Список населённых пунктов
			/// </summary>
			[Browsable(false)]
			public List<AddressVillage> Villages { get; set; } = new List<AddressVillage>();
			#endregion

			#region ======================================= СВОЙСТВА ILotusSupportViewInspector =======================
			/// <summary>
			/// Отображаемое имя типа в инспекторе свойств
			/// </summary>
			[Browsable(false)]
			public String InspectorTypeName
			{
				get { return ("СЕЛЬСКОЕ ПОСЕЛЕНИЕ"); }
			}

			/// <summary>
			/// Отображаемое имя объекта в инспекторе свойств
			/// </summary>
			[Browsable(false)]
			public String InspectorObjectName
			{
				get
				{
					return (mName);
				}
			}
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор по умолчанию инициализирует объект класса предустановленными значениями
			/// </summary>
			//---------------------------------------------------------------------------------------------------------
			public AddressVillageSettlement()
			{
				mName = String.Empty;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="name">Наименование сельского поселения</param>
			//---------------------------------------------------------------------------------------------------------
			public AddressVillageSettlement(String name)
			{
				mName = name;
			}
			#endregion

			#region ======================================= СИСТЕМНЫЕ МЕТОДЫ ==========================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Сравнение объектов для упорядочивания
			/// </summary>
			/// <param name="other">Сравниваемый объект</param>
			/// <returns>Статус сравнения объектов</returns>
			//---------------------------------------------------------------------------------------------------------
			public Int32 CompareTo(AddressVillageSettlement? other)
			{
				if(other == null)	return 0;
				return (Name.CompareTo(other));
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Преобразование к текстовому представлению
			/// </summary>
			/// <returns>Имя объекта</returns>
			//---------------------------------------------------------------------------------------------------------
			public override String ToString()
			{
				return (InspectorObjectName);
			}
			#endregion
		}
		//-------------------------------------------------------------------------------------------------------------
		/**@}*/
		//-------------------------------------------------------------------------------------------------------------
	}
}
//=====================================================================================================================
