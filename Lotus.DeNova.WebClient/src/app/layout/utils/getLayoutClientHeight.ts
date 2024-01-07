import { loadLayoutFromStorage } from './loadLayoutFromStorage';

/**
 * Получение рабочей высоты сайта 
 * @param delta Уменьшение к расчету
 * @returns 
 */
export const getLayoutClientHeight = (delta?: number):number =>
{
  const layoutState = loadLayoutFromStorage();
  const isFooter = layoutState.footer.isVisible && layoutState.footer.isVisibleUser;
  const isHeader = layoutState.header.isVisible && layoutState.header.isVisibleUser;

  let screenHeight = Math.min(screen.height, window.innerHeight);

  if(isHeader)
  {
    screenHeight -= layoutState.header.height;
  }

  if(isFooter)
  {
    screenHeight -= layoutState.footer.height;
  }
  
  if(delta)
  {
    screenHeight -= delta;
  }  

  return screenHeight;
}
