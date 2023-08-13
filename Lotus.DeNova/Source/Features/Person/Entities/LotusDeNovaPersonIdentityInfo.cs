//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема персонажа
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaPersonIdentityInfo.cs
*		Класс для определения идентификационных сведений о персонаже.
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
		/** \addtogroup DeNovaPerson
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Класс для определения идентификационных сведений о персонаже
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		[Serializable]
		public class CIdentityInfo : EntityDbNotifyProperty<Int32>, IComparable<CIdentityInfo>,
			ILotusDatePeriod, ILotusSupportViewInspector
		{
			#region ======================================= КОНСТАНТНЫЕ ДАННЫЕ ========================================
			/// <summary>
			/// Имя таблицы
			/// </summary>
			public const String TABLE_NAME = "IdentityInfo";
			#endregion

			#region ======================================= СТАТИЧЕСКИЕ ДАННЫЕ ========================================
			//
			// Константы для информирования об изменении свойств
			//
			protected static readonly PropertyChangedEventArgs PropertyArgsName = new(nameof(Name));
			protected static readonly PropertyChangedEventArgs PropertyArgsSurname = new(nameof(Surname));
			protected static readonly PropertyChangedEventArgs PropertyArgsFatherName = new(nameof(FatherName));
			protected static readonly PropertyChangedEventArgs PropertyArgsCodeID = new(nameof(CodeID));
			protected static readonly PropertyChangedEventArgs PropertyArgsBeginDate = new(nameof(BeginPeriodDate));
			protected static readonly PropertyChangedEventArgs PropertyArgsEndDate = new(nameof(EndPeriodDate));
			#endregion

			#region ======================================= МЕТОДЫ ОПРЕДЕЛЕНИЯ МОДЕЛЕЙ ================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конфигурирование модели для типа <see cref="CIdentityInfo"/>
			/// </summary>
			/// <param name="modelBuilder">Интерфейс для построения моделей</param>
			//---------------------------------------------------------------------------------------------------------
			public static void ModelCreating(ModelBuilder modelBuilder)
			{
				// Определение для таблицы
				var model = modelBuilder.Entity<CIdentityInfo>();
				model.ToTable(TABLE_NAME, XDbConstants.SchemeName);
			}
			#endregion

			#region ======================================= ДАННЫЕ ====================================================
			// Основные параметры
			protected internal String mName = String.Empty;
			protected internal String? mSurname;
			protected internal String? mFatherName;
			protected internal String? mCodeID;
			protected internal DateOnly mBeginDate;
			protected internal DateOnly? mEndDate;
			#endregion

			#region ======================================= СВОЙСТВА ==================================================
			/// <summary>
			/// Имя персонажа
			/// </summary>
			[DisplayName("Имя")]
			[Description("Имя персонажа")]
			[Category(XInspectorGroupDesc.ID)]
			[LotusPropertyOrder(1)]
			[MaxLength(10, ErrorMessage = "Длина имени не может быть больше 10 символов")]
			[Required(ErrorMessage ="Имя персонажа является обязательным")]
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
			/// Фамилия персонажа
			/// </summary>
			[DisplayName("Фамилия")]
			[Description("Фамилия персонажа")]
			[Category(XInspectorGroupDesc.ID)]
			[LotusPropertyOrder(2)]
			[MaxLength(20, ErrorMessage = "Длина имени не может быть больше 20 символов")]
			[Required(ErrorMessage = "Фамилия персонажа является обязательным")]
			public String? Surname
			{
				get { return (mSurname); }
				set
				{
					mSurname = value;
					NotifyPropertyChanged(PropertyArgsSurname);
				}
			}

			/// <summary>
			/// Отчество персонажа
			/// </summary>
			[DisplayName("Отчество")]
			[Description("Отчество персонажа")]
			[Category(XInspectorGroupDesc.ID)]
			[LotusPropertyOrder(3)]
			[MaxLength(10)]
			public String? FatherName
			{
				get { return (mFatherName); }
				set
				{
					mFatherName = value;
					NotifyPropertyChanged(PropertyArgsFatherName);
				}
			}

			/// <summary>
			/// Код персонажа
			/// </summary>
			[DisplayName("Код")]
			[Description("Код персонажа")]
			[Category(XInspectorGroupDesc.ID)]
			[LotusPropertyOrder(4)]
			[MaxLength(10)]
			public String? CodeID
			{
				get { return (mCodeID); }
				set
				{
					mCodeID = value;
					NotifyPropertyChanged(PropertyArgsCodeID);
				}
			}

			/// <summary>
			/// Дата начала
			/// </summary>
			[DisplayName("Дата начала")]
			[Description("Дата начала")]
			[Category(XInspectorGroupDesc.ID)]
			[LotusPropertyOrder(5)]
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
			/// Дата окончание
			/// </summary>
			[DisplayName("Дата окончание")]
			[Description("Дата окончание")]
			[Category(XInspectorGroupDesc.ID)]
			[LotusPropertyOrder(6)]
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
				get { return ("СВЕДЕНИЯ"); }
			}

			/// <summary>
			/// Отображаемое имя объекта в инспекторе свойств
			/// </summary>
			[Browsable(false)]
			public String InspectorObjectName
			{
				get
				{
					return ($"{Surname} {Name} {FatherName}");
				}
			}
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор по умолчанию инициализирует объект класса предустановленными значениями
			/// </summary>
			//---------------------------------------------------------------------------------------------------------
			public CIdentityInfo()
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
			public Int32 CompareTo(CIdentityInfo? other)
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
