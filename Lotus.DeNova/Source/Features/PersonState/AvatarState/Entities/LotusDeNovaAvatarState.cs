using System.ComponentModel.DataAnnotations.Schema;

#if USE_EFC
using Microsoft.EntityFrameworkCore;
#endif

using Lotus.Core;
using Lotus.Repository;

namespace Lotus.DeNova
{
    /**
     * \defgroup DeNovaAvatarState Подсистема аватара персонажа
     * \ingroup DeNova
     * \brief Подсистема аватара персонажа.
     * @{
     */
    /// <summary>
    /// Класс для определения состояния аватара персонажа.
    /// </summary>
    [Serializable]
    public class AvatarState : PersonState, IComparable<AvatarState>, ILotusDuplicate<AvatarState>
    {
        #region Const
        /// <summary>
        /// Имя таблицы.
        /// </summary>
        public const string TABLE_NAME = "AvatarState";
        #endregion

        #region Models methods
        /// <summary>
        /// Конфигурирование модели для типа <see cref="AvatarState"/>.
        /// </summary>
        /// <param name="modelBuilder">Интерфейс для построения моделей.</param>
        public static void ModelCreating(ModelBuilder modelBuilder)
        {
            // Определение для таблицы
            var model = modelBuilder.Entity<AvatarState>();
            model.ToTable(TABLE_NAME, XDbConstants.SchemeName);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Идентификатор сущности.
        /// </summary>
        public Guid AvatarStateId { get; set; }

        /// <summary>
        /// Идентификатор изображения.
        /// </summary>
        public Guid? ImageId { get; set; }

        /// <summary>
        /// Навигационное свойство для изображения.
        /// </summary>
        [ForeignKey(nameof(ImageId))]
        public virtual ResourceFile? Image { get; set; }

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
        public int CompareTo(AvatarState? other)
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
            return (Image?.Name ?? "Пустое");
        }
        #endregion

        #region ILotusDuplicate methods
        /// <summary>
        /// Получение дубликата объекта.
        /// </summary>
        /// <param name="parameters">Параметры дублирования объекта.</param>
        /// <returns>Дубликат объекта.</returns>
        public AvatarState Duplicate(CParameters? parameters = null)
        {
            var entityCopy = new AvatarState()
            {
                AvatarStateId = AvatarStateId,
                GameId = GameId,
                PersonId = PersonId,
                BeginPeriod = BeginPeriod,
                EndPeriod = EndPeriod,
                ImageId = ImageId
            };

            return entityCopy;
        }
        #endregion
    }
    /**@}*/
}