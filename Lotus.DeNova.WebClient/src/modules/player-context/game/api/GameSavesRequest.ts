import { IRequest } from 'src/shared/types/Request';

/**
 * Класс для получения списка сохранений игры с учетом фильтрации и сортировки
 */
export interface IGameSavesRequest extends IRequest 
{
  /** 
   * Идентификатор игры 
   */
  gameId: string;
}