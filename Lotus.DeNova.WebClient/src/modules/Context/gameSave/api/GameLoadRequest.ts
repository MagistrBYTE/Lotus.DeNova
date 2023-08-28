
/**
 * Класс для загрузки сохранения контекста игры
 */
export interface IGameLoadRequest
{
  /**
   * Идентификатор сохранения
   */
  gameSaveId: string;

  /** 
   * Идентификатор контекста игры 
   */
  gameContextId: string;
}