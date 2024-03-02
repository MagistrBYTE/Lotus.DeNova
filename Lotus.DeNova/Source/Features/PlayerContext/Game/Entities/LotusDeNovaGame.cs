#if USE_EFC
using Microsoft.EntityFrameworkCore;
#endif

using Lotus.Repository;

namespace Lotus.DeNova
{
    /**
     * \defgroup DeNovaGameContext Подсистема контекста игрока
     * \ingroup DeNova
     * \brief Подсистема контекста игрока.
     * @{
     */
    /// <summary>
    /// Класс для определения игры.
    /// </summary>
    public class Game : RepositoryEntityBase<Guid>
    {
        #region Const
        /// <summary>
        /// Имя таблицы.
        /// </summary>
        public const string TABLE_NAME = "Game";
        #endregion

        #region Models methods
        /// <summary>
        /// Конфигурирование модели для типа <see cref="Game"/>.
        /// </summary>
        /// <param name="modelBuilder">Интерфейс для построения моделей.</param>
        public static void ModelCreating(ModelBuilder modelBuilder)
        {
            // Определение для таблицы
            var model = modelBuilder.Entity<Game>();
            model.ToTable(TABLE_NAME, XDbConstants.SchemeName);

            model.SetDatesPolicy();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Идентификатор игрока.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Идентификатор сценария.
        /// </summary>
        public int ScenarioId { get; set; }

        /// <summary>
        /// Статус текущей(актуальной) игры.
        /// </summary>
        /// <remarks>
        /// Для каждого игрока может быть только одна актуальная игра.
        /// </remarks>
        public bool IsCurrent { get; set; }
        #endregion

        #region System methods
        /// <summary>
        /// Преобразование к текстовому представлению.
        /// </summary>
        /// <returns>Имя объекта.</returns>
        public override string ToString()
        {
            return ("Game");
        }
        #endregion
    }
    /**@}*/
}