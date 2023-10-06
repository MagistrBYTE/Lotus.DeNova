import { IPersonState } from 'src/modules/player-context/person';

/**
 * Класс для определения идентификационных сведений о персонаже
 */
export interface IIdentityState extends IPersonState
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