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
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Lotus.Repository;
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

				model.HasOne(x => x.PhysicalStrength)
					.WithOne()
					.HasForeignKey<Person>(p => p.PhysicalStrengthId);

				model.HasOne(x => x.Dexterity)
					.WithOne()
					.HasForeignKey<Person>(p => p.DexterityId);

				model.HasOne(x => x.Endurance)
					.WithOne()
					.HasForeignKey<Person>(p => p.EnduranceId);

				model.HasOne(x => x.Physique)
					.WithOne()
					.HasForeignKey<Person>(p => p.PhysiqueId);



				model.HasOne(x => x.Perception)
					.WithOne()
					.HasForeignKey<Person>(p => p.PerceptionId);

				model.HasOne(x => x.Mind)
					.WithOne()
					.HasForeignKey<Person>(p => p.MindId);

				model.HasOne(x => x.Willpower)
					.WithOne()
					.HasForeignKey<Person>(p => p.WillpowerId);

				model.HasOne(x => x.Spirituality)
					.WithOne()
					.HasForeignKey<Person>(p => p.SpiritualityId);



				model.HasOne(x => x.Appearance)
					.WithOne()
					.HasForeignKey<Person>(p => p.AppearanceId);

				model.HasOne(x => x.Charisma)
					.WithOne()
					.HasForeignKey<Person>(p => p.CharismaId);

				model.HasOne(x => x.Influence)
					.WithOne()
					.HasForeignKey<Person>(p => p.InfluenceId);

				model.HasOne(x => x.Status)
					.WithOne()
					.HasForeignKey<Person>(p => p.StatusId);
			}
			#endregion

			#region ======================================= СВОЙСТВА ==================================================
			/// <summary>
			/// Идентификатор игрока
			/// </summary>
			public Guid UserId { get; set; }

			/// <summary>
			/// Имя персонажа
			/// </summary>
			[MaxLength(20)]
			public String Name { get; set; } = null!;

			/// <summary>
			/// Идентификатор аватара
			/// </summary>
			public Guid? AvatarId { get; set; }

			/// <summary>
			/// Навигационное свойство для аватара
			/// </summary>
			[ForeignKey(nameof(AvatarId))]
			public ResourceFile? Avatar { get; set; }

			/// <summary>
			/// Статус локального аватара
			/// </summary>
			[NotMapped]
			public Boolean IsLocalAvatar
			{
				get
				{
					if(Avatar == null) return false;
					return Avatar.StorageType == TResourceFileStorage.Local;
				}
			}

			/// <summary>
			/// Идентификатор расы
			/// </summary>
			public Int32 RaceTypeId { get; set; }

			/// <summary>
			/// Навигационное свойство для расы
			/// </summary>
			[ForeignKey(nameof(RaceTypeId))]
			public RaceType RaceType { get; set; } = null!;

			/// <summary>
			/// Идентификатор данных по астрологии
			/// </summary>
			public Int32? AstrologyTypeId { get; set; }

			/// <summary>
			/// Навигационное свойство данных по астрологии
			/// </summary>
			[ForeignKey(nameof(AstrologyTypeId))]
			public AstrologyType? AstrologyType { get; set; }

			//
			// ПАРАМЕТРЫ ПЕРСОНАЖА
			//
			/// <summary>
			/// Идентификатор параметра Физическая сила
			/// </summary>
			public Guid PhysicalStrengthId { get; set; }

			/// <summary>
			/// Навигационное свойство параметра Физическая сила
			/// </summary>
			[ForeignKey(nameof(PhysicalStrengthId))]
			public PersonParameter PhysicalStrength { get; set; }

			/// <summary>
			/// Идентификатор параметра Ловкость
			/// </summary>
			public Guid DexterityId { get; set; }

			/// <summary>
			/// Навигационное свойство параметра Ловкость
			/// </summary>
			[ForeignKey(nameof(DexterityId))]
			public PersonParameter Dexterity { get; set; }

			/// <summary>
			/// Идентификатор параметра Выносливость
			/// </summary>
			public Guid EnduranceId { get; set; }

			/// <summary>
			/// Навигационное свойство параметра Выносливость
			/// </summary>
			[ForeignKey(nameof(EnduranceId))]
			public PersonParameter Endurance { get; set; }

			/// <summary>
			/// Идентификатор параметра Телосложение
			/// </summary>
			public Guid PhysiqueId { get; set; }

			/// <summary>
			/// Навигационное свойство параметра Телосложение
			/// </summary>
			[ForeignKey(nameof(PhysiqueId))]
			public PersonParameter Physique { get; set; }

			/// <summary>
			/// Идентификатор параметра Восприятие
			/// </summary>
			public Guid PerceptionId { get; set; }

			/// <summary>
			/// Навигационное свойство параметра Восприятие
			/// </summary>
			[ForeignKey(nameof(PerceptionId))]
			public PersonParameter Perception { get; set; }

			/// <summary>
			/// Идентификатор параметра Разум
			/// </summary>
			public Guid MindId { get; set; }

			/// <summary>
			/// Навигационное свойство параметра Разум
			/// </summary>
			[ForeignKey(nameof(MindId))]
			public PersonParameter Mind { get; set; }

			/// <summary>
			/// Идентификатор параметра Сила воли
			/// </summary>
			public Guid WillpowerId { get; set; }

			/// <summary>
			/// Навигационное свойство параметра Сила воли
			/// </summary>
			[ForeignKey(nameof(WillpowerId))]
			public PersonParameter Willpower { get; set; }

			/// <summary>
			/// Идентификатор параметра Духовность
			/// </summary>
			public Guid SpiritualityId { get; set; }

			/// <summary>
			/// Навигационное свойство параметра Духовность
			/// </summary>
			[ForeignKey(nameof(SpiritualityId))]
			public PersonParameter Spirituality { get; set; }

			/// <summary>
			/// Идентификатор параметра Внешность
			/// </summary>
			public Guid AppearanceId { get; set; }

			/// <summary>
			/// Навигационное свойство параметра Внешность
			/// </summary>
			[ForeignKey(nameof(AppearanceId))]
			public PersonParameter Appearance { get; set; }

			/// <summary>
			/// Идентификатор параметра Харизма
			/// </summary>
			public Guid CharismaId { get; set; }

			/// <summary>
			/// Навигационное свойство параметра Харизма
			/// </summary>
			[ForeignKey(nameof(CharismaId))]
			public PersonParameter Charisma { get; set; }

			/// <summary>
			/// Идентификатор параметра Влияние
			/// </summary>
			public Guid InfluenceId { get; set; }

			/// <summary>
			/// Навигационное свойство параметра Влияние
			/// </summary>
			[ForeignKey(nameof(InfluenceId))]
			public PersonParameter Influence { get; set; }

			/// <summary>
			/// Идентификатор параметра Статус
			/// </summary>
			public Guid StatusId { get; set; }

			/// <summary>
			/// Навигационное свойство параметра Статус
			/// </summary>
			[ForeignKey(nameof(StatusId))]
			public PersonParameter Status { get; set; }
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует данные списка предустановленными данными
			/// </summary>
			//---------------------------------------------------------------------------------------------------------
			public Person()
			{
				Id = Guid.NewGuid();

				PhysicalStrength = new PersonParameter(XParameterTypeConstants.PhysicalStrength.Id);
				PhysicalStrengthId = PhysicalStrength.Id;

				Dexterity = new PersonParameter(XParameterTypeConstants.Dexterity.Id);
				DexterityId = Dexterity.Id;
				
				Endurance = new PersonParameter(XParameterTypeConstants.Endurance.Id);
				EnduranceId = Endurance.Id;

				Physique = new PersonParameter(XParameterTypeConstants.Physique.Id);
				PhysiqueId = Physique.Id;

				Perception = new PersonParameter(XParameterTypeConstants.Perception.Id);
				PerceptionId = Perception.Id;

				Mind = new PersonParameter(XParameterTypeConstants.Mind.Id);
				MindId = Mind.Id;

				Willpower = new PersonParameter(XParameterTypeConstants.Willpower.Id);
				WillpowerId = Willpower.Id;

				Spirituality = new PersonParameter(XParameterTypeConstants.Spirituality.Id);
				SpiritualityId = Spirituality.Id;

				Appearance = new PersonParameter(XParameterTypeConstants.Appearance.Id);
				AppearanceId = Appearance.Id;

				Charisma = new PersonParameter(XParameterTypeConstants.Charisma.Id);
				CharismaId = Charisma.Id;

				Influence = new PersonParameter(XParameterTypeConstants.Influence.Id);
				InfluenceId = Influence.Id;

				Status = new PersonParameter(XParameterTypeConstants.Status.Id);
				StatusId = Status.Id;
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
				return (Name);
			}
			#endregion

			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Установка идентификатор персонажа для всех зависимых сущностей
			/// </summary>
			//---------------------------------------------------------------------------------------------------------
			public void SetPersonId()
			{
				PhysicalStrength.PersonId = Id;
				Dexterity.PersonId = Id;
				Endurance.PersonId = Id;
				Physique.PersonId = Id;

				Perception.PersonId = Id;
				Mind.PersonId = Id;
				Willpower.PersonId = Id;
				Spirituality.PersonId = Id;

				Appearance.PersonId = Id;
				Charisma.PersonId = Id;
				Influence.PersonId = Id;
				Status.PersonId = Id;
			}
			#endregion
		}
		//-------------------------------------------------------------------------------------------------------------
		/**@}*/
		//-------------------------------------------------------------------------------------------------------------
	}
}
//=====================================================================================================================
