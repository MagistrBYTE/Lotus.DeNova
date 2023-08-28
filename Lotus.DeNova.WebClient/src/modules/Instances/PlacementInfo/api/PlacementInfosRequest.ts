import { IRequest } from 'src/shared/request/Request';

/**
 * Класс для получения списка местоположений персонажа с учетом фильтрации и сортировки
 */
export interface IPlacementInfosRequest extends IRequest 
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