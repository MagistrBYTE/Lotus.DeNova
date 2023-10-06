import { IEntity } from 'src/shared/types/Entity';

export interface IGameSaveRequest extends IEntity<string>
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