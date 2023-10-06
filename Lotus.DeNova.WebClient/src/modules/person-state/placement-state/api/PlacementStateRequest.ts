import { IPersonState } from 'src/modules/player-context/person';

export interface IPlacementStateRequest extends IPersonState
{
  /**
   * Идентификатор сущности
   */
  placementStateId: string;
  
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