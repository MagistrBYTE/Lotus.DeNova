﻿//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Константы
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaDbConstants.cs
*		Константы для базы данных аккаунта пользователя.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 30.04.2023
//=====================================================================================================================
using System;
//=====================================================================================================================
namespace Lotus
{
    namespace DeNova
    {
		//-------------------------------------------------------------------------------------------------------------
		/** \addtogroup DeNovaConstants
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Константы для базы данных модуля игровой вселенной DeNova
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public static class XDbConstants
        {
			/// <summary>
			/// Имя схемы модуля игровой вселенной DeNova
			/// </summary>
			public const String SchemeName = "denova";

            /// <summary>
            /// Имя таблицы для хранения истории миграции
            /// </summary>
            public const String MigrationHistoryTableName = "__EFIdentityMigrationHistory";

            /// <summary>
            /// Имя строки подключения в файле конфигурации
            /// </summary>
            public const String ConnectingDenovaDb = "Denova";
        }
        //-------------------------------------------------------------------------------------------------------------
        /**@}*/
        //-------------------------------------------------------------------------------------------------------------
    }
}
//=====================================================================================================================