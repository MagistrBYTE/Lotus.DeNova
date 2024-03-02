using System.ComponentModel.DataAnnotations.Schema;

#if USE_EFC
using Microsoft.EntityFrameworkCore;
#endif

using Lotus.Core;

namespace Lotus.DeNova
{
    /**
     * \defgroup DeNovaAddressState Подсистема место жительства персонажа
     * \ingroup DeNova
     * \brief Подсистема место жительства персонажа.
     * @{
     */
    /// <summary>
    /// Класс для определения состояния об месте жительства.
    /// </summary>
    [Serializable]
    public class AddressState : PersonState, IComparable<AddressState>, ILotusDuplicate<AddressState>
    {
        #region Const
        /// <summary>
        /// Имя таблицы.
        /// </summary>
        public const string TABLE_NAME = "AddressState";
        #endregion

        #region Models methods
        /// <summary>
        /// Конфигурирование модели для типа <see cref="AddressState"/>.
        /// </summary>
        /// <param name="modelBuilder">Интерфейс для построения моделей.</param>
        public static void ModelCreating(ModelBuilder modelBuilder)
        {
            // Определение для таблицы
            var model = modelBuilder.Entity<AddressState>();
            model.ToTable(TABLE_NAME, XDbConstants.SchemeName);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Идентификатор сущности.
        /// </summary>
        public Guid AddressStateId { get; set; }

        /// <summary>
        /// Дата начала.
        /// </summary>
        public DateTime BeginPeriod { get; set; }

        /// <summary>
        /// Дата окончания.
        /// </summary>
        public DateTime? EndPeriod { get; set; }

        /// <summary>
        /// Идентификатор адреса.
        /// </summary>
        public int? AddressId { get; set; }

        /// <summary>
        /// Навигационное свойство для адреса.
        /// </summary>
        [ForeignKey(nameof(AddressId))]
        public virtual AddressElement? Address { get; set; }
        #endregion

        #region System methods
        /// <summary>
        /// Сравнение объектов для упорядочивания.
        /// </summary>
        /// <param name="other">Сравниваемый объект.</param>
        /// <returns>Статус сравнения объектов.</returns>
        public int CompareTo(AddressState? other)
        {
            if (other == null) return 0;
            return (BeginPeriod.CompareTo(other.EndPeriod));
        }

        /// <summary>
        /// Преобразование к текстовому представлению.
        /// </summary>
        /// <returns>Имя объекта.</returns>
        public override string ToString()
        {
            return (Address?.Name ?? string.Empty);
        }
        #endregion

        #region ILotusDuplicate methods
        /// <summary>
        /// Получение дубликата объекта.
        /// </summary>
        /// <param name="parameters">Параметры дублирования объекта.</param>
        /// <returns>Дубликат объекта.</returns>
        public AddressState Duplicate(CParameters? parameters = null)
        {
            var entityCopy = new AddressState()
            {
                AddressStateId = AddressStateId,
                GameId = GameId,
                PersonId = PersonId,
                BeginPeriod = BeginPeriod,
                EndPeriod = EndPeriod,
                AddressId = AddressId
            };

            return entityCopy;
        }
        #endregion
    }
    /**@}*/
}