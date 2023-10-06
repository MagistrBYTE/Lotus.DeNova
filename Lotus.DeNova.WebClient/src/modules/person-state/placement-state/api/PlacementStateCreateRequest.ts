import { IPersonCreateRequest } from 'src/modules/player-context/person';

/**
 * Класс для создания нового перемещения персонажа
 */
export interface IPlacementStateCreateRequest extends IPersonCreateRequest
{
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