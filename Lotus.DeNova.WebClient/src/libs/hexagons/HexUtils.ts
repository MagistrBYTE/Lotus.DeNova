import { Shape, ShapeConfig } from 'konva/lib/Shape';
import { Context } from 'konva/lib/Context';
import { Vector2 } from '../Math';
import { HexMap, THexMapForm } from './HexMap';
import { HexLayout, HexOrientation } from './HexLayout';
import { Hex, IHex } from './Hex';

export const drawHex = (context:Context, strokeStyle:string, layout:HexLayout, hex:IHex) =>
{
  const points = layout.polygonCorners(hex);

  context.beginPath();
  context.strokeStyle = strokeStyle;
  context.lineWidth = 1;    
  for(let h = 0; h < points.length; h++)
  {
    const point = points[h];
    context.lineTo(point.x + 0.5, point.y + 0.5);
    context.stroke();
  }
  context.lineTo(points[0].x + 0.5, points[0].y + 0.5);
  context.stroke();
  context.closePath();  
}

export const drawHexImage = (context:Context, strokeStyle:string, imageSource:CanvasImageSource, layout:HexLayout, hex:IHex) =>
{
  const points = layout.polygonCorners(hex);

  context.beginPath();
  context.strokeStyle = strokeStyle;
  context.lineWidth = 1; 
  
  const center:Vector2 = new Vector2(0, 0);
  for(let h = 0; h < points.length; h++)
  {
    const point = points[h];
    context.lineTo(point.x + 0.5, point.y + 0.5);
    context.stroke();
    center.x += point.x;
    center.y += point.y;
  }
  context.lineTo(points[0].x + 0.5, points[0].y + 0.5);
  context.stroke();
  context.closePath();

  center.x = center.x / points.length; 
  center.y = center.y / points.length;
 
  context.drawImage(imageSource, center.x - layout.size.x, center.y - layout.size.y, layout.size.x * 2, layout.size.y * 2);
}

export const drawHexField = (context:Context, shape: Shape<ShapeConfig>, 
  width: number, height: number, size:number, isFlat:boolean, mapForm: THexMapForm) =>
{
  const countX = 10; // Math.floor(width / (size*1.5));
  const countY = 10; // Math.floor(height / (size*2));

  const startX = size;
  const startY = size;

  const orientation:HexOrientation = isFlat ? HexOrientation.Flat : HexOrientation.Pointy;

  const map: HexMap = new HexMap(mapForm, orientation, countX, countY);

  const layout: HexLayout = new HexLayout(orientation, new Vector2(size, size), new Vector2(startX, startY));

  for (let index = 0; index < map.hexs.length; index++) 
  {
    const hex = map.hexs[index];
    drawHex(context, 'black', layout, hex);
  }
}