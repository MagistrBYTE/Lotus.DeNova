/**
 * Класс для создания нового персонажа
 */
export interface IPersonCreateRequest
{
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