import { IRequest } from 'src/shared/types/Request';

/**
 * Класс для получения списка данных по астрологии с учетом фильтрации и сортировки
 */
export interface IAstrologyTypesRequest extends IRequest 
{
  /**
   * Идентификатор сеттинга игры
   */
  gameSettingTypeId?: number;
}