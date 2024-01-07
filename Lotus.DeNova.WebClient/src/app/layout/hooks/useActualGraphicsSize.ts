import { useLayoutEffect, useState } from 'react';
import { IRectOffset, IRectSizeOffset } from 'src/shared/types/RectOffset';
import { getLayoutClientHeight } from '../utils/getLayoutClientHeight';
import { useLayoutState } from '../store/LayoutSelector';
import { TScreenType } from '../domain/ScreenType';

export const useActualGraphicsSize = (margin: IRectOffset = {left: 1, top: 1, right: 1, bottom: 1}):IRectSizeOffset =>
{
  const marginLeftDefault = margin.left;
  const marginTopDefault = margin.top;
  const marginRightDefault = margin.right;
  const marginBottomDefault = margin.bottom;
  
  const layoutState = useLayoutState();

  const calcHeight = ():number =>
  {
    const graphicsHeight = getLayoutClientHeight(marginTopDefault + marginBottomDefault);
    return graphicsHeight;
  }

  const calcWidth = ():number =>
  {
    let graphicsWidth = window.innerWidth - marginLeftDefault - marginRightDefault;

    if(layoutState.screenType === TScreenType.Landscape)
    {
      graphicsWidth -= layoutState.leftPanel.minWidth;
    }

    return graphicsWidth;
  }

  const calcMarginTop = ():number =>
  {
    if(layoutState.screenType !== TScreenType.Landscape)
    {
      return (marginTopDefault + layoutState.header.height);
    }

    return marginTopDefault;
  }

  const [width, setWidth] = useState(calcWidth());
  const [height, setHeight] = useState(calcHeight());
  const [marginTop, setMarginTop] = useState(calcMarginTop());

  const handleScreenResizeOrOrientation = () =>
  {
    setHeight(calcHeight());

    setWidth(calcWidth());

    setMarginTop(calcMarginTop());
  }

  useLayoutEffect(() => 
  {
    window.addEventListener('resize', handleScreenResizeOrOrientation);
    window.addEventListener('orientationchange', handleScreenResizeOrOrientation);

    handleScreenResizeOrOrientation();

    return () => 
    {
      window.removeEventListener('resize', handleScreenResizeOrOrientation);
      window.removeEventListener('orientationchange', handleScreenResizeOrOrientation);
    };
  }, [])

  return { left:marginLeftDefault, right:marginRightDefault, top:marginTop, bottom:marginBottomDefault, width:width, height:height};
}