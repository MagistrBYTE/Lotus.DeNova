/**
 * Класс для создания новой расы
 */
export interface IRaceCreateRequest
{
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