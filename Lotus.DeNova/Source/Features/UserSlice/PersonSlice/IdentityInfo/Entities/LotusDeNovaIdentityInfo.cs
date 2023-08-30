//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема идентификации персонажа
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaIdentityInfo.cs
*		Класс для определения идентификационных сведений о персонаже.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 30.04.2023
//=====================================================================================================================
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
		/**
         * \defgroup DeNovaIdentityInfo Подсистема идентификации персонажа
         * \ingroup DeNova
         * \brief Подсистема идентификации персонажа.
         * @{
         */
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Класс для определения идентификационных сведений о персонаже
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class IdentityInfo : EntityDb<Guid>, IComparable<IdentityInfo>,
			ILotusGameEntitySaveable, ILotusDuplicate<IdentityInfo>
		{
			#region ======================================= КОНСТАНТНЫЕ ДАННЫЕ ========================================
			/// <summary>
			/// Имя таблицы
			/// </summary>
			public const String TABLE_NAME = "IdentityInfo";
			#endregion

			#region ======================================= МЕТОДЫ ОПРЕДЕЛЕНИЯ МОДЕЛЕЙ ================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конфигурирование модели для типа <see cref="IdentityInfo"/>
			/// </summary>
			/// <param name="modelBuilder">Интерфейс для построения моделей</param>
			//---------------------------------------------------------------------------------------------------------
			public static void ModelCreating(ModelBuilder modelBuilder)
			{
				// Определение для таблицы
				var model = modelBuilder.Entity<IdentityInfo>();
				model.ToTable(TABLE_NAME, XDbConstants.SchemeName);
			}
			#endregion

			#region ======================================= СВОЙСТВА ==================================================
			/// <summary>
			/// Идентификатор сущности
			/// </summary>
			public Guid IdentityInfoId { get; set; }

			/// <summary>
			/// Идентификатор контекста игры
			/// </summary>
			public Guid GameContextId { get; set; }

			/// <summary>
			/// Идентификатор сохранения
			/// </summary>
			public Guid? GameSaveId { get; set; }

			/// <summary>
			/// Имя персонажа
			/// </summary>
			[MaxLength(10)]
			public String Name { get; set; }

			/// <summary>
			/// Фамилия персонажа
			/// </summary>
			[MaxLength(20)]
			public String? Surname { get; set; }

			/// <summary>
			/// Отчество персонажа
			/// </summary>
			[MaxLength(20)]
			public String? FatherName { get; set; }

			/// <summary>
			/// Код персонажа
			/// </summary>
			[MaxLength(10)]
			public String? CodeID { get; set; }

			/// <summary>
			/// Дата начала
			/// </summary>
			public DateTime BeginPeriod { get; set; }

			/// <summary>
			/// Дата окончания
			/// </summary>
			public DateTime? EndPeriod { get; set; }

			/// <summary>
			/// Идентификатор персонажа
			/// </summary>
			public Int32 PersonId { get; set; }

			/// <summary>
			/// Навигационное свойство для персонажа
			/// </summary>
			[ForeignKey(nameof(PersonId))]
			public virtual Person Person { get; set; } = default!;
			#endregion

			#region ======================================= СИСТЕМНЫЕ МЕТОДЫ ==========================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Сравнение объектов для упорядочивания
			/// </summary>
			/// <param name="other">Сравниваемый объект</param>
			/// <returns>Статус сравнения объектов</returns>
			//---------------------------------------------------------------------------------------------------------
			public Int32 CompareTo(IdentityInfo? other)
			{
				if (other == null) return 0;
				return (BeginPeriod.CompareTo(other.BeginPeriod));
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Преобразование к текстовому представлению
			/// </summary>
			/// <returns>Имя объекта</returns>
			//---------------------------------------------------------------------------------------------------------
			public override String ToString()
			{
				return ($"{Name} {Surname}");
			}
			#endregion

			#region ======================================= МЕТОДЫ ILotusDuplicate ====================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение дубликата объекта
			/// </summary>
			/// <param name="parameters">Параметры дублирования объекта</param>
			/// <returns>Дубликат объекта</returns>
			//---------------------------------------------------------------------------------------------------------
			public IdentityInfo Duplicate(CParameters? parameters = null)
			{
				var entityCopy = new IdentityInfo()
				{
					IdentityInfoId = IdentityInfoId,
					GameContextId = GameContextId,
					PersonId = PersonId,
					BeginPeriod = BeginPeriod,
					EndPeriod = EndPeriod,
					Name = Name, 
					Surname = Surname,
					FatherName = FatherName,
					CodeID = CodeID,
				};

				return entityCopy;
			}
			#endregion
		}
		//-------------------------------------------------------------------------------------------------------------
		/**@}*/
		//-------------------------------------------------------------------------------------------------------------
	}
}
//=====================================================================================================================
