//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема персонажа
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaPersonAvatarInfo.cs
*		Класс для определения аватара персонаже.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 30.04.2023
//=====================================================================================================================
using System;
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
		/// Класс для определения аватара персонаже
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		[Serializable]
		public class CAvatarInfo : EntityDbNotifyProperty<Int32>, IComparable<CAvatarInfo>,
			ILotusDatePeriod, ILotusSupportViewInspector
		{
			#region ======================================= КОНСТАНТНЫЕ ДАННЫЕ ========================================
			/// <summary>
			/// Имя таблицы
			/// </summary>
			public const String TABLE_NAME = "AvatarInfo";
			#endregion

			#region ======================================= СТАТИЧЕСКИЕ ДАННЫЕ ========================================
			//
			// Константы для информирования об изменении свойств
			//
			protected static readonly PropertyChangedEventArgs PropertyArgsLoadPath = new(nameof(LoadPath));
			protected static readonly PropertyChangedEventArgs PropertyArgsWidth = new(nameof(Width));
			protected static readonly PropertyChangedEventArgs PropertyArgsHeight = new(nameof(Height));
			protected static readonly PropertyChangedEventArgs PropertyArgsDataImage = new(nameof(DataImage));
			protected static readonly PropertyChangedEventArgs PropertyArgsBeginDate = new(nameof(BeginPeriodDate));
			protected static readonly PropertyChangedEventArgs PropertyArgsEndDate = new(nameof(EndPeriodDate));
			#endregion

			#region ======================================= МЕТОДЫ ОПРЕДЕЛЕНИЯ МОДЕЛЕЙ ================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конфигурирование модели для типа <see cref="CAvatarInfo"/>
			/// </summary>
			/// <param name="modelBuilder">Интерфейс для построения моделей</param>
			//---------------------------------------------------------------------------------------------------------
			public static void ModelCreating(ModelBuilder modelBuilder)
			{
				// Определение для таблицы
				var model = modelBuilder.Entity<CAvatarInfo>();
				model.ToTable(TABLE_NAME, XDbConstants.SchemeName);
			}
			#endregion

			#region ======================================= ДАННЫЕ ====================================================
			// Основные параметры
			protected internal String mLoadPath = String.Empty;
			protected internal Int32 mWidth;
			protected internal Int32 mHeight;
			protected internal Byte[] mDataImage = new Byte[10];
			protected internal DateOnly mBeginDate;
			protected internal DateOnly? mEndDate;
			#endregion

			#region ======================================= СВОЙСТВА ==================================================
			/// <summary>
			/// Uri для загрузки картинки
			/// </summary>
			[DisplayName("Uri")]
			[Description("Uri для загрузки картинки")]
			[Category(XInspectorGroupDesc.ID)]
			[LotusPropertyOrder(1)]
			public String LoadPath
			{
				get { return (mLoadPath); }
				set
				{
					mLoadPath = value;
					NotifyPropertyChanged(PropertyArgsLoadPath);
				}
			}

			/// <summary>
			/// Ширина изображения в пикселях
			/// </summary>
			[DisplayName("Ширина")]
			[Description("Ширина изображения в пикселях")]
			[Category(XInspectorGroupDesc.ID)]
			[LotusPropertyOrder(2)]
			public Int32 Width
			{
				get { return (mWidth); }
				set
				{
					mWidth = value;
					NotifyPropertyChanged(PropertyArgsWidth);
				}
			}

			/// <summary>
			/// Высота изображения в пикселях
			/// </summary>
			[DisplayName("Высота")]
			[Description("Ширина изображения в пикселях")]
			[Category(XInspectorGroupDesc.ID)]
			[LotusPropertyOrder(3)]
			public Int32 Height
			{
				get { return (mHeight); }
				set
				{
					mHeight = value;
					NotifyPropertyChanged(PropertyArgsHeight);
				}
			}

			/// <summary>
			/// Данные изображения
			/// </summary>
			[DisplayName("Данные")]
			[Description("Данные изображения")]
			[Category(XInspectorGroupDesc.ID)]
			[LotusPropertyOrder(4)]
			public Byte[] DataImage
			{
				get { return (mDataImage); }
				set
				{
					mDataImage = value;
					NotifyPropertyChanged(PropertyArgsDataImage);
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
				get { return ("АВАТАР"); }
			}

			/// <summary>
			/// Отображаемое имя объекта в инспекторе свойств
			/// </summary>
			[Browsable(false)]
			public String InspectorObjectName
			{
				get
				{
					return (LoadPath);
				}
			}
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор по умолчанию инициализирует объект класса предустановленными значениями
			/// </summary>
			//---------------------------------------------------------------------------------------------------------
			public CAvatarInfo()
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
			public Int32 CompareTo(CAvatarInfo? other)
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
