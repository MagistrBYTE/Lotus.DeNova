import { IRequest } from 'src/shared/request/Request';

/**
 * Класс для получения списка контекстов игр с учетом фильтрации и сортировки
 */
export interface IGameContextsRequest extends IRequest 
{
  /**
   * Идентификатор игрока
   */
  userId?: string;
}