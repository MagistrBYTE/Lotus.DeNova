import { useTheme } from '@mui/material';
import { KonvaEventObject } from 'konva/lib/Node';
import React, { useEffect, useLayoutEffect, useRef, useState } from 'react';
import { Stage, Layer, Shape } from 'react-konva';
import { useAppDispatch } from 'src/app/store';
import Vector2 from 'src/libs/Math/Vector2';
import { hex_corner } from 'src/libs/hexagons/Hex';
import { TScreenType, getLayoutClientHeight, useLayoutState } from 'src/shared/layout';

export const MapPage: React.FC = () => 
{
  const marginLeftDefault = 4;
  const marginTopDefault = 4;
  const marginRightDefault = 4;
  const marginBottomDefault = 4;

  const theme = useTheme();
  const layoutState = useLayoutState();
  const dispatch = useAppDispatch();

  const canvasRef = useRef(null);

  const [marginLeft, setMarginLeft] = useState(marginLeftDefault);
  const [marginTop, setMarginTop] = useState(marginTopDefault);
  const [marginRight, setMarginRight] = useState(marginRightDefault);
  const [marginBottom, setMarginBottom] = useState(marginBottomDefault);

  const [fieldWidth, setFieldWidth] = useState(0);
  const [fieldHeight, setFieldHeight] = useState(0);



  // @ts-ignore
  // console.log(`window.innerHeight = ${window.innerHeight}`);
  // console.log(`screen.height = ${screen.height}`);
  // console.log(`mapHeight = ${mapHeight}`);

  const handleMouseEnter = (evt: KonvaEventObject<MouseEvent>) =>
  {
    console.log(evt);
    // setColorHex('red');
  }

  const handleMouseLeave = (evt: KonvaEventObject<MouseEvent>) =>
  {
    console.log(evt);
    // setColorHex('#00D2FF');
  }

  // const [hex, setHex] = useState<Hex>({q: 1, r: 1, s: 1});

  const center:Vector2 = new Vector2([300, 300]);
  const size:number = 32;

  const handleScreenChange = ()=>
  {
    const mapHeight = getLayoutClientHeight(marginTopDefault + marginBottomDefault + 1 + 1);

    console.log(`window.innerHeight = ${window.innerHeight}`);
    console.log(`mapHeight = ${mapHeight}`);

    setFieldHeight(mapHeight);

    let mapWidth = window.innerWidth -  marginLeft - marginRight;

    if(layoutState.screenType === TScreenType.Landscape)
    {
      mapWidth -= layoutState.leftPanel.minWidth;
    }

    setFieldWidth(mapWidth);

    if(layoutState.screenType === TScreenType.Desktop)
    {
      setMarginTop(marginTopDefault + layoutState.header.height);
    }
  }  

  //
  // Методы жизненного цикла
  //

  useLayoutEffect(() => 
  {
    window.addEventListener('resize', handleScreenChange);
    window.addEventListener('orientationchange', handleScreenChange);

    handleScreenChange();

    return () => 
    {
      window.removeEventListener('resize', handleScreenChange);
      window.removeEventListener('orientationchange', handleScreenChange);
    };
  }, []);
 
  return (
    <Stage style={{backgroundColor: 'lightgray', 
      marginTop: `${marginTop}px`, 
      marginLeft: `${marginLeft}px`, 
      marginRight: `${marginRight}px`,
      borderColor: 'darkgray', borderWidth: '1px', borderStyle: 'solid'}} width={fieldWidth} height={fieldHeight}>
      <Layer>
        <Shape
          onMouseEnter={handleMouseEnter}
          onMouseLeave={handleMouseLeave}
          sceneFunc={(context, shape) => 
          {
            context.beginPath();
            
            for (let index = 0; index < 6; index++) 
            {
              const data = hex_corner(center, size, index);
              if(index === 0)
              {
                context.moveTo(data.x, data.y);
              }
              else
              {
                context.lineTo(data.x, data.y);
              }
            }

            context.closePath();
            // (!) Konva specific method, it is very important
            context.fillStrokeShape(shape);
          }}
          fill={'red'}
          stroke="black"
          strokeWidth={1}
        />
      </Layer>
    </Stage>
  );
};
