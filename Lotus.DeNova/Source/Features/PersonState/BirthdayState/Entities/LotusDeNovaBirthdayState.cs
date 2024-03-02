using System.ComponentModel.DataAnnotations.Schema;

#if USE_EFC
using Microsoft.EntityFrameworkCore;
#endif

using Lotus.Core;

namespace Lotus.DeNova
{
    /**
     * \defgroup DeNovaBirthdayState Подсистема данных о рождении персонажа
     * \ingroup DeNova
     * \brief Подсистема данных о рождении персонажа.
     * @{
     */
    /// <summary>
    /// Класс для определения информации о рождении персонажа.
    /// </summary>
    public class BirthdayState : EntityDb<Guid>, IComparable<BirthdayState>
    {
        #region Const
        /// <summary>
        /// Имя таблицы.
        /// </summary>
        public const string TABLE_NAME = "BirthdayState";
        #endregion

        #region Models methods
        /// <summary>
        /// Конфигурирование модели для типа <see cref="BirthdayState"/>.
        /// </summary>
        /// <param name="modelBuilder">Интерфейс для построения моделей.</param>
        public static void ModelCreating(ModelBuilder modelBuilder)
        {
            // Определение для таблицы
            var model = modelBuilder.Entity<BirthdayState>();
            model.ToTable(TABLE_NAME, XDbConstants.SchemeName);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Идентификатор игры.
        /// </summary>
        public Guid GameId { get; set; }

        /// <summary>
        /// Дата рождения персонажа.
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Идентификатор адреса рождения персонажа.
        /// </summary>
        public int? AddressId { get; set; }

        /// <summary>
        /// Навигационное свойство адреса рождения персонажа.
        /// </summary>
        [ForeignKey(nameof(AddressId))]
        public virtual AddressElement? Address { get; set; }

        /// <summary>
        /// Идентификатор персонажа.
        /// </summary>
        public Guid PersonId { get; set; }

        /// <summary>
        /// Навигационное свойство для персонажа.
        /// </summary>
        [ForeignKey(nameof(PersonId))]
        public virtual Person Person { get; set; } = default!;
        #endregion

        #region System methods
        /// <summary>
        /// Сравнение объектов для упорядочивания.
        /// </summary>
        /// <param name="other">Сравниваемый объект.</param>
        /// <returns>Статус сравнения объектов.</returns>
        public int CompareTo(BirthdayState? other)
        {
            if (other == null) return 0;
            return (Birthday.CompareTo(other.Birthday));
        }

        /// <summary>
        /// Преобразование к текстовому представлению.
        /// </summary>
        /// <returns>Имя объекта.</returns>
        public override string ToString()
        {
            return (Birthday.ToLongDateString());
        }
        #endregion
    }
    /**@}*/
}