import { IRequest } from 'src/shared/request/Request';

/**
 * Класс для получения списка астрологических данных с учетом фильтрации и сортировки
 */
export interface IAstrologiesRequest extends IRequest 
{
  /**
   * Идентификатор сеттинга игры
   */
  campaignSettingId?: number;
}