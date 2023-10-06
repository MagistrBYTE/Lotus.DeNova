import { IEntity } from 'src/shared/types/Entity';

export interface IScenarioTypeRequest extends IEntity<number>
{
  /**
   * Идентификатор сеттинга игры
   */
  gameSettingTypeId?: number;
  
  /**
   * Название сценария
   */
  name: string;
  
  /**
   * Название сценария для отображения
   */
  displayName?: string;

  /**
   * Дополнительная информация
   */
  additionalInfo?: string;  
}