namespace Lotus.DeNova.Test
{
    /// <summary>
    /// Параметры подключения к БД POstgres
    /// </summary>
    public class PostgresDbConnectionOptions
    {
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Порт
        /// </summary>
        public string Port { get; set; }

        /// <summary>
        /// Сервер
        /// </summary>
        public string Server { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public string UserId { get; set; }
    }
}