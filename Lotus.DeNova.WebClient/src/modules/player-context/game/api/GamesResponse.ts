import { IResponsePage } from 'src/shared/types/Response';
import { IGame } from '../domain/Game';


export interface IGamesResponse extends IResponsePage<IGame>
{
  
}