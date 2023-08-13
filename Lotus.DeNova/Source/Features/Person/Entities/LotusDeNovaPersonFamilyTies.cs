﻿//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема персонажа
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaPersonFamilyTies.cs
*		Класс для вспомогательной таблице хранения родственных связей.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 30.04.2023
//=====================================================================================================================
#if USE_EFC
using Microsoft.EntityFrameworkCore;
#endif
//---------------------------------------------------------------------------------------------------------------------
using Lotus.Core;
using System.ComponentModel.DataAnnotations.Schema;
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
		/// Класс для вспомогательной таблице хранения родственных связей
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class CFamilyTies : EntityDb<Guid>
		{
			#region ======================================= КОНСТАНТНЫЕ ДАННЫЕ ========================================
			/// <summary>
			/// Имя таблицы
			/// </summary>
			public const String TABLE_NAME = "PersonFamilyTies";
			#endregion

			#region ======================================= МЕТОДЫ ОПРЕДЕЛЕНИЯ МОДЕЛЕЙ ================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конфигурирование модели для типа <see cref="CFamilyTies"/>
			/// </summary>
			/// <param name="modelBuilder">Интерфейс для построения моделей</param>
			//---------------------------------------------------------------------------------------------------------
			public static void ModelCreating(ModelBuilder modelBuilder)
			{
				// Определение для таблицы
				var model = modelBuilder.Entity<CFamilyTies>();
				model.ToTable(TABLE_NAME, XDbConstants.SchemeName);
			}
			#endregion

			#region ======================================= СВОЙСТВА ==================================================
			/// <summary>
			/// Навигационное свойство для родителя персонажа
			/// </summary>
			[ForeignKey(nameof(ParentId))]
			public virtual CPerson Parent { get; set; } = null!;

			/// <summary>
			/// Внешний ключ для родителя персонажа
			/// </summary>
			public Guid ParentId { get; set; }

			/// <summary>
			/// Навигационное свойство для ребенка персонажа
			/// </summary>
			[ForeignKey(nameof(ChildId))]
			public virtual CPerson Child { get; set; } = null!;

			/// <summary>
			/// Внешний ключ для ребенка персонажа
			/// </summary>
			public Guid ChildId { get; set; }
			#endregion
		}
		//-------------------------------------------------------------------------------------------------------------
		/**@}*/
		//-------------------------------------------------------------------------------------------------------------
	}
}
//=====================================================================================================================
