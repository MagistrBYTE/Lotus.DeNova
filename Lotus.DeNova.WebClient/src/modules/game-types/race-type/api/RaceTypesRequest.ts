import { IRequest } from 'src/shared/types/Request';

/**
 * Класс для получения списка рас с учетом фильтрации и сортировки
 */
export interface IRaceTypesRequest extends IRequest 
{
  /**
   * Идентификатор сеттинга игры
   */
  gameSettingTypeId?: number;
}