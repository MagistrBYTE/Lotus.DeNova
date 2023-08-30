import { IRequest } from 'src/shared/request/Request';

/**
 * Класс для получения списка персонажей с учетом фильтрации и сортировки
 */
export interface IPersonsRequest extends IRequest 
{
  /**
   * Идентификатор игрока
   */
  userId?: string;
}