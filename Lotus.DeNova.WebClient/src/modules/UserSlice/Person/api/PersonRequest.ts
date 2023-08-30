
export interface IPersonRequest
{
  /**
   * Идентификатор игрока
   */
  userId: string;
    
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
   * Статус локального изображения для аватара
   */
  isLocalAvatar?: boolean;  

  /**
   * Идентификатор информации о астрологических сведениях
   */
  astrologyId?: number;  
}