import { IRequest } from 'src/shared/request/Request';

/**
 * Класс для получения списка рас с учетом фильтрации и сортировки
 */
export interface IRacesRequest extends IRequest 
{
  /**
   * Идентификатор сеттинга игры
   */
  campaignSettingId?: number;
}