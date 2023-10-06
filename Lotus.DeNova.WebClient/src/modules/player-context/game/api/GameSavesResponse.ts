import { IResponsePage } from 'src/shared/types/Response';
import { IGameSave } from '../domain/GameSave';

export interface IGameSavesResponse extends IResponsePage<IGameSave>
{
  
}