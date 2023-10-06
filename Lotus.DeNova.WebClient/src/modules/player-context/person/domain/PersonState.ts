import { IEntity } from 'src/shared/types/Entity';

/**
 * Базовый класс для определения сохраняемого состояния персонажа
 */
export interface IPersonState extends IEntity<string>
{
  /**
   * Идентификатор персонажа
   */
  personId: string;

  /**
   * Идентификатор игры
   */
  gameId: string;
  
  /**
   * Идентификатор сохранения
   */
  gameSaveId?: string;  
}