import { AuthApiService } from 'src/modules/auth';
import { IResponse } from 'src/shared/types/Response';
import { createURLSearchParamsFromRequest } from 'src/shared/utils/utilsRequest';
import { IGameCreateRequest } from './GameCreateRequest';
import { IGameLoadRequest } from './GameLoadRequest';
import { IGameResponse } from './GameResponse';
import { IGameSaveCreateRequest } from './GameSaveCreateRequest';
import { IGameSaveResponse } from './GameSaveResponse';
import { IGameSavesRequest } from './GameSavesRequest';
import { IGameSavesResponse } from './GameSavesResponse';
import { IGamesRequest } from './GamesRequest';
import { IGamesResponse } from './GamesResponse';


class GameApiService extends AuthApiService 
{
  private static _GameApi: GameApiService;

  public static get Instance(): GameApiService 
  {
    return (this._GameApi || (this._GameApi = new this()));
  }

  constructor()
  {
    super();
    this.createGameAsync = this.createGameAsync.bind(this);
    this.saveGameSaveAsync = this.saveGameSaveAsync.bind(this);
    this.loadGameSaveAsync = this.loadGameSaveAsync.bind(this);
    this.getGameCurrentAsync = this.getGameCurrentAsync.bind(this);
    this.getGamesAsync = this.getGamesAsync.bind(this);
    this.getGameSavesAsync = this.getGameSavesAsync.bind(this);
    this.removeGameAsync = this.removeGameAsync.bind(this);
    this.removeGameSaveAsync = this.removeGameSaveAsync.bind(this);
  } 

  public async createGameAsync(createParams: IGameCreateRequest):Promise<IGameResponse> 
  {
    const url = 'api/game/create';

    const response = await this.post<IGameResponse, IGameCreateRequest>(url, createParams);
    return response.data;
  } 

  public async saveGameSaveAsync(createParams: IGameSaveCreateRequest):Promise<IGameSaveResponse> 
  {
    const url = 'api/game/save';

    const response = await this.post<IGameSaveResponse, IGameSaveCreateRequest>(url, createParams);
    return response.data;
  }

  public async loadGameSaveAsync(createParams: IGameLoadRequest):Promise<IGameSaveResponse> 
  {
    const url = 'api/game/save';

    const response = await this.put<IGameSaveResponse, IGameLoadRequest>(url, createParams);
    return response.data;
  } 

  public async getGameCurrentAsync(playerId: string):Promise<IGameResponse> 
  {
    const query:URLSearchParams = new URLSearchParams();
    query.append('id', playerId.toString())

    const url = 'api/game/getCurrent';

    const response = await this.get<IGameResponse>(url, query);
    return response.data;
  }  

  public async getGamesAsync(request: IGamesRequest):Promise<IGamesResponse>
  {
    const search:URLSearchParams = createURLSearchParamsFromRequest(request);

    const url = 'api/game/getall';

    const response = await this.get<IGamesResponse>(url, {params: search});
    return response.data;
  }

  public async getGameSavesAsync(request: IGameSavesRequest):Promise<IGameSavesResponse>
  {
    const search:URLSearchParams = createURLSearchParamsFromRequest(request);

    const url = 'api/game/getAllSave';

    const response = await this.get<IGameSavesResponse>(url, {params: search});
    return response.data;
  }

  public async removeGameAsync(id: string):Promise<IResponse> 
  {
    const delet:URLSearchParams = new URLSearchParams();
    delet.append('id', id.toString())

    const url = 'api/game/delete';

    const response = await this.delete<IResponse>(url, {params: delet});
    return response.data;
  }

  public async removeGameSaveAsync(id: string):Promise<IResponse> 
  {
    const delet:URLSearchParams = new URLSearchParams();
    delet.append('id', id.toString())

    const url = 'api/game/deleteSave';

    const response = await this.delete<IResponse>(url, {params: delet});
    return response.data;
  }     
}

/**
 * Глобальный экземпляр для доступа к Api для работы с игрой
 */
export const GameApi = GameApiService.Instance;