import { IEntity } from 'src/shared/types/Entity';

export interface IRaceTypeRequest extends IEntity<number>
{
  /**
   * Идентификатор сеттинга игры
   */
  gameSettingTypeId?: number;
  
  /**
   * Название расы
   */
  name: string;
  
  /**
   * Название расы для отображения
   */
  displayName?: string;

  /**
   * Дополнительная информация
   */
  additionalInfo?: string;  
}