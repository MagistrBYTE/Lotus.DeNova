using System.ComponentModel.DataAnnotations;

#if USE_EFC
using Microsoft.EntityFrameworkCore;
#endif

using Lotus.Core;

namespace Lotus.DeNova
{
    /**
     * \defgroup DeNovaIdentityState Подсистема идентификации персонажа
     * \ingroup DeNova
     * \brief Подсистема идентификации персонажа.
     * @{
     */
    /// <summary>
    /// Класс для определения состояния идентификационных сведений о персонаже.
    /// </summary>
    public class IdentityState : PersonState, IComparable<IdentityState>, ILotusDuplicate<IdentityState>
    {
        #region Const
        /// <summary>
        /// Имя таблицы.
        /// </summary>
        public const string TABLE_NAME = "IdentityState";
        #endregion

        #region Models methods
        /// <summary>
        /// Конфигурирование модели для типа <see cref="IdentityState"/>.
        /// </summary>
        /// <param name="modelBuilder">Интерфейс для построения моделей.</param>
        public static void ModelCreating(ModelBuilder modelBuilder)
        {
            // Определение для таблицы
            var model = modelBuilder.Entity<IdentityState>();
            model.ToTable(TABLE_NAME, XDbConstants.SchemeName);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Идентификатор сущности.
        /// </summary>
        public Guid IdentityStateId { get; set; }

        /// <summary>
        /// Имя персонажа.
        /// </summary>
        [MaxLength(10)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Фамилия персонажа.
        /// </summary>
        [MaxLength(20)]
        public string? Surname { get; set; }

        /// <summary>
        /// Отчество персонажа.
        /// </summary>
        [MaxLength(20)]
        public string? FatherName { get; set; }

        /// <summary>
        /// Код персонажа.
        /// </summary>
        [MaxLength(10)]
        public string? CodeID { get; set; }

        /// <summary>
        /// Дата начала.
        /// </summary>
        public DateTime BeginPeriod { get; set; }

        /// <summary>
        /// Дата окончания.
        /// </summary>
        public DateTime? EndPeriod { get; set; }
        #endregion

        #region System methods
        /// <summary>
        /// Сравнение объектов для упорядочивания.
        /// </summary>
        /// <param name="other">Сравниваемый объект.</param>
        /// <returns>Статус сравнения объектов.</returns>
        public int CompareTo(IdentityState? other)
        {
            if (other == null) return 0;
            return (BeginPeriod.CompareTo(other.BeginPeriod));
        }

        /// <summary>
        /// Преобразование к текстовому представлению.
        /// </summary>
        /// <returns>Имя объекта.</returns>
        public override string ToString()
        {
            return ($"{Name} {Surname}");
        }
        #endregion

        #region ILotusDuplicate methods
        /// <summary>
        /// Получение дубликата объекта.
        /// </summary>
        /// <param name="parameters">Параметры дублирования объекта.</param>
        /// <returns>Дубликат объекта.</returns>
        public IdentityState Duplicate(CParameters? parameters = null)
        {
            var entityCopy = new IdentityState()
            {
                IdentityStateId = IdentityStateId,
                GameId = GameId,
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
    /**@}*/
}