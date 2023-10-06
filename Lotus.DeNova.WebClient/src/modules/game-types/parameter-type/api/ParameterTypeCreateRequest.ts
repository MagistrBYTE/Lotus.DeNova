/**
 * ласс для создания нового параметра существа
 */
export interface IParameterTypeCreateRequest
{
  /**
   * Идентификатор сеттинга игры
   */
  gameSettingTypeId?: number;
  
  /**
   * Название параметра
   */
  name: string;
  
  /**
   * Название параметра для отображения
   */
  displayName?: string;

  /**
   * Дополнительная информация
   */
  additionalInfo?: string;  
}