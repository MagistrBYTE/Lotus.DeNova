import { IPersonState } from 'src/modules/player-context/person';

export interface IAvatarStateRequest extends IPersonState
{
  /**
   * Идентификатор сущности
   */
  avatarStateId: string;
  
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