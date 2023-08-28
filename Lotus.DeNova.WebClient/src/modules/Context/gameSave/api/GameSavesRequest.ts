import { IRequest } from 'src/shared/request/Request';

/**
 * Класс для получения списка сохранений контекста игры с учетом фильтрации и сортировки
 */
export interface IGameSavesRequest extends IRequest 
{
  /** 
   * Идентификатор контекста игры 
   */
  gameContextId: string;
}