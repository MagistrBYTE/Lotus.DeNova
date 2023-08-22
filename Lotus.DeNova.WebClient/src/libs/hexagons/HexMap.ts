import { Hex } from './Hex';
import { HexOrientation } from './HexLayout';

/**
 * Форма карты
 */
export enum THexMapForm
{
  /**
   * Параллелограмм
   */
  Parallelograms,

  /**
   * Треугольники
   */
  Triangles,

  /**
   * Шестиугольники
   */
  Hexagons,

  /**
   * Прямоугольники
   */  
  Rectangles,
}

/**
 * Карта из гексов
 */
export class HexMap
{
  /**
   * Форма карты
   */  
  public mapForm:THexMapForm;

  /**
   * Ориентация гексов
   */  
  public orientation:HexOrientation;

  /**
   * Размер карты по ширине - количесвто гексов
   */    
  public countCol: number;

  /**
   * Размер карты по высоте - количесвто гексов
   */    
  public countRow: number;

  /**
   * Гексы карты
   */     
  public hexs:Hex[];

  constructor (mapForm:THexMapForm, orientation:HexOrientation, countCol:number, countRow:number)
  {
    this.mapForm = mapForm;
    this.orientation = orientation;
    this.countCol = countCol;
    this.countRow = countRow;
    this.hexs = [];
    this.buildMap();
  }
  
  public buildMap()
  {
    switch(this.mapForm)
    {
      case THexMapForm.Parallelograms: 
        {
          this.createParallelograms();
        } break;
      case THexMapForm.Triangles:
        {
          this.createTriangles();
        } break;        
      case THexMapForm.Hexagons:
        {
          this.createHexagons();
        } break;          
      case THexMapForm.Rectangles:
        {
          this.createRectangles();
        } break;          
    }
  }

  public createParallelograms()
  {
    for (let q = 0; q <= this.countCol; q++) 
    {
      for (let r = 0; r <= this.countCol; r++) 
      { 
        this.hexs.push(new Hex(q, r, -q-r)); 
      } 
    }
  }

  public createTriangles()
  {
    for (let q = 0; q <= this.countCol; q++) 
    {
      for (let r = 0; r <= this.countCol; r++) 
      { 
        this.hexs.push(new Hex(q, r, -q-r)); 
      } 
    }
  }

  public createHexagons()
  {
    for (let q = 0; q <= this.countCol; q++) 
    {
      for (let r = 0; r <= this.countCol; r++) 
      { 
        this.hexs.push(new Hex(q, r, -q-r)); 
      } 
    }
  }

  public createRectangles()
  {
    for (let q = 0; q <= this.countCol; q++) 
    {
      for (let r = 0; r <= this.countCol; r++) 
      { 
        this.hexs.push(new Hex(q, r, -q-r)); 
      } 
    }
  }   
}