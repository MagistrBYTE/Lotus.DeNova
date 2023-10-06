import { IEntity } from 'src/shared/types/Entity';

export interface IAstrologyTypeRequest extends IEntity<number>
{
  /**
   * Идентификатор сеттинга игры
   */
  gameSettingTypeId?: number;

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