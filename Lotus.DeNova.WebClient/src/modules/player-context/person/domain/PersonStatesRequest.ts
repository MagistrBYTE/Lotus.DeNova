import { IRequest } from 'src/shared/types/Request';

/**
 * Базовый класс для получения состояний персонажа
 */
export interface IPersonStatesRequest extends IRequest
{
  /**
   * Идентификатор персонажа
   */
  personId: string;

  /**
   * Идентификатор игры
   */
  gameId: string;
}