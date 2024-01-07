/**
 * Визуальные настройки для каждого размера и ориентации устройства
 */
export interface IViewSettings
{
  /**
   * Высота загловка/шапка сайта
   */
  headerHeight: number;

  /**
  * Максимальная ширина левой панели
  */
  leftPanelWidthMax: number;

  /**
  * Минимальная ширина левой панели
  */
  leftPanelWidthMin: number; 

  /**
  * Максимальная ширина правой панели
  */
  rightPanelWidthMax: number;

  /**
  * Минимальная ширина правой панели
  */
  rightPanelWidthMin: number;   

  /**
   * Высота футера/подвал сайта
   */
  footerHeight: number; 
}

/**
 * Визуальные настройки для десктоп режима
 */
export const DesktopViewSettings:IViewSettings = 
{
  headerHeight: 64,
  leftPanelWidthMax: 240,
  leftPanelWidthMin: 60,
  rightPanelWidthMax: 240,
  rightPanelWidthMin: 60,
  footerHeight: 64
}

/**
 * Визуальные настройки для мобильного режима в портретной ориентации
 */
export const PortraitViewSettings:IViewSettings = 
{
  headerHeight: 56,
  leftPanelWidthMax: 240,
  leftPanelWidthMin: 60,
  rightPanelWidthMax: 240,
  rightPanelWidthMin: 60,
  footerHeight: 56
}

/**
 * Визуальные настройки для мобильного режима в альбомной ориентации
 */
export const LandscapeViewSettings:IViewSettings = 
{
  headerHeight: 56,
  leftPanelWidthMax: 240,
  leftPanelWidthMin: 120,
  rightPanelWidthMax: 240,
  rightPanelWidthMin: 80,
  footerHeight: 56
}

