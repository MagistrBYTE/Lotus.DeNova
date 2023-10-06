import { IRequest } from 'src/shared/types/Request';

/**
 * Класс для получения списка параметров существ с учетом фильтрации и сортировки
 */
export interface IParameterTypesRequest extends IRequest 
{
  /**
   * Идентификатор сеттинга игры
   */
  gameSettingTypeId?: number;
}