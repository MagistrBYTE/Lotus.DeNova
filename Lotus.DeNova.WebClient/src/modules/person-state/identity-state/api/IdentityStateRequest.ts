import { IPersonState } from 'src/modules/player-context/person';

export interface IIdentityStateRequest extends IPersonState
{
  /**
   * Идентификатор сущности
   */
  identityStateId: string;
  
  /**
   * Имя персонажа
   */
  name: string;

  /**
   * Фамилия персонажа
   */
  surname?: string;

  /**
   * Отчество персонажа
   */
  fatherName?: string;   

  /**
   * Дата начала
   */
  beginPeriod: Date;

  /**
   * Дата окончания 
   */
  endPeriod?: Date; 
}