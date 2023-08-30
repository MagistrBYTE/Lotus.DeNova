import { IRequest } from 'src/shared/request/Request';

/**
 * Класс для получения списка идентификационных сведений о персонаже с учетом фильтрации и сортировки
 */
export interface IIdentityInfosRequest extends IRequest 
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