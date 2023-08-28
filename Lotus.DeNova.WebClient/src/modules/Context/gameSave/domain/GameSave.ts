/** 
 * Класс для сохранения контекста игры 
 */
export interface IGameSave
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