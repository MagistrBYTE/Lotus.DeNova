//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема адресного хозяйства
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaAddress.cs
*		Класс для определения информации о структуре адреса или местоположения объекта.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 30.04.2023
//=====================================================================================================================
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
		/**
         * \defgroup DeNovaAddress Подсистема адресного хозяйства
         * \ingroup DeNova
         * \brief Подсистема адресного хозяйства обеспечивает идентификацию объектов на основе адреса и местоположения.
         * @{
         */
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Тип адресуемого элемента
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		[TypeConverter(typeof(EnumToStringConverter<TAddressElementType>))]
		public enum TAddressElementType
		{
			/// <summary>
			/// Земельный участок
			/// </summary>
			[Description("Земельный участок")]
			Landplot = 0,

			/// <summary>
			/// Объект капитального строительства
			/// </summary>
			[Description("Объект капитального строительства")]
			Building = 1,

			/// <summary>
			/// Квартира
			/// </summary>
			[Description("Квартира")]
			Apartment = 2
		}

		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Класс для определения информации о структуре адреса или местоположении объекта
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		[Serializable]
		public class CAddressElement : EntityDbNotifyProperty<Int32>, IComparable<CAddressElement>, ILotusSupportViewInspector
		{
			#region ======================================= КОНСТАНТНЫЕ ДАННЫЕ ========================================
			/// <summary>
			/// Имя таблицы
			/// </summary>
			public const String TABLE_NAME = "AddressElement";
			#endregion

			#region ======================================= СТАТИЧЕСКИЕ ДАННЫЕ ========================================
			//
			// Константы для информирования об изменении свойств
			//
			protected static readonly PropertyChangedEventArgs PropertyArgsElementType = new(nameof(ElementType));
			protected static readonly PropertyChangedEventArgs PropertyArgsName = new(nameof(Name));
			protected static readonly PropertyChangedEventArgs PropertyArgsNumber = new(nameof(Number));
			protected static readonly PropertyChangedEventArgs PropertyArgsCadastralNumber = new(nameof(CadastralNumber));
			protected static readonly PropertyChangedEventArgs PropertyArgsCode = new(nameof(Code));
			#endregion

			#region ======================================= МЕТОДЫ ОПРЕДЕЛЕНИЯ МОДЕЛЕЙ ================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конфигурирование модели для типа <see cref="CAddressElement"/>
			/// </summary>
			/// <param name="modelBuilder">Интерфейс для построения моделей</param>
			//---------------------------------------------------------------------------------------------------------
			public static void ModelCreating(ModelBuilder modelBuilder)
			{
				// Определение для таблицы
				var model = modelBuilder.Entity<CAddressElement>();
				model.ToTable(TABLE_NAME, XDbConstants.SchemeName);
			}
			#endregion

			#region ======================================= ДАННЫЕ ====================================================
			// Основные параметры
			protected internal TAddressElementType mElementType;
			protected internal String mName = String.Empty;
			protected internal String mNumber = String.Empty;
			protected internal String? mCadastralNumber;
			protected internal String? mCode;
			#endregion

			#region ======================================= СВОЙСТВА ==================================================
			//
			// ОСНОВНЫЕ ПАРАМЕТРЫ
			//
			/// <summary>
			/// Тип адресуемого элемента
			/// </summary>
			[DisplayName("Тип элемента")]
			[Description("Тип адресуемого элемента")]
			[Category(XInspectorGroupDesc.ID)]
			[LotusPropertyOrder(1)]
			public TAddressElementType ElementType
			{
				get { return (mElementType); }
				set
				{
					mElementType = value;
					NotifyPropertyChanged(PropertyArgsElementType);
				}
			}

			/// <summary>
			/// Наименование адресуемого элемента
			/// </summary>
			[DisplayName("Наименование")]
			[Description("Наименование адресуемого элемента")]
			[Category(XInspectorGroupDesc.ID)]
			[LotusPropertyOrder(2)]
			[MaxLength(XAddressConstantsDb.LengthNameElement)]
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
			/// Номер адресуемого элемента
			/// </summary>
			[DisplayName("Номер")]
			[Description("Номер адресуемого элемента")]
			[Category(XInspectorGroupDesc.ID)]
			[LotusPropertyOrder(3)]
			[MaxLength(XAddressConstantsDb.LengthNumber)]
			public String Number
			{
				get { return (mNumber); }
				set
				{
					mNumber = value;
					NotifyPropertyChanged(PropertyArgsNumber);
				}
			}

			/// <summary>
			/// Кадастровый номер
			/// </summary>
			[DisplayName("Кадастровый номер")]
			[Description("Кадастровый номер")]
			[Category(XInspectorGroupDesc.ID)]
			[LotusPropertyOrder(4)]
			[MaxLength(XAddressConstantsDb.LengthCadastralNumber)]
			public String? CadastralNumber
			{
				get { return (mCadastralNumber); }
				set
				{
					mCadastralNumber = value;
					NotifyPropertyChanged(PropertyArgsCadastralNumber);
				}
			}

			/// <summary>
			/// Уникальный номер адреса
			/// </summary>
			[DisplayName("Уникальный номер адреса")]
			[Description("Уникальный номер адреса объекта адресации в государственном адресном реестре")]
			[Category(XInspectorGroupDesc.ID)]
			[LotusPropertyOrder(5)]
			[MaxLength(XAddressConstantsDb.LengthCadastralNumber)]
			public String? Code
			{
				get { return (mCode); }
				set
				{
					mCode = value;
					NotifyPropertyChanged(PropertyArgsCode);
				}
			}

			/// <summary>
			/// Внешний ключ для улицы
			/// </summary>
			[Browsable(false)]
			public Int32? StreetId { get; set; }

			/// <summary>
			/// Навигационное свойство для улицы
			/// </summary>
			[Browsable(false)]
			[ForeignKey(nameof(StreetId))]
			public CAddressStreet? Street { get; set; }
			#endregion

			#region ======================================= СВОЙСТВА ILotusSupportViewInspector =======================
			/// <summary>
			/// Отображаемое имя типа в инспекторе свойств
			/// </summary>
			[Browsable(false)]
			public String InspectorTypeName
			{
				get { return ("АДРЕС"); }
			}

			/// <summary>
			/// Отображаемое имя объекта в инспекторе свойств
			/// </summary>
			[Browsable(false)]
			public String InspectorObjectName
			{
				get
				{
					return (mName + ", " + mNumber);
				}
			}
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор по умолчанию инициализирует объект класса предустановленными значениями
			/// </summary>
			//---------------------------------------------------------------------------------------------------------
			public CAddressElement()
			{

			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="number">Номер адресуемого элемента</param>
			//---------------------------------------------------------------------------------------------------------
			public CAddressElement(String number)
			{
				mNumber = number;
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
			public Int32 CompareTo(CAddressElement? other)
			{
				if(other == null) return 0;

				var result = mName.CompareTo(other.Name);
				if(result == 0)
				{
					return (mNumber.CompareTo(other.Number));
				}

				return result;
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
