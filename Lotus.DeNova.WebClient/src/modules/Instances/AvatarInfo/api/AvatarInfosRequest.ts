import { IRequest } from 'src/shared/request/Request';

/**
 * Класс для получения списка аватаров персонажа с учетом фильтрации и сортировки
 */
export interface IAvatarInfosRequest extends IRequest 
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