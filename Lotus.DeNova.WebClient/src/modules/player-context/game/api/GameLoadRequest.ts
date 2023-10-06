
/**
 * Класс для загрузки сохранения игры
 */
export interface IGameLoadRequest
{
  /** 
   * Идентификатор игры 
   */
  gameId: string;
    
  /**
   * Идентификатор сохранения
   */
  gameSaveId: string;
}