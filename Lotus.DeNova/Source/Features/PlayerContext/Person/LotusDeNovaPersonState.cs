using System.ComponentModel.DataAnnotations.Schema;

using Lotus.Core;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaPerson
	*@{*/
    /// <summary>
    /// Базовый класс для определения сохраняемого состояния персонажа.
    /// </summary>
    public abstract class PersonState : EntityDb<Guid>, ILotusGameEntitySaveable
    {
        #region Properties
        /// <summary>
        /// Идентификатор игры.
        /// </summary>
        public Guid GameId { get; set; }

        /// <summary>
        /// Идентификатор сохранения.
        /// </summary>
        public Guid? GameSaveId { get; set; }

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
    }
    /**@}*/
}