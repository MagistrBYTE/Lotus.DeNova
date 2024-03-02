namespace Lotus.DeNova
{
    /** \addtogroup DeNovaConstants
	*@{*/
    /// <summary>
    /// Константы для базы данных модуля игровой вселенной DeNova.
    /// </summary>
    public static class XDbConstants
    {
        /// <summary>
        /// Имя схемы модуля игровой вселенной DeNova.
        /// </summary>
        public const string SchemeName = "denova";

        /// <summary>
        /// Имя таблицы для хранения истории миграции.
        /// </summary>
        public const string MigrationHistoryTableName = "__EFIdentityMigrationHistory";

        /// <summary>
        /// Имя строки подключения в файле конфигурации.
        /// </summary>
        public const string ConnectingDenovaDb = "Denova";
    }
    /**@}*/
}