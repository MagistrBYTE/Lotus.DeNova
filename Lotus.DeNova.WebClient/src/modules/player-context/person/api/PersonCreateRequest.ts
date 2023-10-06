/**
 * Класс для создания нового персонажа
 */
export interface IPersonCreateRequest
{
  /**
   * Идентификатор игрока
   */
  userId: string;
    
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
   * Идентификатор данных по астрологии
   */
  astrologyId?: number;  
}