import { IRequest } from 'src/shared/request/Request';

/**
 * Класс для получения списка мест жительства с учетом фильтрации и сортировки
 */
export interface IAddressInfosRequest extends IRequest 
{
  /**
   * Идентификатор контекста игры
   */
  gameContextId: string;
  
  /**
   * Идентификатор персонажа
   */
  personId: string;
}