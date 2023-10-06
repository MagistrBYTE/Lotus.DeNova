import { IPersonStateCreateRequest } from 'src/modules/player-context/person';

/**
 * Класс для создания новых сведений о персонаже
 */
export interface IIdentityStateCreateRequest extends IPersonStateCreateRequest
{
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