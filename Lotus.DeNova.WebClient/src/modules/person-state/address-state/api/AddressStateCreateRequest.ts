import { IPersonStateCreateRequest } from 'src/modules/player-context/person';

/**
 * Класс для создания нового места жительства
 */
export interface IAddressStateCreateRequest extends IPersonStateCreateRequest
{
  /**
   * Идентификатор адреса
   */
  addressId?: number;  

  /**
   * Дата начала
   */
  beginPeriod: Date;

  /**
   * Дата окончания 
   */
  endPeriod?: Date;  
}