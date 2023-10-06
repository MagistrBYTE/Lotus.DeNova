import { IRequest } from 'src/shared/types/Request';

/**
 * Класс для получения списка игр с учетом фильтрации и сортировки
 */
export interface IGamesRequest extends IRequest 
{
  /**
   * Идентификатор игрока
   */
  userId?: string;
}