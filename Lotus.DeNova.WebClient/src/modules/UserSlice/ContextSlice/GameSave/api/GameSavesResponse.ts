import { IResponsePage } from 'src/core/types/Response';
import { IGameSave } from '../domain/GameSave';

export interface IGameSavesResponse extends IResponsePage<IGameSave>
{
  
}