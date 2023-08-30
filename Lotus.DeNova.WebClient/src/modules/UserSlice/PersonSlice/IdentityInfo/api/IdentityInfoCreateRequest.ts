/**
 * Класс для создания новых сведений о персонаже
 */
export interface IIdentityInfoCreateRequest
{
  /**
   * Идентификатор контекста игры
   */
  gameContextId: string;
  
  /**
   * Идентификатор персонажа
   */
  personId: string;

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