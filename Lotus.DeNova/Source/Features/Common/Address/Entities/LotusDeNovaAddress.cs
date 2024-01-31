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
		public class AddressElement : EntityDbNotifyProperty<Int32>, IComparable<AddressElement>
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
			/// Конфигурирование модели для типа <see cref="AddressElement"/>
			/// </summary>
			/// <param name="modelBuilder">Интерфейс для построения моделей</param>
			//---------------------------------------------------------------------------------------------------------
			public static void ModelCreating(ModelBuilder modelBuilder)
			{
				// Определение для таблицы
				var model = modelBuilder.Entity<AddressElement>();
				model.ToTable(TABLE_NAME, XDbConstants.SchemeName);
			}
			#endregion

			#region ======================================= ДАННЫЕ ====================================================
			// Основные параметры
			protected internal TAddressElementType _elementType;
			protected internal String _name = String.Empty;
			protected internal String _number = String.Empty;
			protected internal String? _cadastralNumber;
			protected internal String? _code;
			#endregion

			#region ======================================= СВОЙСТВА ==================================================
			//
			// ОСНОВНЫЕ ПАРАМЕТРЫ
			//
			/// <summary>
			/// Тип адресуемого элемента
			/// </summary>
			public TAddressElementType ElementType
			{
				get { return (_elementType); }
				set
				{
					_elementType = value;
					NotifyPropertyChanged(PropertyArgsElementType);
				}
			}

			/// <summary>
			/// Наименование адресуемого элемента
			/// </summary>
			[MaxLength(XAddressConstantsDb.LengthNameElement)]
			public String Name
			{
				get { return (_name); }
				set
				{
					_name = value;
					NotifyPropertyChanged(PropertyArgsName);
				}
			}

			/// <summary>
			/// Номер адресуемого элемента
			/// </summary>
			[MaxLength(XAddressConstantsDb.LengthNumber)]
			public String Number
			{
				get { return (_number); }
				set
				{
					_number = value;
					NotifyPropertyChanged(PropertyArgsNumber);
				}
			}

			/// <summary>
			/// Кадастровый номер
			/// </summary>
			[MaxLength(XAddressConstantsDb.LengthCadastralNumber)]
			public String? CadastralNumber
			{
				get { return (_cadastralNumber); }
				set
				{
					_cadastralNumber = value;
					NotifyPropertyChanged(PropertyArgsCadastralNumber);
				}
			}

			/// <summary>
			/// Уникальный номер адреса
			/// </summary>
			[MaxLength(XAddressConstantsDb.LengthCadastralNumber)]
			public String? Code
			{
				get { return (_code); }
				set
				{
					_code = value;
					NotifyPropertyChanged(PropertyArgsCode);
				}
			}

			/// <summary>
			/// Внешний ключ для улицы
			/// </summary>
			public Int32? StreetId { get; set; }

			/// <summary>
			/// Навигационное свойство для улицы
			/// </summary>
			[ForeignKey(nameof(StreetId))]
			public AddressStreet? Street { get; set; }
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор по умолчанию инициализирует объект класса предустановленными значениями
			/// </summary>
			//---------------------------------------------------------------------------------------------------------
			public AddressElement()
			{

			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="number">Номер адресуемого элемента</param>
			//---------------------------------------------------------------------------------------------------------
			public AddressElement(String number)
			{
				_number = number;
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
			public Int32 CompareTo(AddressElement? other)
			{
				if(other == null) return 0;

				var result = _name.CompareTo(other.Name);
				if(result == 0)
				{
					return (_number.CompareTo(other.Number));
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
				return (_name);
			}
			#endregion
		}
		//-------------------------------------------------------------------------------------------------------------
		/**@}*/
		//-------------------------------------------------------------------------------------------------------------
	}
}
//=====================================================================================================================
