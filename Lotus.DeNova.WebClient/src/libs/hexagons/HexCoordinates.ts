import { Hex } from './Hex';

/**
 * Тип смещения
 */
export enum THexOffsetCoordType
{
  /**
   * Горизонтальное расположение «нечет-r»
   */
  ODD_R = 'ODD_R',

  /**
   * Горизонтальное расположение «чёт-r» 
   */
  EVEN_R = 'EVEN_R',

  /**
   * Вертикальное расположение «нечет-r»
   */
  ODD_Q = 'ODD_Q',

  /**
   * Вертикальное расположение «чёт-r» 
   */
  EVEN_Q = 'EVEN_Q',    

}

/**
 * Интерфейс координат смещения
 */
export interface IHexOffsetCoord
{
  col: number;
  row: number;
}

/**
 * Координаты смещения
 */
export class HexOffsetCoord implements IHexOffsetCoord
{
  public col:number;
  public row:number;

  constructor (col:number, row:number) 
  {
    this.col = col;
    this.row = row;
  }

  /**
   * Преобразование смещения как горизонтального расположения «нечет-r» в кубические координаты
   * @returns 
   */
  public ConvertAs_ODD_R_ToCube():Hex
  {  
    const q:number = this.col - (this.row - (this.row&1)) / 2;
    const r:number = this.row
    const s:number = -q - r;
    return new Hex(q, r, s);
  }
  
  /**
   * Преобразование смещения как горизонтального расположения «чет-r» в кубические координаты
   * @returns 
   */
  public ConvertAs_EVEN_R_ToCube():Hex
  {  
    const q:number = this.col - (this.row + (this.row&1)) / 2;
    const r:number = this.row
    const s:number = -q - r;
    return new Hex(q, r, s);
  }

  /**
   * Преобразование смещения как вертикального расположения «нечет-q» в кубические координаты
   * @returns 
   */
  public ConvertAs_ODD_Q_ToCube():Hex
  {  
    const q:number = this.col;
    const r:number = this.row - (this.col - (this.col&1)) / 2
    const s:number = -q - r;
    return new Hex(q, r, s);
  }  

  /**
   * Преобразование смещения как вертикального расположения «чёт-r» в кубические координаты
   * @returns 
   */
  public ConvertAs_EVEN_Q_ToCube():Hex
  {
    const q:number = this.col;
    const r:number = this.row - (this.col + (this.col&1)) / 2
    const s:number = -q - r;
    return new Hex(q, r, s);
  }

  /**
   * Конвертирование в кубические координаты
   * @param offsetCoordType Как интерпретировать текущие координаты
   * @returns 
   */
  public ConvertToCube(offsetCoordType:THexOffsetCoordType):Hex
  {
    switch(offsetCoordType)
    {
      case THexOffsetCoordType.ODD_R:
      {
        return this.ConvertAs_ODD_R_ToCube();
      }
      case THexOffsetCoordType.EVEN_R:
      {
        return this.ConvertAs_EVEN_R_ToCube();
      }        
      case THexOffsetCoordType.ODD_Q:
      {
        return this.ConvertAs_ODD_Q_ToCube();
      }
      case THexOffsetCoordType.EVEN_Q:
      {
        return this.ConvertAs_EVEN_Q_ToCube();
      }        
    }

    return Hex.Zero;
  }
}