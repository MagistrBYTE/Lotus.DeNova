/**
 * Класс для определения аватара персонажа
 */
export interface IAvatarState
{
  /**
   * Идентификатор сущности
   */
  avatarStateId: string;
  
  /**
   * Идентификатор игры
   */
  gameId: string;
  
  /**
   * Идентификатор персонажа
   */
  personId: string;

  /**
   * Идентификатор изображения
   */
  imageId?: number;  

  /**
   * Дата начала
   */
  beginPeriod: Date;

  /**
   * Дата окончания 
   */
  endPeriod?: Date;  
}