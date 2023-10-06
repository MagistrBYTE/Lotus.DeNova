import { IEntity } from 'src/shared/types/Entity';

/**
 * Класс для определения данных по астрологии
 */
export interface IAstrologyType extends IEntity<number>
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