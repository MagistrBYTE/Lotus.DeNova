import { IRequest } from 'src/shared/request/Request';

/**
 * Класс для получения списка изображений с учетом фильтрации и сортировки
 */
export interface IImagesRequest extends IRequest 
{
  /**
   * Идентификатор сеттинга игры
   */
  campaignSettingId?: number;
}