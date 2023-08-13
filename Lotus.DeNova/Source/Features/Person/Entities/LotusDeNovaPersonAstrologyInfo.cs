//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема персонажа
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaPersonAstrologyInfo.cs
*		Класс для определения информации об астрологических данных персонажа.
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
		/// Класс для определения информации об астрологических данных персонажа
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		[Serializable]
		public class CAstrologyInfo : EntityDbNotifyProperty<Int32>, IComparable<CAstrologyInfo>, ILotusSupportViewInspector
		{
			#region ======================================= КОНСТАНТНЫЕ ДАННЫЕ ========================================
			/// <summary>
			/// Имя таблицы
			/// </summary>
			public const String TABLE_NAME = "AstrologyInfo";
			#endregion

			#region ======================================= СТАТИЧЕСКИЕ ДАННЫЕ ========================================
			//
			// Константы для информирования об изменении свойств
			//
			protected static readonly PropertyChangedEventArgs PropertyArgsZodiacSign = new(nameof(ZodiacSign));
			protected static readonly PropertyChangedEventArgs PropertyArgsStoneZodiac = new(nameof(StoneZodiac));
			protected static readonly PropertyChangedEventArgs PropertyArgsTreeZodiac = new(nameof(TreeZodiac));
			#endregion

			#region ======================================= МЕТОДЫ ОПРЕДЕЛЕНИЯ МОДЕЛЕЙ ================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конфигурирование модели для типа <see cref="CAstrologyInfo"/>
			/// </summary>
			/// <param name="modelBuilder">Интерфейс для построения моделей</param>
			//---------------------------------------------------------------------------------------------------------
			public static void ModelCreating(ModelBuilder modelBuilder)
			{
				// Определение для таблицы
				var model = modelBuilder.Entity<CAstrologyInfo>();
				model.ToTable(TABLE_NAME, XDbConstants.SchemeName);
			}
			#endregion

			#region ======================================= ДАННЫЕ ====================================================
			// Основные параметры
			protected internal String? mZodiacSign;
			protected internal String? mStoneZodiac;
			protected internal String? mTreeZodiac;
			#endregion

			#region ======================================= СВОЙСТВА ==================================================
			/// <summary>
			/// Знак зодиака
			/// </summary>
			[DisplayName("Знак зодиака")]
			[Description("Знак зодиака")]
			[Category(XInspectorGroupDesc.ID)]
			[LotusPropertyOrder(1)]
			[MaxLength(10)]
			public String? ZodiacSign
			{
				get { return (mZodiacSign); }
				set
				{
					mZodiacSign = value;
					NotifyPropertyChanged(PropertyArgsZodiacSign);
				}
			}

			/// <summary>
			/// Камень по знаку зодиака
			/// </summary>
			[DisplayName("Камень")]
			[Description("Камень по знаку зодиака")]
			[Category(XInspectorGroupDesc.ID)]
			[LotusPropertyOrder(2)]
			[MaxLength(10)]
			public String? StoneZodiac
			{
				get { return (mStoneZodiac); }
				set
				{
					mStoneZodiac = value;
					NotifyPropertyChanged(PropertyArgsStoneZodiac);
				}
			}

			/// <summary>
			/// Дерево по знаку зодиака
			/// </summary>
			[DisplayName("Дерево")]
			[Description("Дерево по знаку зодиака")]
			[Category(XInspectorGroupDesc.ID)]
			[LotusPropertyOrder(2)]
			[MaxLength(10)]
			public String? TreeZodiac
			{
				get { return (mTreeZodiac); }
				set
				{
					mTreeZodiac = value;
					NotifyPropertyChanged(PropertyArgsTreeZodiac);
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
				get { return ("АСТРОЛОГИЯ"); }
			}

			/// <summary>
			/// Отображаемое имя объекта в инспекторе свойств
			/// </summary>
			[Browsable(false)]
			public String InspectorObjectName
			{
				get
				{
					return mZodiacSign ?? "Нет знака";
				}
			}
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор по умолчанию инициализирует объект класса предустановленными значениями
			/// </summary>
			//---------------------------------------------------------------------------------------------------------
			public CAstrologyInfo()
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
			public Int32 CompareTo(CAstrologyInfo? other)
			{
				if (other == null) return 0;

				if (mZodiacSign is not null)
				{
					return (mZodiacSign.CompareTo(other.ZodiacSign));
				}

				return 0;
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
