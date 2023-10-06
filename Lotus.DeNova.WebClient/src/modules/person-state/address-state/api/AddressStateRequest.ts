import { IPersonState } from 'src/modules/player-context/person';

export interface IAddressStateRequest extends IPersonState
{
  /**
   * Идентификатор сущности
   */
  addressStateId: string;
  
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