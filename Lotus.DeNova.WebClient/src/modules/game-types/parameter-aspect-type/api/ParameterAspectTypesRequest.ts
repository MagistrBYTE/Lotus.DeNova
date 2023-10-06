import { IRequest } from 'src/shared/types/Request';

/**
 * Класс для получения списка аспектов параметров существ с учетом фильтрации и сортировки
 */
export interface IParameterAspectTypesRequest extends IRequest 
{
  /**
   * Идентификатор сеттинга игры
   */
  gameSettingTypeId?: number;

  /**
   * Идентификатор типа параметра
   */
  parameterTypeId: number;    
}