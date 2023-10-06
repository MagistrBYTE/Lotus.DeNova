import { IEntity } from 'src/shared/types/Entity';

/**
 * Класс для определения параметра существа
 */
export interface IParameterType extends IEntity<number>
{
  /**
   * Идентификатор сеттинга игры
   */
  gameSettingTypeId?: number;
  
  /**
   * Название параметра
   */
  name: string;
  
  /**
   * Название параметра для отображения
   */
  displayName?: string;

  /**
   * Дополнительная информация
   */
  additionalInfo?: string;
}