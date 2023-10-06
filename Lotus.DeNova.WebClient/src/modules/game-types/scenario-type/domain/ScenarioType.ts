import { IEntity } from 'src/shared/types/Entity';

/**
 * Класс для определения сценария игры
 */
export interface IScenarioType extends IEntity<number>
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