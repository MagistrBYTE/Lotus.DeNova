namespace Lotus.DeNova
{
    /** \addtogroup DeNovaPlacementState
    *@{*/
    /// <summary>
    /// Класс для определения местоположения персонажа.
    /// </summary>
    public class PlacementStateDto : PersonStateDto
    {
        /// <summary>
        /// Идентификатор сущности.
        /// </summary>
        public Guid PlacementStateId { get; set; }

        /// <summary>
        /// Позиция персонажа по X.
        /// </summary>
        public int PositionX { get; set; }

        /// <summary>
        /// Позиция персонажа по Y.
        /// </summary>
        public int PositionY { get; set; }

        /// <summary>
        /// Позиция персонажа по Z.
        /// </summary>
        public int PositionZ { get; set; }
    }
    /**@}*/
}