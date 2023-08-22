﻿//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема адресного хозяйства
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaAddressStreet.cs
*		Класс представляющий собой компонент адреса - элемент улицы в населённом пункте или местоположение 
*	вне границ населённого пункта.
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
		/// Тип улицы
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		[TypeConverter(typeof(EnumToStringConverter<TAddressStreetType>))]
		public enum TAddressStreetType
		{
			/// <summary>
			/// Тип улицы отсутствует
			/// </summary>
			[Description("Тип улицы отсутствует")]
			None = -1,

			/// <summary>
			/// Улица
			/// </summary>
			[Description("Улица")]
			Street = 0,

			/// <summary>
			/// Переулок
			/// </summary>
			[Description("Переулок")]
			Lane = 1,

			/// <summary>
			/// Микрорайон
			/// </summary>
			[Description("Микрорайон")]
			Microdistrict = 2
		}

		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Класс представляющий собой компонент адреса - элемент улицы в населённом пункте или местоположение 
		/// вне границ населённого пункта
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		[Serializable]
		public class AddressStreet : EntityDbNotifyProperty<Int32>, IComparable<AddressStreet>, ILotusSupportViewInspector
		{
			#region ======================================= КОНСТАНТНЫЕ ДАННЫЕ ========================================
			/// <summary>
			/// Имя таблицы
			/// </summary>
			public const String TABLE_NAME = "AddressStreet";
			#endregion

			#region ======================================= СТАТИЧЕСКИЕ ДАННЫЕ ========================================
			//
			// Константы для информирования об изменении свойств
			//
			protected static readonly PropertyChangedEventArgs PropertyArgsStreetType = new(nameof(StreetType));
			protected static readonly PropertyChangedEventArgs PropertyArgsName = new(nameof(Name));
			#endregion

			#region ======================================= МЕТОДЫ ОПРЕДЕЛЕНИЯ МОДЕЛЕЙ ================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конфигурирование модели для типа <see cref="AddressStreet"/>
			/// </summary>
			/// <param name="modelBuilder">Интерфейс для построения моделей</param>
			//---------------------------------------------------------------------------------------------------------
			public static void ModelCreating(ModelBuilder modelBuilder)
			{
				// Определение для таблицы
				var model = modelBuilder.Entity<AddressStreet>();
				model.ToTable(TABLE_NAME, XDbConstants.SchemeName);
			}
			#endregion

			#region ======================================= ДАННЫЕ ====================================================
			// Основные параметры
			protected internal String mName = String.Empty;
			protected internal TAddressStreetType mStreetType;
			#endregion

			#region ======================================= СВОЙСТВА ==================================================
			//
			// ОСНОВНЫЕ ПАРАМЕТРЫ
			//
			/// <summary>
			/// Тип улицы
			/// </summary>
			[DisplayName("Тип улицы")]
			[Description("Тип улицы")]
			[Category(XInspectorGroupDesc.ID)]
			[LotusPropertyOrder(1)]
			public TAddressStreetType StreetType
			{
				get { return (mStreetType); }
				set
				{
					mStreetType = value;
					NotifyPropertyChanged(PropertyArgsStreetType);
				}
			}

			/// <summary>
			/// Наименование
			/// </summary>
			[DisplayName("Наименование")]
			[Description("Наименование улицы")]
			[Category(XInspectorGroupDesc.ID)]
			[LotusPropertyOrder(2)]
			[MaxLength(XAddressConstantsDb.LengthNameStreet)]
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
			/// Внешний ключ для населённого пункта
			/// </summary>
			[Browsable(false)]
			public Int32? VillageId { get; set; }

			/// <summary>
			/// Навигационное свойство населённого пункта
			/// </summary>
			[Browsable(false)]
			[ForeignKey(nameof(VillageId))]
			public AddressVillage? Village { get; set; }

			/// <summary>
			/// Список элементов
			/// </summary>
			[Browsable(false)]
			public List<AddressElement> Elements { get; set; } = new List<AddressElement>();
			#endregion

			#region ======================================= СВОЙСТВА ILotusSupportViewInspector =======================
			/// <summary>
			/// Отображаемое имя типа в инспекторе свойств
			/// </summary>
			[Browsable(false)]
			public String InspectorTypeName
			{
				get { return ("УЛИЦА"); }
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
			public AddressStreet()
			{
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="name">Наименование улицы</param>
			//---------------------------------------------------------------------------------------------------------
			public AddressStreet(String name)
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
			public Int32 CompareTo(AddressStreet? other)
			{
				if(other == null) return 0;
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
