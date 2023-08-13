﻿//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема персонажа
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaPersonBirthdayInfo.cs
*		Класс для определения информации о рождении персонажа.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 30.04.2023
//=====================================================================================================================
using System.ComponentModel;
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
		/** \addtogroup DeNovaPerson
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Класс для определения информации о рождении персонажа
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		[Serializable]
		public class CBirthdayInfo : EntityDbNotifyProperty<Int32>, IComparable<CBirthdayInfo>, ILotusSupportViewInspector
		{
			#region ======================================= КОНСТАНТНЫЕ ДАННЫЕ ========================================
			/// <summary>
			/// Имя таблицы
			/// </summary>
			public const String TABLE_NAME = "BirthdayInfo";
			#endregion

			#region ======================================= СТАТИЧЕСКИЕ ДАННЫЕ ========================================
			//
			// Константы для информирования об изменении свойств
			//
			protected static readonly PropertyChangedEventArgs PropertyArgsBirthday = new(nameof(Birthday));
			#endregion

			#region ======================================= МЕТОДЫ ОПРЕДЕЛЕНИЯ МОДЕЛЕЙ ================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конфигурирование модели для типа <see cref="CBirthdayInfo"/>
			/// </summary>
			/// <param name="modelBuilder">Интерфейс для построения моделей</param>
			//---------------------------------------------------------------------------------------------------------
			public static void ModelCreating(ModelBuilder modelBuilder)
			{
				// Определение для таблицы
				var model = modelBuilder.Entity<CBirthdayInfo>();
				model.ToTable(TABLE_NAME, XDbConstants.SchemeName);
			}
			#endregion

			#region ======================================= ДАННЫЕ ====================================================
			// Основные параметры
			protected internal DateTime mBirthday;
			#endregion

			#region ======================================= СВОЙСТВА ==================================================
			/// <summary>
			/// Дата рождения персонажа
			/// </summary>
			[DisplayName("Дата рождения")]
			[Description("Дата рождения персонажа")]
			[Category(XInspectorGroupDesc.ID)]
			[LotusPropertyOrder(1)]
			public DateTime Birthday
			{
				get { return (mBirthday); }
				set
				{
					mBirthday = value;
					NotifyPropertyChanged(PropertyArgsBirthday);
				}
			}

			/// <summary>
			/// Внешний ключ для адреса
			/// </summary>
			[Browsable(false)]
			public Int32? AddressId { get; set; }

			/// <summary>
			/// Навигационное свойство для адреса
			/// </summary>
			[Browsable(false)]
			[ForeignKey(nameof(AddressId))]
			public virtual CAddressElement? Address { get; set; }

			/// <summary>
			/// Внешний ключ для персонажа
			/// </summary>
			[Browsable(false)]
			public Guid? PersonId { get; set; }

			/// <summary>
			/// Навигационное свойство для персонажа
			/// </summary>
			[Browsable(false)]
			[ForeignKey(nameof(PersonId))]
			public virtual CPerson? Person { get; set; }
			#endregion

			#region ======================================= СВОЙСТВА ILotusSupportViewInspector =======================
			/// <summary>
			/// Отображаемое имя типа в инспекторе свойств
			/// </summary>
			[Browsable(false)]
			public String InspectorTypeName
			{
				get { return ("РОЖДЕНИЕ"); }
			}

			/// <summary>
			/// Отображаемое имя объекта в инспекторе свойств
			/// </summary>
			[Browsable(false)]
			public String InspectorObjectName
			{
				get
				{
					return (mBirthday.ToShortDateString());
				}
			}
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор по умолчанию инициализирует объект класса предустановленными значениями
			/// </summary>
			//---------------------------------------------------------------------------------------------------------
			public CBirthdayInfo()
			{

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
			public Int32 CompareTo(CBirthdayInfo? other)
			{
				if (other == null) return 0;
				return (mBirthday.CompareTo(other.Birthday));
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
