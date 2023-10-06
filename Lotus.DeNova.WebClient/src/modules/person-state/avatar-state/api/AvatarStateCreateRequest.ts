import { IPersonStateCreateRequest } from 'src/modules/player-context/person';

/**
 * Класс для создания нового аватара персонажа
 */
export interface IAvatarStateCreateRequest extends IPersonStateCreateRequest
{
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