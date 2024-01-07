import Phaser, { Game } from 'phaser'
import React, { useEffect, useLayoutEffect, useRef, useState } from 'react'
import { IRectOffset } from 'src/shared/types/RectOffset';
import { TScreenType, loadLayoutFromStorage } from 'src/app/layout';

export interface IPhaserGameComponentProps
{
  config: Phaser.Types.Core.GameConfig;
  onGameInit: (game: Phaser.Game)=>void;
  margin: IRectOffset;
}

export const PhaserGameComponent = (props: IPhaserGameComponentProps) => 
{
  const {config, onGameInit, margin} = props;

  const marginLeftDefault = margin.left;
  const marginTopDefault = margin.top;
  const marginRightDefault = margin.right;
  const marginBottomDefault = margin.bottom;

  const layoutState = loadLayoutFromStorage();
  const isFooter = layoutState.footer.isVisible && layoutState.footer.isVisibleUser;
  const isHeader = layoutState.header.isVisible && layoutState.header.isVisibleUser;

  const calcHeight = ():number =>
  {
    let graphicsHeight = Math.min(screen.height, window.innerHeight);

    if(isHeader)
    {
      graphicsHeight -= layoutState.header.height;
    }
  
    if(isFooter)
    {
      graphicsHeight -= layoutState.footer.height;
    }
    
    graphicsHeight -= (marginTopDefault + marginBottomDefault);

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
      if(isHeader)
      {
        return (marginTopDefault + layoutState.header.height);
      }
      else
      {
        return (marginTopDefault);
      }
    }

    return marginTopDefault;
  }

  const [width, setWidth] = useState(calcWidth());
  const [height, setHeight] = useState(calcHeight());
  const [marginTop, setMarginTop] = useState(calcMarginTop());
  const [game, setGame] = useState<Game>();
  const [isReady, setReady] = useState(false);

  const refContainer = useRef<HTMLDivElement|null>(null);

  const handleScreenResizeOrOrientation = () =>
  {
    setHeight(calcHeight());

    setWidth(calcWidth());

    setMarginTop(calcMarginTop());

    if(game)
    {
      game.destroy(false);
    }

    // Вручную удаляем все канвасы
    if(refContainer && refContainer.current)
    {
      const allCanvas = Array.from(refContainer.current.childNodes);
      allCanvas.forEach((canvas )=>
      {
        (canvas as HTMLElement).remove();
      })
    }


    const newGame = new Game({ ...config, width:calcWidth(), height:calcHeight(), parent: 'gameContainer' });

    onGameInit(newGame);

    setGame(newGame);
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

      game?.destroy(true);
      setReady(false);
    };
  }, [])

  // Return the host element where Phaser3 will append the canvas.
  return (<div ref={refContainer} id="gameContainer" style={{marginLeft:margin.left, marginTop:marginTop, width: width, height: height}}>
  </div>  
  );
}