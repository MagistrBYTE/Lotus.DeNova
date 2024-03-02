namespace Lotus.DeNova
{
    /** \addtogroup DeNovaPlacementState
    *@{*/
    /// <summary>
    /// Класс для создания нового перемещения персонажа.
    /// </summary>
    public class PlacementStateCreateRequest : PersonStateCreateRequest
    {
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