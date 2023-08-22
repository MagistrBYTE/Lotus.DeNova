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
		public class Person : EntityDb<Guid>, IComparable<Person>
		{
			#region ======================================= КОНСТАНТНЫЕ ДАННЫЕ ========================================
			/// <summary>
			/// Имя таблицы
			/// </summary>
			public const String TABLE_NAME = "Person";
			#endregion

			#region ======================================= МЕТОДЫ ОПРЕДЕЛЕНИЯ МОДЕЛЕЙ ================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конфигурирование модели для типа <see cref="Person"/>
			/// </summary>
			/// <param name="modelBuilder">Интерфейс для построения моделей</param>
			//---------------------------------------------------------------------------------------------------------
			public static void ModelCreating(ModelBuilder modelBuilder)
			{
				// Определение для таблицы
				var model = modelBuilder.Entity<Person>();
				model.ToTable(TABLE_NAME, XDbConstants.SchemeName);

				modelBuilder.Entity<Person>()
					.HasMany(p => p.Children)
					.WithOne()
					.HasForeignKey(p => p.Id);

				modelBuilder.Entity<Person>()
					.HasOne(p => p.Father)
					.WithMany()
					.HasForeignKey(p => p.FatherId);

				modelBuilder.Entity<Person>()
					.HasOne(p => p.Mother)
					.WithMany()
					.HasForeignKey(p => p.MotherId);
			}
			#endregion

			#region ======================================= СВОЙСТВА ==================================================
			//
			// РОДСТВЕННЫЕ ОТНОШЕНИЯ
			//
			/// <summary>
			/// Идентификатор отца персонажа
			/// </summary>
			public Guid? FatherId { get; set; }

			/// <summary>
			/// Отец персонажа
			/// </summary>
			[ForeignKey(nameof(FatherId))]
			public Person? Father { get; set; }

			/// <summary>
			/// Идентификатор матери персонажа
			/// </summary>
			public Guid? MotherId { get; set; }

			/// <summary>
			/// Мать персонажа
			/// </summary>
			[ForeignKey(nameof(MotherId))]
			public Person? Mother { get; set; }

			/// <summary>
			/// Список детей персонажа
			/// </summary>
			public List<Person>? Children { get; set; }

			//
			// РОЖДЕНИЕ
			//
			/// <summary>
			/// Идентификатор информации о рождении
			/// </summary>
			public Guid? BirthdayInfoId { get; set; }

			/// <summary>
			/// Информация о рождении
			/// </summary>
			[ForeignKey(nameof(BirthdayInfoId))]
			public BirthdayInfo? BirthdayInfo { get; set; }

			/// <summary>
			/// Идентификатор расы
			/// </summary>
			public Int32? RaceId { get; set; }

			/// <summary>
			/// Раса
			/// </summary>
			[ForeignKey(nameof(RaceId))]
			public Race? Race { get; set; }

			/// <summary>
			/// Идентификатор информации о астрологических сведениях
			/// </summary>
			public Int32? AstrologyId { get; set; }

			/// <summary>
			/// Информация о астрологических сведениях
			/// </summary>
			[ForeignKey(nameof(AstrologyId))]
			public Astrology? Astrology { get; set; }

			//
			// ДИНАМИЧЕСКИЕ ДАННЫЕ
			//
			/// <summary>
			/// Список идентификационных сведений
			/// </summary>
			public List<IdentityInfo> IdentityInfos { get; set; } = new List<IdentityInfo>();

			/// <summary>
			/// Список аватаров
			/// </summary>
			public List<AvatarInfo> AvatarInfos { get; set; } = new List<AvatarInfo>();

			/// <summary>
			/// Список мест жительств
			/// </summary>
			public List<AddressInfo> AddressInfos { get; set; } = new List<AddressInfo>();
			#endregion

			#region ======================================= СИСТЕМНЫЕ МЕТОДЫ ==========================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Сравнение объектов для упорядочивания
			/// </summary>
			/// <param name="other">Сравниваемый объект</param>
			/// <returns>Статус сравнения объектов</returns>
			//---------------------------------------------------------------------------------------------------------
			public Int32 CompareTo(Person? other)
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
				var last = IdentityInfos.Last();
				if(last is not null)
				{
					return last.ToString();
				}
				return (Id.ToString());
			}
			#endregion
		}
		//-------------------------------------------------------------------------------------------------------------
		/**@}*/
		//-------------------------------------------------------------------------------------------------------------
	}
}
//=====================================================================================================================
