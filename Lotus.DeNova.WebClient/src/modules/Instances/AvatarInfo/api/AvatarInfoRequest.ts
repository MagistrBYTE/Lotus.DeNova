
export interface IAvatarInfoRequest
{
  /**
   * Идентификатор сущности
   */
  avatarInfoId: string;
  
  /**
   * Идентификатор контекста игры
   */
  gameContextId: string;
  
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