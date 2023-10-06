import { IRequest } from 'src/shared/types/Request';

/**
 * Класс для получения списка сценариев с учетом фильтрации и сортировки
 */
export interface IScenarioTypesRequest extends IRequest 
{
  /**
   * Идентификатор сеттинга игры
   */
  gameSettingTypeId?: number;
}