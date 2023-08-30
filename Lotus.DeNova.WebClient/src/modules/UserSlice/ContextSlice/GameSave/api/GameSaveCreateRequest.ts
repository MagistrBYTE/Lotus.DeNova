/**
 * Интерфейс для создания сохранения контекста игры
 */
export interface IGameSaveCreateRequest 
{
  /**
   * Идентификатор контекста игры
   */
  gameContextId: string;

  /**
   * Идентификатор сохранения
   */
  gameSaveId?: string;

  /**
   * Название сохранения
   */
  name?: string;
}