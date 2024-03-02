using System.ComponentModel.DataAnnotations;

using Lotus.Repository;

#if USE_EFC
using Microsoft.EntityFrameworkCore;
#endif

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaGameContext
	*@{*/
    /// <summary>
    /// Класс для определения сохранения текущей игры.
    /// </summary>
    public class GameSave : RepositoryEntityBase<Guid>, IComparable<GameSave>
    {
        #region Const
        /// <summary>
        /// Имя таблицы.
        /// </summary>
        public const string TABLE_NAME = "GameSave";
        #endregion

        #region Models methods
        /// <summary>
        /// Конфигурирование модели для типа <see cref="GameSave"/>.
        /// </summary>
        /// <param name="modelBuilder">Интерфейс для построения моделей.</param>
        public static void ModelCreating(ModelBuilder modelBuilder)
        {
            // Определение для таблицы
            var model = modelBuilder.Entity<GameSave>();
            model.ToTable(TABLE_NAME, XDbConstants.SchemeName);

            model.SetDatesPolicy();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Идентификатор игры.
        /// </summary>
        public Guid GameId { get; set; }

        /// <summary>
        /// Название сохранения.
        /// </summary>
        [MaxLength(20)]
        public string Name { get; set; } = null!;
        #endregion

        #region System methods
        /// <summary>
        /// Сравнение объектов для упорядочивания.
        /// </summary>
        /// <param name="other">Сравниваемый объект.</param>
        /// <returns>Статус сравнения объектов.</returns>
        public int CompareTo(GameSave? other)
        {
            if (other == null) return 0;

            return Created.CompareTo(other.Created);
        }

        /// <summary>
        /// Преобразование к текстовому представлению.
        /// </summary>
        /// <returns>Имя объекта.</returns>
        public override string ToString()
        {
            return (Name);
        }
        #endregion
    }
    /**@}*/
}