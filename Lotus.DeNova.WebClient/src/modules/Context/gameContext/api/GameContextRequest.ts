
export interface IGameContextRequest
{
  /**
   * Идентификатор контекста игры
   */
  id: string;

  /**
   * Идентификатор игрока
   */
  userId: string;

  /**
   * Идентификатор сеттинга игры
   */
  campaignSettingId?: number;

  /**
   * Статус текущего(актуального) контекст игры
   * 
   * Для каждого игрока может быть только один актуальный контекст игры
   */
  isCurrent: boolean;

  /**
   * Название игры
   */
  name: string;
}