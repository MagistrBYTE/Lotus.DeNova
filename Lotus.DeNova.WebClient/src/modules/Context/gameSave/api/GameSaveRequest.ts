
export interface IGameSaveRequest
{
  /**
   * Идентификатор сохранения
   */
  id: string;

  /** 
   * Идентификатор контекста игры 
   */
  gameContextId: string;

  /** 
   * Название сохранения 
   */
  name: string;
}