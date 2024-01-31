//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема адресного хозяйства
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaAddressVillage.cs
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
		public class AddressVillage : EntityDbNotifyProperty<Int32>, IComparable<AddressVillage>
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
			/// Конфигурирование модели для типа <see cref="AddressVillage"/>
			/// </summary>
			/// <param name="modelBuilder">Интерфейс для построения моделей</param>
			//---------------------------------------------------------------------------------------------------------
			public static void ModelCreating(ModelBuilder modelBuilder)
			{
				// Определение для таблицы
				var model = modelBuilder.Entity<AddressVillage>();
				model.ToTable(TABLE_NAME, XDbConstants.SchemeName);
			}
			#endregion

			#region ======================================= ДАННЫЕ ====================================================
			// Основные параметры
			protected internal String _name = String.Empty;
			protected internal TAddressVillageType _villageType;
			protected internal String? _OKTMO;
			protected internal String? _OKATO;
			protected internal String? _postalCode;
			#endregion

			#region ======================================= СВОЙСТВА ==================================================
			//
			// ОСНОВНЫЕ ПАРАМЕТРЫ
			//
			/// <summary>
			/// Наименование населённого пункта
			/// </summary>
			[MaxLength(XAddressConstantsDb.LengthNameVillage)]
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
			/// Тип населённого пункта
			/// </summary>
			public TAddressVillageType VillageType
			{
				get { return (_villageType); }
				set
				{
					_villageType = value;
					NotifyPropertyChanged(PropertyArgsVillageType);
				}
			}

			/// <summary>
			/// Код ОКТМО
			/// </summary>
			[MaxLength(10)]
			public String? OKTMO
			{
				get { return (_OKTMO); }
				set
				{
					_OKTMO = value;
					NotifyPropertyChanged(PropertyArgsOKTMO);
				}
			}

			/// <summary>
			/// Код ОКАТО
			/// </summary>
			[MaxLength(10)]
			public String? OKATO
			{
				get { return (_OKATO); }
				set
				{
					_OKATO = value;
					NotifyPropertyChanged(PropertyArgsOKATO);
				}
			}

			/// <summary>
			/// Почтовый индекс
			/// </summary>
			[MaxLength(10)]
			public String? PostalCode
			{
				get { return (_postalCode); }
				set
				{
					_postalCode = value;
					NotifyPropertyChanged(PropertyArgsPostalCode);
				}
			}

			/// <summary>
			/// Внешний ключ для сельского поселения
			/// </summary>
			public Int32? VillageSettlementId { get; set; }

			/// <summary>
			/// Навигационное свойство сельского поселения
			/// </summary>
			[ForeignKey(nameof(VillageSettlementId))]
			public AddressVillageSettlement? VillageSettlement { get; set; }

			/// <summary>
			/// Список улиц
			/// </summary>
			public List<AddressStreet> Streets { get; set; } = new List<AddressStreet>();
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор по умолчанию инициализирует объект класса предустановленными значениями
			/// </summary>
			//---------------------------------------------------------------------------------------------------------
			public AddressVillage()
			{
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="name">Наименование населённого пункта</param>
			//---------------------------------------------------------------------------------------------------------
			public AddressVillage(String name)
			{
				_name = name;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="village_settlement_id">Внешний ключ для сельского поселения</param>
			/// <param name="name">Наименование населённого пункта</param>
			//---------------------------------------------------------------------------------------------------------
			public AddressVillage(Int32 village_settlement_id, String name)
			{
				_name = name;
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
			public AddressVillage(Int32 village_settlement_id, Int32 id, String name)
			{
				_name = name;
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
			public Int32 CompareTo(AddressVillage? other)
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
