import { IPersonState } from 'src/modules/player-context/person';

/**
 * Класс для определения информации об месте жительства
 */
export interface IAddressState extends IPersonState
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