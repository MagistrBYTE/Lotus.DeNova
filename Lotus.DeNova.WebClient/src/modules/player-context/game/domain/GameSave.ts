import { IEntity } from 'src/shared/types/Entity';

/** 
 * Класс для сохранения игры 
 */
export interface IGameSave extends IEntity<string>
{
  /** 
   * Идентификатор игры 
   */
  gameId: string;

  /** 
   * Название сохранения 
   */
  name: string;
}