/**
 * Класс для создания нового места жительства
 */
export interface IAddressInfoCreateRequest
{
  /**
   * Идентификатор контекста игры
   */
  gameContextId: number;
  
  /**
   * Идентификатор персонажа
   */
  personId: string;

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