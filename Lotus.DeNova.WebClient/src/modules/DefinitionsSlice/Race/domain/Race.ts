/**
 * Класс расы
 */
export interface IRace
{
  /**
   * Идентификатор расы
   */
  id: number;  
  
  /**
   * Идентификатор сеттинга игры
   */
  campaignSettingId?: number;
  
  /**
   * Название расы
   */
  name: string;
  
  /**
   * Название расы для отображения
   */
  displayName?: string;
}