import { Vector2 } from '../Math';
import { Hex, IHex } from './Hex';

/**
 * Вспомогательный класс для хранения прямой матрицы 2×2, обратной матрицы 2×2 и начального угла
 */
export class HexOrientation
{
  //
  // КОНСТАНТНЫЕ ДАННЫЕ
  //
  // #region
  /**
   * Компоновка с острой вершиной - горизонтальная
   */  
  public static readonly Pointy:HexOrientation = new HexOrientation(Math.sqrt(3.0), Math.sqrt(3.0) / 2.0, 0.0, 3.0 / 2.0, Math.sqrt(3.0) / 3.0, -1.0 / 3.0, 0.0, 2.0 / 3.0, 0.5);
  
  /**
   * Компоновка с плоской вершиной - вертикальная
   */  
  public static readonly Flat:HexOrientation = new HexOrientation(3.0 / 2.0, 0.0, Math.sqrt(3.0) / 2.0, Math.sqrt(3.0), 2.0 / 3.0, 0.0, -1.0 / 3.0, Math.sqrt(3.0) / 3.0, 0.0);
  // #endregion

  //
  // ДАННЫЕ
  //
  // #region  
  public f0:number;
  public f1:number;
  public f2:number;
  public f3:number;

  public b0:number;
  public b1:number;
  public b2:number;
  public b3:number;

  /**
   * Кратно 60° 
   */    
  public startAngle:number;
  // #endregion

  constructor (f0:number, f1:number, f2:number, f3:number, b0:number, b1:number, b2:number, b3:number, startAngle:number) 
  {
    this.f0 = f0;
    this.f1 = f1;
    this.f2 = f2;
    this.f3 = f3;

    this.b0 = b0;
    this.b1 = b1;
    this.b2 = b2;
    this.b3 = b3;

    this.startAngle = startAngle;
  }
}

/**
 * Класc для преобразование гексов в экранное пространство
 */
export class HexLayout
{
  /**
   * Ориентация макета
   */  
  public orientation:HexOrientation;

  /**
   * Размер гекса в пикселях
   */   
  public size:Vector2;

  /**
   * Начальная точка
   */    
  public origin:Vector2;

  constructor (orientation:HexOrientation, size:Vector2, origin:Vector2)
  {
    this.orientation = orientation;
    this.size = size;
    this.origin = origin;
  }

  public hexToPixel(hex:IHex):Vector2
  {
    const matrix:HexOrientation = this.orientation;
    const size:Vector2 = this.size;
    const origin:Vector2 = this.origin;
    const x:number = (matrix.f0 * hex.q + matrix.f1 * hex.r) * size.x;
    const y:number = (matrix.f2 * hex.q + matrix.f3 * hex.r) * size.y;
    return new Vector2(x + origin.x, y + origin.y);
  }


  public pixelToHex(p:Vector2):Hex
  {
    const matrix:HexOrientation = this.orientation;
    const size:Vector2 = this.size;
    const origin:Vector2 = this.origin;
    const pt:Vector2 = new Vector2((p.x - origin.x) / size.x, (p.y - origin.y) / size.y);
    const q:number = matrix.b0 * pt.x + matrix.b1 * pt.y;
    const r:number = matrix.b2 * pt.x + matrix.b3 * pt.y;
    return new Hex(q, r, (-q - r));
  }


  public hexCornerOffset(corner:number):Vector2
  {
    const matrix:HexOrientation = this.orientation;
    const size:Vector2 = this.size;
    const angle:number = 2.0 * Math.PI * (matrix.startAngle - corner) / 6.0;
    return new Vector2(size.x * Math.cos(angle), size.y * Math.sin(angle));
  }


  public polygonCorners(hex:IHex):Vector2[]
  {
    const corners:Vector2[] = [];
    const center:Vector2 = this.hexToPixel(hex);
    for (let i = 0; i < 6; i++)
    {
      const offset:Vector2 = this.hexCornerOffset(i);
      corners.push(new Vector2(center.x + offset.x, center.y + offset.y));
    }
    return corners;
  }

}