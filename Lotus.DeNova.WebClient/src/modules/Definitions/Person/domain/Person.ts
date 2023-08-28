/**
 * Класс персонажа
 */
export interface IPerson
{
  /**
   * Идентификатор персонажа
   */
  id: number;

  /**
   * Имя персонажа
   */
  name: string;

  /**
   * Идентификатор расы
   */
  raceId: number;

  /**
   * Идентификатор аватара
   */
  avatarId?: number;

  /**
   * Идентификатор информации о астрологических сведениях
   */
  astrologyId?: number;  
}