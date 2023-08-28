
export interface IAstrologyRequest
{
  /**
   * Идентификатор астрологических данных
   */
  id: number;  

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