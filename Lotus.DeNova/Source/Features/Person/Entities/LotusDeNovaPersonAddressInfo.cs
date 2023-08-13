//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема персонажа
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaPersonAddressInfo.cs
*		Класс для определения информации об месте жительства персонажа.
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
		/// Класс для определения информации об месте жительства персонажа
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		[Serializable]
		public class CAddressInfo : EntityDbNotifyProperty<Int32>, IComparable<CAddressInfo>,
			ILotusDatePeriod, ILotusSupportViewInspector
		{
			#region ======================================= КОНСТАНТНЫЕ ДАННЫЕ ========================================
			/// <summary>
			/// Имя таблицы
			/// </summary>
			public const String TABLE_NAME = "AddressInfo";
			#endregion

			#region ======================================= СТАТИЧЕСКИЕ ДАННЫЕ ========================================
			//
			// Константы для информирования об изменении свойств
			//
			protected static readonly PropertyChangedEventArgs PropertyArgsBeginDate = new(nameof(BeginPeriodDate));
			protected static readonly PropertyChangedEventArgs PropertyArgsEndDate = new(nameof(EndPeriodDate));
			#endregion

			#region ======================================= МЕТОДЫ ОПРЕДЕЛЕНИЯ МОДЕЛЕЙ ================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конфигурирование модели для типа <see cref="CAddressInfo"/>
			/// </summary>
			/// <param name="modelBuilder">Интерфейс для построения моделей</param>
			//---------------------------------------------------------------------------------------------------------
			public static void ModelCreating(ModelBuilder modelBuilder)
			{
				// Определение для таблицы
				var model = modelBuilder.Entity<CAddressInfo>();
				model.ToTable(TABLE_NAME, XDbConstants.SchemeName);
			}
			#endregion

			#region ======================================= ДАННЫЕ ====================================================
			// Основные параметры
			protected internal DateOnly mBeginDate;
			protected internal DateOnly? mEndDate;
			#endregion

			#region ======================================= СВОЙСТВА ==================================================
			/// <summary>
			/// Дата начала регистрации
			/// </summary>
			[DisplayName("Дата начала")]
			[Description("Дата начала регистрации")]
			[Category(XInspectorGroupDesc.ID)]
			[LotusPropertyOrder(1)]
			public DateOnly BeginPeriodDate
			{
				get { return (mBeginDate); }
				set
				{
					mBeginDate = value;
					NotifyPropertyChanged(PropertyArgsBeginDate);
				}
			}

			/// <summary>
			/// Дата окончание регистрации
			/// </summary>
			[DisplayName("Дата окончание")]
			[Description("Дата окончание регистрации")]
			[Category(XInspectorGroupDesc.ID)]
			[LotusPropertyOrder(2)]
			public DateOnly? EndPeriodDate
			{
				get { return (mEndDate); }
				set
				{
					mEndDate = value;
					NotifyPropertyChanged(PropertyArgsEndDate);
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
					return ((Address?.Name ?? "Без адреса") + " с " + this.GetPeriodOfText());
				}
			}
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор по умолчанию инициализирует объект класса предустановленными значениями
			/// </summary>
			//---------------------------------------------------------------------------------------------------------
			public CAddressInfo()
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
			public Int32 CompareTo(CAddressInfo? other)
			{
				if (other == null) return 0;
				return (mBeginDate.CompareTo(other.BeginPeriodDate));
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
