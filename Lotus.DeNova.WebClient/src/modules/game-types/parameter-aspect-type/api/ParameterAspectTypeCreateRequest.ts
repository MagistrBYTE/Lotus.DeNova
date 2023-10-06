/**
 * ласс для создания нового параметра существа
 */
export interface IParameterAspectTypeCreateRequest
{
  /**
   * Идентификатор сеттинга игры
   */
  gameSettingTypeId?: number;

  /**
   * Идентификатор типа параметра
   */
  parameterTypeId: number;    
  
  /**
   * Название аспекта параметра
   */
  name: string;
  
  /**
   * Название аспекта параметра для отображения
   */
  displayName?: string;

  /**
   * Дополнительная информация
   */
  additionalInfo?: string;  
}