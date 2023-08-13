//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема персонажа
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaPerson.cs
*		Класс для определения персонажа.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 30.04.2023
//=====================================================================================================================
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System;
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
         * \defgroup DeNovaPerson Подсистема персонажа
         * \ingroup DeNova
         * \brief Подсистема персонажа.
         * @{
         */
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Класс для определения персонажа
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		[Serializable]
		public class CPerson : EntityDbNotifyProperty<Guid>, IComparable<CPerson>, ILotusSupportViewInspector
		{
			#region ======================================= КОНСТАНТНЫЕ ДАННЫЕ ========================================
			/// <summary>
			/// Имя таблицы
			/// </summary>
			public const String TABLE_NAME = "Person";
			#endregion

			#region ======================================= СТАТИЧЕСКИЕ ДАННЫЕ ========================================
			//
			// Константы для информирования об изменении свойств
			//
			#endregion

			#region ======================================= МЕТОДЫ ОПРЕДЕЛЕНИЯ МОДЕЛЕЙ ================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конфигурирование модели для типа <see cref="CPerson"/>
			/// </summary>
			/// <param name="modelBuilder">Интерфейс для построения моделей</param>
			//---------------------------------------------------------------------------------------------------------
			public static void ModelCreating(ModelBuilder modelBuilder)
			{
				// Определение для таблицы
				var model = modelBuilder.Entity<CPerson>();
				model.ToTable(TABLE_NAME, XDbConstants.SchemeName);

				modelBuilder.Entity<CPerson>()
					.HasMany(p => p.Children)
					.WithOne()
					.HasForeignKey(p => p.Id);

				modelBuilder.Entity<CPerson>()
					.HasOne(p => p.Father)
					.WithMany()
					.HasForeignKey(p => p.FatherId);

				modelBuilder.Entity<CPerson>()
					.HasOne(p => p.Mother)
					.WithMany()
					.HasForeignKey(p => p.MotherId);
			}
			#endregion

			#region ======================================= СВОЙСТВА ==================================================
			/// <summary>
			/// Внешний ключ для рождения
			/// </summary>
			public Int32? BirthdayInfoId { get; set; }

			/// <summary>
			/// Навигационное свойство для рождения
			/// </summary>
			[ForeignKey(nameof(BirthdayInfoId))]
			public CBirthdayInfo? BirthdayInfo { get; set; }

			/// <summary>
			/// Внешний ключ для отца персонажа
			/// </summary>
			public Guid? FatherId { get; set; }

			/// <summary>
			/// Отец персонажа
			/// </summary>
			[ForeignKey(nameof(FatherId))]
			public CPerson? Father { get; set; }

			/// <summary>
			/// Внешний ключ для матери персонажа
			/// </summary>
			public Guid? MotherId { get; set; }

			/// <summary>
			/// Мать персонажа
			/// </summary>
			public CPerson? Mother { get; set; }

			/// <summary>
			/// Список детей персонажа
			/// </summary>
			public List<CPerson> Children { get; set; } = new List<CPerson>();

			/// <summary>
			/// Внешний ключ для астрологических сведений
			/// </summary>
			public Int32? AstrologyInfoId { get; set; }

			/// <summary>
			/// Навигационное свойство для астрологических сведений
			/// </summary>
			[ForeignKey(nameof(AstrologyInfoId))]
			public CAstrologyInfo? AstrologyInfo { get; set; }

			/// <summary>
			/// Список идентификационных сведений персонажа
			/// </summary>
			[Browsable(false)]
			public List<CIdentityInfo> IdentityInfos { get; set; } = new List<CIdentityInfo>();

			/// <summary>
			/// Список аватаров персонажа
			/// </summary>
			[Browsable(false)]
			public List<CAvatarInfo> AvatarInfos { get; set; } = new List<CAvatarInfo>();

			/// <summary>
			/// Список адресов пользователей
			/// </summary>
			[Browsable(false)]
			public List<CAddressInfo> AddressInfos { get; set; } = new List<CAddressInfo>();
			#endregion

			#region ======================================= СВОЙСТВА ILotusSupportViewInspector =======================
			/// <summary>
			/// Отображаемое имя типа в инспекторе свойств
			/// </summary>
			[Browsable(false)]
			public String InspectorTypeName
			{
				get { return ("ПЕРСОНАЖ"); }
			}

			/// <summary>
			/// Отображаемое имя объекта в инспекторе свойств
			/// </summary>
			[Browsable(false)]
			public String InspectorObjectName
			{
				get
				{
					return (String.Empty);
				}
			}
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор по умолчанию инициализирует объект класса предустановленными значениями
			/// </summary>
			//---------------------------------------------------------------------------------------------------------
			public CPerson()
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
			public Int32 CompareTo(CPerson? other)
			{
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
