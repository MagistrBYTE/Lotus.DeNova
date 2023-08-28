import { IResponse } from 'src/core/types/Response';
import { TKey } from 'src/core/types/Key';
import { createURLSearchParamsFromRequest } from 'src/shared/request/utils';
import { AuthApiService } from 'src/shared/auth/api/AuthApiService';
import { IGameContextCreateRequest } from './GameContextCreateRequest';
import { IGameContextsRequest } from './GameContextsRequest';
import { IGameContextsResponse } from './GameContextsResponse';
import { IGameContextResponse } from './GameContextResponse';
import { IGameContextRequest } from './GameContextRequest';

class GameContextApiService extends AuthApiService 
{
  private static _GameContextApi: GameContextApiService;

  public static get Instance(): GameContextApiService 
  {
    return (this._GameContextApi || (this._GameContextApi = new this()));
  }

  constructor()
  {
    super();
    this.createGameContextAsync = this.createGameContextAsync.bind(this);
    this.updateGameContextAsync = this.updateGameContextAsync.bind(this);
    this.getGameContextsAsync = this.getGameContextsAsync.bind(this);
    this.getGameContextAsync = this.getGameContextAsync.bind(this);
    this.removeGameContextAsync = this.removeGameContextAsync.bind(this);
  } 

  public async createGameContextAsync(createParams: IGameContextCreateRequest):Promise<IGameContextResponse> 
  {
    const url = 'api/gameContext/create';

    const response = await this.post<IGameContextResponse, IGameContextCreateRequest>(url, createParams);
    return response.data;
  } 

  public async updateGameContextAsync(updatedGameContext: IGameContextRequest):Promise<IGameContextResponse> 
  {
    const url = 'api/gameContext/update';

    const response = await this.put<IGameContextResponse, IGameContextRequest>(url, updatedGameContext);
    return response.data;
  } 

  public async getGameContextAsync(id: number):Promise<IGameContextResponse> 
  {
    const url = 'api/gameContext/get';

    const response = await this.get<IGameContextResponse>(url);
    return response.data;
  }    

  public async getGameContextsAsync(request: IGameContextsRequest):Promise<IGameContextsResponse>
  {
    const search:URLSearchParams = createURLSearchParamsFromRequest(request);

    const url = 'api/gameContext/getall';

    const response = await this.get<IGameContextsResponse>(url, {params: search});
    return response.data;
  } 

  public async removeGameContextAsync(id: TKey):Promise<IResponse> 
  {
    const delet:URLSearchParams = new URLSearchParams();
    delet.append('id', id.toString())

    const url = 'api/gameContext/delete';

    const response = await this.delete<IResponse>(url, {params: delet});
    return response.data;
  }
}

/**
 * Глобальный экземпляр для доступа к Api для работы с игровым контекстом
 */
export const GameContextApi = GameContextApiService.Instance;