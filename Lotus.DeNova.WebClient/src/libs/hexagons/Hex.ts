import Vector2 from '../Math/Vector2';

export interface IHex
{
  q: number;
  r: number;
  s: number;
}

export const hex_corner = (center:Vector2, size:number, i:number):Vector2 =>
{
  const angle_deg = 60 * i + 30;
  const angle_rad = Math.PI / 180 * angle_deg
  return new Vector2([center.x + size * Math.cos(angle_rad), center.y + size * Math.sin(angle_rad)])
}