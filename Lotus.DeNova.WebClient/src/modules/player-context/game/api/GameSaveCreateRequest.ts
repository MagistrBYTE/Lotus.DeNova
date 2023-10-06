/**
 * Класс для создания сохранения игры
 */
export interface IGameSaveCreateRequest 
{
  /**
   * Идентификатор игры
   */
  gameId: string;

  /**
   * Идентификатор сохранения
   */
  gameSaveId?: string;

  /**
   * Название сохранения
   */
  name?: string;
}