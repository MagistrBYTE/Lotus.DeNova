//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема адресного хозяйства
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file DeNovaAddressVillage.cs
*		Класс представляющий собой компонент адреса - населённый пункт.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 30.04.2023
//=====================================================================================================================
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
		/// Тип населенного пункта
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		[TypeConverter(typeof(EnumToStringConverter<TAddressVillageType>))]
		public enum TAddressVillageType
		{
			/// <summary>
			/// Город
			/// </summary>
			[Description("Город")]
			Town = 0,

			/// <summary>
			/// Поселок
			/// </summary>
			[Description("Поселок")]
			Township = 1,

			/// <summary>
			/// Село
			/// </summary>
			[Description("Село")]
			Village = 2,

			/// <summary>
			/// Железнодорожный разъезд
			/// </summary>
			[Description("Железнодорожный разъезд")]
			RailwaySiding = 24
		}

		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Класс представляющий собой компонент адреса - населённый пункт
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		[Serializable]
		public class CAddressVillage : EntityDbNotifyProperty<Int32>, IComparable<CAddressVillage>, ILotusSupportViewInspector
		{
			#region ======================================= КОНСТАНТНЫЕ ДАННЫЕ ========================================
			/// <summary>
			/// Имя таблицы
			/// </summary>
			public const String TABLE_NAME = "AddressVillage";
			#endregion

			#region ======================================= СТАТИЧЕСКИЕ ДАННЫЕ ========================================
			//
			// Константы для информирования об изменении свойств
			//
			protected static readonly PropertyChangedEventArgs PropertyArgsName = new(nameof(Name));
			protected static readonly PropertyChangedEventArgs PropertyArgsVillageType = new(nameof(VillageType));
			protected static readonly PropertyChangedEventArgs PropertyArgsOKTMO = new(nameof(OKTMO));
			protected static readonly PropertyChangedEventArgs PropertyArgsOKATO = new(nameof(OKATO));
			protected static readonly PropertyChangedEventArgs PropertyArgsPostalCode = new(nameof(PostalCode));
			#endregion

			#region ======================================= МЕТОДЫ ОПРЕДЕЛЕНИЯ МОДЕЛЕЙ ================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конфигурирование модели для типа <see cref="CAddressVillage"/>
			/// </summary>
			/// <param name="modelBuilder">Интерфейс для построения моделей</param>
			//---------------------------------------------------------------------------------------------------------
			public static void ModelCreating(ModelBuilder modelBuilder)
			{
				// Определение для таблицы
				var model = modelBuilder.Entity<CAddressVillage>();
				model.ToTable(TABLE_NAME, XDbConstants.SchemeName);
			}
			#endregion

			#region ======================================= ДАННЫЕ ====================================================
			// Основные параметры
			protected internal String mName = String.Empty;
			protected internal TAddressVillageType mVillageType;
			protected internal String? mOKTMO;
			protected internal String? mOKATO;
			protected internal String? mPostalCode;
			#endregion

			#region ======================================= СВОЙСТВА ==================================================
			//
			// ОСНОВНЫЕ ПАРАМЕТРЫ
			//
			/// <summary>
			/// Наименование населённого пункта
			/// </summary>
			[DisplayName("Наименование")]
			[Description("Наименование населённого пункта")]
			[Category(XInspectorGroupDesc.ID)]
			[LotusPropertyOrder(2)]
			[MaxLength(XAddressConstantsDb.LengthNameVillage)]
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
			/// Тип населённого пункта
			/// </summary>
			[DisplayName("Тип населённого пункта")]
			[Description("Тип населённого пункта")]
			[Category(XInspectorGroupDesc.ID)]
			[LotusPropertyOrder(3)]
			public TAddressVillageType VillageType
			{
				get { return (mVillageType); }
				set
				{
					mVillageType = value;
					NotifyPropertyChanged(PropertyArgsVillageType);
				}
			}

			/// <summary>
			/// Код ОКТМО
			/// </summary>
			[DisplayName("Код ОКТМО")]
			[Description("Код ОКТМО")]
			[Category(XInspectorGroupDesc.ID)]
			[LotusPropertyOrder(4)]
			[MaxLength(10)]
			public String? OKTMO
			{
				get { return (mOKTMO); }
				set
				{
					mOKTMO = value;
					NotifyPropertyChanged(PropertyArgsOKTMO);
				}
			}

			/// <summary>
			/// Код ОКАТО
			/// </summary>
			[DisplayName("Код ОКАТО")]
			[Description("Код ОКАТО")]
			[Category(XInspectorGroupDesc.ID)]
			[LotusPropertyOrder(5)]
			[MaxLength(10)]
			public String? OKATO
			{
				get { return (mOKATO); }
				set
				{
					mOKATO = value;
					NotifyPropertyChanged(PropertyArgsOKATO);
				}
			}

			/// <summary>
			/// Почтовый индекс
			/// </summary>
			[DisplayName("Почтовый индекс")]
			[Description("Почтовый индекс")]
			[Category(XInspectorGroupDesc.ID)]
			[LotusPropertyOrder(6)]
			[MaxLength(10)]
			public String? PostalCode
			{
				get { return (mPostalCode); }
				set
				{
					mPostalCode = value;
					NotifyPropertyChanged(PropertyArgsPostalCode);
				}
			}

			/// <summary>
			/// Внешний ключ для сельского поселения
			/// </summary>
			[Browsable(false)]
			public Int32? VillageSettlementId { get; set; }

			/// <summary>
			/// Навигационное свойство сельского поселения
			/// </summary>
			[Browsable(false)]
			[ForeignKey(nameof(VillageSettlementId))]
			public CAddressVillageSettlement? VillageSettlement { get; set; }

			/// <summary>
			/// Список улиц
			/// </summary>
			[Browsable(false)]
			public List<CAddressStreet> Streets { get; set; } = new List<CAddressStreet>();
			#endregion

			#region ======================================= СВОЙСТВА ILotusSupportViewInspector =======================
			/// <summary>
			/// Отображаемое имя типа в инспекторе свойств
			/// </summary>
			[Browsable(false)]
			public String InspectorTypeName
			{
				get { return ("НАСЕЛЁННЫЙ ПУНКТ"); }
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
			public CAddressVillage()
			{
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="name">Наименование населённого пункта</param>
			//---------------------------------------------------------------------------------------------------------
			public CAddressVillage(String name)
			{
				mName = name;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="village_settlement_id">Внешний ключ для сельского поселения</param>
			/// <param name="name">Наименование населённого пункта</param>
			//---------------------------------------------------------------------------------------------------------
			public CAddressVillage(Int32 village_settlement_id, String name)
			{
				mName = name;
				VillageSettlementId = village_settlement_id;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="village_settlement_id">Внешний ключ для сельского поселения</param>
			/// <param name="id">Индекс(ключ) населённого пункта</param>
			/// <param name="name">Наименование населённого пункта</param>
			//---------------------------------------------------------------------------------------------------------
			public CAddressVillage(Int32 village_settlement_id, Int32 id, String name)
			{
				mName = name;
				VillageSettlementId = village_settlement_id;
				Id = id;
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
			public Int32 CompareTo(CAddressVillage? other)
			{
				if (other == null) return 0;
				return (Name.CompareTo(other.Name));
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
