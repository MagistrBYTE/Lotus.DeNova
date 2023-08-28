﻿//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема место жительства
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaAddressInfo.cs
*		Класс для определения информации об месте жительства.
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
		/**
         * \defgroup DeNovaAddressInfo Подсистема место жительства персонажа
         * \ingroup DeNova
         * \brief Подсистема место жительства персонажа.
         * @{
         */
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Класс для определения информации об месте жительства
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		[Serializable]
		public class AddressInfo : EntityDb<Guid>, IComparable<AddressInfo>,
			ILotusGameEntitySaveable, ILotusDuplicate<AddressInfo>
		{
			#region ======================================= КОНСТАНТНЫЕ ДАННЫЕ ========================================
			/// <summary>
			/// Имя таблицы
			/// </summary>
			public const String TABLE_NAME = "AddressInfo";
			#endregion

			#region ======================================= МЕТОДЫ ОПРЕДЕЛЕНИЯ МОДЕЛЕЙ ================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конфигурирование модели для типа <see cref="AddressInfo"/>
			/// </summary>
			/// <param name="modelBuilder">Интерфейс для построения моделей</param>
			//---------------------------------------------------------------------------------------------------------
			public static void ModelCreating(ModelBuilder modelBuilder)
			{
				// Определение для таблицы
				var model = modelBuilder.Entity<AddressInfo>();
				model.ToTable(TABLE_NAME, XDbConstants.SchemeName);
			}
			#endregion

			#region ======================================= СВОЙСТВА ==================================================
			/// <summary>
			/// Идентификатор сущности
			/// </summary>
			public Guid AddressInfoId { get; set; }

			/// <summary>
			/// Идентификатор контекста игры
			/// </summary>
			public Guid GameContextId { get; set; }

			/// <summary>
			/// Идентификатор сохранения
			/// </summary>
			public Guid? GameSaveId { get; set; }

			/// <summary>
			/// Дата начала
			/// </summary>
			public DateTime BeginPeriod { get; set; }

			/// <summary>
			/// Дата окончания
			/// </summary>
			public DateOnly? EndPeriod { get; set; }

			/// <summary>
			/// Идентификатор адреса
			/// </summary>
			public Int32? AddressId { get; set; }

			/// <summary>
			/// Навигационное свойство для адреса
			/// </summary>
			[ForeignKey(nameof(AddressId))]
			public virtual AddressElement? Address { get; set; }

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
			public Int32 CompareTo(AddressInfo? other)
			{
				if (other == null) return 0;
				return (BeginPeriod.CompareTo(other.EndPeriod));
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Преобразование к текстовому представлению
			/// </summary>
			/// <returns>Имя объекта</returns>
			//---------------------------------------------------------------------------------------------------------
			public override String ToString()
			{
				return (Address?.Name ?? String.Empty);
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
			public AddressInfo Duplicate(CParameters? parameters = null)
			{
				var entityCopy = new AddressInfo()
				{
					AddressInfoId = AddressInfoId,
					GameContextId = GameContextId,
					PersonId = PersonId,
					BeginPeriod = BeginPeriod,
					EndPeriod = EndPeriod,
					AddressId = AddressId
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
