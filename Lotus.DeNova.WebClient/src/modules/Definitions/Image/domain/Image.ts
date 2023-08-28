/**
 * Класс изображения
 */
export interface IImage
{
  /**
   * Идентификатор сеттинга игры
   */
  campaignSettingId?: number;

  /**
   * Название изображения
   */
  name: string;

  /**
   * Статус локального изображения (которое храниться на клиенте)
   */
  isLocal: boolean;

  /**
   * Uri для загрузки изображения
   */
  loadPath?: string;

  /**
   * Ширина изображения в пикселях
   */
  width:number;

  /**
   * Высота изображения в пикселях
   */
  height:number;

  /**
   * Размер изображения в байтах
   */
  sizeInBytes:number;  

  /**
   * Данные изображения
   */
  dataImage?: any;
}