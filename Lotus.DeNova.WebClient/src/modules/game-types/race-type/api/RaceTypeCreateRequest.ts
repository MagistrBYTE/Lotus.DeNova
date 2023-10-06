/**
 * Класс для создания новой расы
 */
export interface IRaceTypeCreateRequest
{
  /**
   * Идентификатор сеттинга игры
   */
  gameSettingTypeId?: number;
  
  /**
   * Название расы
   */
  name: string;
  
  /**
   * Название расы для отображения
   */
  displayName?: string;

  /**
   * Дополнительная информация
   */
  additionalInfo?: string;  
}