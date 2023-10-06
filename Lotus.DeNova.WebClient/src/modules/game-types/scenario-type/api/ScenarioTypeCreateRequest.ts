/**
 * Класс для создания новой сценария
 */
export interface IScenarioTypeCreateRequest
{
  /**
   * Идентификатор сеттинга игры
   */
  gameSettingTypeId?: number;
  
  /**
   * Название сценария
   */
  name: string;
  
  /**
   * Название сценария для отображения
   */
  displayName?: string;

  /**
   * Дополнительная информация
   */
  additionalInfo?: string;  
}