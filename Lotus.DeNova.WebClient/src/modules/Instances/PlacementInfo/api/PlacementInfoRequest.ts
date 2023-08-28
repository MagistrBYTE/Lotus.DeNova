
export interface IPlacementInfoRequest
{
  /**
   * Идентификатор сущности
   */
  placementInfoId: string;
  
  /**
   * Идентификатор контекста игры
   */
  gameContextId: string;
  
  /**
   * Идентификатор персонажа
   */
  personId: string;

  /**
   * Позиция персонажа по X
   */
  positionX: number;

  /**
   * Позиция персонажа по Y
   */
  positionY: number;

  /**
   * Позиция персонажа по Z
   */
  positionZ: number;
}