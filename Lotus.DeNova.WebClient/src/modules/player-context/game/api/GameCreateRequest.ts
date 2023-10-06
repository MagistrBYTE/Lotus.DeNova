/**
 * Класс для создания новой игры
 */
export interface IGameCreateRequest
{
  /**
   * Идентификатор игрока
   */
  userId: string;

  /**
   * Идентификатор сценария
   */
  scenarioId: number;
}