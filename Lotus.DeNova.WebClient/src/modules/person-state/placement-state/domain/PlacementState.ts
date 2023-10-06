import { IPersonState } from 'src/modules/player-context/person';

/**
 * Класс для определения состояния местоположения персонажа
 */
export interface IPlacementState extends IPersonState
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