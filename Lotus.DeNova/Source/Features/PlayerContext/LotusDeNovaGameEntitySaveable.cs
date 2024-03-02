namespace Lotus.DeNova
{
    /** \addtogroup DeNovaGameContext
	*@{*/
    /// <summary>
    /// Интерфейс для сущностей которые поддерживают сохранение.
    /// </summary>
    public interface ILotusGameEntitySaveable
    {
        /// <summary>
        /// Идентификатор игры.
        /// </summary>
        public Guid GameId { get; set; }

        /// <summary>
        /// Идентификатор сохранения.
        /// </summary>
        public Guid? GameSaveId { get; set; }
    }
    /**@}*/
}