import { useTheme } from '@mui/material';
import { KonvaEventObject } from 'konva/lib/Node';
import React, { ChangeEvent, useRef, useState } from 'react';
import { Stage, Layer, Shape } from 'react-konva';
import { SyntheticEvent } from 'react-toastify/dist/utils';
import { useAppDispatch } from 'src/app/store';
import { Vector2 } from 'src/libs/Math';
import { Hex, IHex } from 'src/libs/Hexagons/Hex';
import { HexLayout, HexOrientation } from 'src/libs/Hexagons/HexLayout';
import { HexMap, THexMapForm } from 'src/libs/Hexagons/HexMap';
import { drawHex, drawHexField, drawHexImage } from 'src/libs/Hexagons/HexUtils';
import useImage from 'use-image';
import { useLayoutState, getLayoutClientHeight, TScreenType } from 'src/app/layout';
import { useInterval } from 'src/shared/hooks/useInterval';
import { useScreenResizeOrOrientation } from 'src/shared/hooks/useScreenTypeChanged';

export const MapPage: React.FC = () => 
{
  const marginLeftDefault = 4;
  const marginTopDefault = 4;
  const marginRightDefault = 4;
  const marginBottomDefault = 4;

  const borderWidth = 2;
  const borderColor = 'red';

  const theme = useTheme();
  const layoutState = useLayoutState();
  const dispatch = useAppDispatch();

  const [marginLeft, setMarginLeft] = useState(marginLeftDefault);
  const [marginTop, setMarginTop] = useState(marginTopDefault);
  const [marginRight, setMarginRight] = useState(marginRightDefault);
  const [marginBottom, setMarginBottom] = useState(marginBottomDefault);

  const [fieldWidth, setFieldWidth] = useState(0);
  const [fieldHeight, setFieldHeight] = useState(0);

  const [flatMap, setFlatMap] = useState(false);
  const [sizeHex, setSizeHex] = useState(32);

  const [overHex, setOverHex] = useState<IHex|null>(null);
  const [positionCursors, setPositionCursors] = useState('');

  const [personHex, setPersonHex] = useState<IHex|null>({q:3, r:2, s:-5});
  const [selectedPerson, setSelectedPerson] = useState(false);

  const [targetHex, setTargetHex] = useState<IHex|null>(null);
  const [pathTraget, setPathTraget] = useState<IHex[]|null>(null);
  const [currentPathIndex, setCurrentPathIndex] = useState(0);

  // set crossOrigin of image as second argument, set referrerpolicy as third argument
  const url = '/images/hex/Person/Smile.png';
  const url1 = 'data:image/gif;base64,R0lGODlhCwALAIAAAAAA3pn/ZiH5BAEAAAEALAAAAAALAAsAAAIUhA+hkcuO4lmNVindo7qyrIXiGBYAOw==';
  const [image, status] = useImage(url, 'anonymous', 'origin');

  const countX = 10; // Math.floor(width / (size*1.5));
  const countY = 10; // Math.floor(height / (size*2));

  const startX = 0;
  const startY = 0;

  const orientation:HexOrientation = flatMap ? HexOrientation.Flat : HexOrientation.Pointy;

  const map: HexMap = new HexMap(THexMapForm.Parallelograms, orientation, countX, countY);

  const layout: HexLayout = new HexLayout(orientation, new Vector2(sizeHex, sizeHex), new Vector2(startX, startY));

  const handleScreenChange = ()=>
  {
    const mapHeight = getLayoutClientHeight(marginTopDefault + marginBottomDefault + borderWidth * 2);

    setFieldHeight(mapHeight);

    let mapWidth = window.innerWidth - marginLeft - marginRight - borderWidth * 2;

    if(layoutState.screenType === TScreenType.Landscape)
    {
      mapWidth -= layoutState.leftPanel.minWidth;
    }

    setFieldWidth(mapWidth);

    if(layoutState.screenType !== TScreenType.Landscape)
    {
      setMarginTop(marginTopDefault + layoutState.header.height);
    }
  }

  const handleFlatMap = (event: ChangeEvent<HTMLInputElement>) =>
  {
    setFlatMap(event.target.checked);
  }

  const handleSizeHex = (event: ChangeEvent<HTMLInputElement>) =>
  {
    setSizeHex(event.target.valueAsNumber);
  }

  const handleMouseMoveCanvas = (event: KonvaEventObject<MouseEvent>) =>
  {
    const x =  event.evt.offsetX;
    const y =  event.evt.offsetY;
    const hex = layout.pixelToHex(new Vector2(x, y));
    const roundHex = hex.round();
    setOverHex(roundHex);

    setPositionCursors(`x: ${x}; y: ${y}`);
  }

  const handlePointerDownCanvas = (event: KonvaEventObject<MouseEvent>) =>
  {
    const x =  event.evt.offsetX;
    const y =  event.evt.offsetY;
    const hex = layout.pixelToHex(new Vector2(x, y));
    const roundHex = hex.round();
    setTargetHex(roundHex);

    if(personHex)
    {
      const path = new Hex(personHex.q, personHex.r, personHex.s).lineDraw(roundHex);
      setPathTraget(path);
      setCurrentPathIndex(0);
    }
  }  

  const elementRef = useRef(null);

  const toggleFullScreen = () => 
  {
    if (!document.fullscreenElement) 
    {
      const elem:Element = elementRef!.current!;
      elem.requestFullscreen();
    } 
    else 
    {
      if (document.exitFullscreen) 
      {
        document.exitFullscreen();
      }
    }
  };

  //
  // Методы жизненного цикла
  //
  useScreenResizeOrOrientation(handleScreenChange);

  useInterval(()=>
  {
    if(targetHex && pathTraget && currentPathIndex < pathTraget.length)
    {
      setPersonHex(pathTraget[currentPathIndex]);
      setCurrentPathIndex(currentPathIndex+1);
    }
  }, 500);
 
  return (<div ref={elementRef}>
    <Stage style={{backgroundColor: 'lightgray', 
      marginTop: `${marginTop}px`, 
      marginLeft: `${marginLeft}px`, 
      marginRight: `${marginRight}px`,
      marginBottom: `${marginBottom}px`,
      borderColor: `${borderColor}`, borderWidth: `${borderWidth}px`, borderStyle: 'solid'}} 
    width={fieldWidth} 
    height={fieldHeight}
    onPointerDown={handlePointerDownCanvas}
    onMouseMove={handleMouseMoveCanvas}>
      <Layer>
        <Shape
          sceneFunc={(context, shape) => 
          {
            for (let index = 0; index < map.hexs.length; index++) 
            {
              const hex = map.hexs[index];
              drawHex(context, 'black', layout, hex);
            }
            if(overHex != null)
            {
              // drawHex(context, 'red', layout, overHex);
            }
            if(personHex && status === 'loaded')
            {
              drawHexImage(context, 'blue', image!, layout, personHex);
            }
            if(targetHex)
            {
              drawHex(context, 'red', layout, targetHex);
            }            
          }}
          fill="#00D2FF"
          stroke="black"
        />
      </Layer>
    </Stage>
    <input style={{position: 'absolute', zIndex: 1, top: fieldHeight - 20, left: 100}} onChange={handleFlatMap} checked={flatMap} type='checkbox'>
    </input>
    <input style={{position: 'absolute', zIndex: 1, top: fieldHeight - 20, left: 140}} onChange={handleSizeHex} min={10} max={64} value={sizeHex} type='range'>
    </input>
    <span style={{position: 'absolute', zIndex: 1, top: fieldHeight - 20, left: 300}}>{positionCursors}</span>

    <button style={{position: 'absolute', zIndex: 1, top: fieldHeight - 20, left: 380, width: 120}} onClick={toggleFullScreen}>
      {document.fullscreenElement ? 'Exit Fullscreen' : 'Fullscreen'}
    </button >
  </div>
  );
};
