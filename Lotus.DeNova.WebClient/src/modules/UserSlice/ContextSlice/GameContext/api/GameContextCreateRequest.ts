/**
 * Класс для создания нового контекста игры
 */
export interface IGameContextCreateRequest
{
  /**
   * Идентификатор игрока
   */
  userId: string;

  /**
   * Идентификатор сеттинга игры
   */
  campaignSettingId?: number;

  /**
   * Название контекста игры
   */
  name: string;
}