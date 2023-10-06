import { IEntity } from 'src/shared/types/Entity';

/**
 * Класс игры
 */
export interface IGame extends IEntity<string>
{
  /**
   * Идентификатор игрока
   */
  userId: string;

  /**
   * Идентификатор сценария
   */
  scenarioId: number;

  /**
   * Статус текущего(актуального) контекст игры
   * 
   * Для каждого игрока может быть только один актуальный контекст игры
   */
  isCurrent: boolean;
}