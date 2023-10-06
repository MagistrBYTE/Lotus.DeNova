import { IEntity } from 'src/shared/types/Entity';

/**
 * Класс для определения параметра существа
 */
export interface IParameterAspectType extends IEntity<number>
{
  /**
   * Идентификатор сеттинга игры
   */
  gameSettingTypeId?: number;

  /**
   * Идентификатор типа параметра
   */
  parameterTypeId: number;  
  
  /**
   * Название аспекта параметра
   */
  name: string;
  
  /**
   * Название аспекта параметра для отображения
   */
  displayName?: string;

  /**
   * Дополнительная информация
   */
  additionalInfo?: string;
}