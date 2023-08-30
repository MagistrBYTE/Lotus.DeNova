/**
 * Класс для создания новых астрологических данных
 */
export interface IAstrologyCreateRequest
{
  /**
   * Идентификатор сеттинга игры
   */
  campaignSettingId?: number;

  /**
   * Знак зодиака
   */
  zodiacSign?: string;

  /**
   * Камень по знаку зодиака
   */
  stoneZodiac?: string;

  /**
   * Дерево по знаку зодиака
   */
  treeZodiac?: string;
}