import { IEntity } from 'src/shared/types/Entity';

export interface IParameterTypeRequest extends IEntity<number>
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