
/**
 * Базовый класс для создания сохраняемого состояния персонажа
 */
export interface IPersonStateCreateRequest
{
  /**
   * Идентификатор персонажа
   */
  personId: string;

  /**
   * Идентификатор игры
   */
  gameId: string;
}