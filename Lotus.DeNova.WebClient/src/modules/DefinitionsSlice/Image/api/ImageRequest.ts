
export interface IImageRequest
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
   * Данные изображения
   */
  dataImage?: any;
}