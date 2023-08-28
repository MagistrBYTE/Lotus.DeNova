import { IResponse } from 'src/core/types/Response';
import { TKey } from 'src/core/types/Key';
import { createURLSearchParamsFromRequest } from 'src/shared/request/utils';
import { AuthApiService } from 'src/shared/auth/api/AuthApiService';
import { IGameSaveCreateRequest } from './GameSaveCreateRequest';
import { IGameSavesRequest } from './GameSavesRequest';
import { IGameSavesResponse } from './GameSavesResponse';
import { IGameSaveResponse } from './GameSaveResponse';
import { IGameSaveRequest } from './GameSaveRequest';
import { IGameLoadRequest } from './GameLoadRequest';

class GameSaveApiService extends AuthApiService 
{
  private static _GameSaveApi: GameSaveApiService;

  public static get Instance(): GameSaveApiService 
  {
    return (this._GameSaveApi || (this._GameSaveApi = new this()));
  }

  constructor()
  {
    super();

    this.saveGameSaveAsync = this.saveGameSaveAsync.bind(this);
    this.loadGameSaveAsync = this.loadGameSaveAsync.bind(this);
    this.updateGameSaveAsync = this.updateGameSaveAsync.bind(this);
    this.getGameSavesAsync = this.getGameSavesAsync.bind(this);
    this.removeGameSaveAsync = this.removeGameSaveAsync.bind(this);
  } 

  public async saveGameSaveAsync(createParams: IGameSaveCreateRequest):Promise<IGameSaveResponse> 
  {
    const url = 'api/gameSave/save';

    const response = await this.post<IGameSaveResponse, IGameSaveCreateRequest>(url, createParams);
    return response.data;
  }

  public async loadGameSaveAsync(createParams: IGameLoadRequest):Promise<IGameSaveResponse> 
  {
    const url = 'api/gameSave/save';

    const response = await this.put<IGameSaveResponse, IGameLoadRequest>(url, createParams);
    return response.data;
  } 

  public async updateGameSaveAsync(updatedGameSave: IGameSaveRequest):Promise<IGameSaveResponse> 
  {
    const url = 'api/gameSave/update';

    const response = await this.put<IGameSaveResponse, IGameSaveRequest>(url, updatedGameSave);
    return response.data;
  } 

  public async getGameSavesAsync(request: IGameSavesRequest):Promise<IGameSavesResponse>
  {
    const search:URLSearchParams = createURLSearchParamsFromRequest(request);

    const url = 'api/gameSave/getall';

    const response = await this.get<IGameSavesResponse>(url, {params: search});
    return response.data;
  }

  public async removeGameSaveAsync(id: TKey):Promise<IResponse> 
  {
    const delet:URLSearchParams = new URLSearchParams();
    delet.append('id', id.toString())

    const url = 'api/gameContext/delete';

    const response = await this.delete<IResponse>(url, {params: delet});
    return response.data;
  }     
}

/**
 * Глобальный экземпляр для доступа к Api для работы с сохранением/загрузкой контекста игры
 */
export const GameSaveApi = GameSaveApiService.Instance;