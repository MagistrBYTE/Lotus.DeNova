import { AuthApiService } from 'src/modules/auth';
import { TKey } from 'src/shared/types/Key';
import { IResponse } from 'src/shared/types/Response';
import { createURLSearchParamsFromRequest } from 'src/shared/utils/utilsRequest';
import { IAvatarStateCreateRequest } from './AvatarStateCreateRequest';
import { IAvatarStatesRequest } from './AvatarStatesRequest';
import { IAvatarStatesResponse } from './AvatarStatesResponse';
import { IAvatarStateResponse } from './AvatarStateResponse';
import { IAvatarStateRequest } from './AvatarStateRequest';

class AvatarStateApiService extends AuthApiService 
{
  private static _AvatarStateApi: AvatarStateApiService;

  public static get Instance(): AvatarStateApiService 
  {
    return (this._AvatarStateApi || (this._AvatarStateApi = new this()));
  }

  constructor()
  {
    super();
    this.createAvatarStateAsync = this.createAvatarStateAsync.bind(this);
    this.updateAvatarStateAsync = this.updateAvatarStateAsync.bind(this);
    this.getAvatarStateAsync = this.getAvatarStateAsync.bind(this);
    this.getAvatarStatesAsync = this.getAvatarStatesAsync.bind(this);
    this.removeAvatarStateAsync = this.removeAvatarStateAsync.bind(this);
  } 

  public async createAvatarStateAsync(createParams: IAvatarStateCreateRequest):Promise<IAvatarStateResponse> 
  {
    const url = 'api/avatarState/create';

    const response = await this.post<IAvatarStateResponse, IAvatarStateCreateRequest>(url, createParams);
    return response.data;
  }

  public async updateAvatarStateAsync(updatedAvatarState: IAvatarStateRequest):Promise<IAvatarStateResponse> 
  {
    const url = 'api/avatarState/update';

    const response = await this.put<IAvatarStateResponse, IAvatarStateRequest>(url, updatedAvatarState);
    return response.data;
  }   

  public async getAvatarStateAsync(id: string):Promise<IAvatarStateResponse> 
  {
    const query:URLSearchParams = new URLSearchParams();
    query.append('id', id.toString());

    const url = 'api/avatarState/get';

    const response = await this.get<IAvatarStateResponse>(url, query);
    return response.data;
  }    

  public async getAvatarStatesAsync(request: IAvatarStatesRequest):Promise<IAvatarStatesResponse>
  {
    const search:URLSearchParams = createURLSearchParamsFromRequest(request);

    const url = 'api/avatarState/getall';

    const response = await this.get<IAvatarStatesResponse>(url, {params: search});
    return response.data;
  }  

  public async removeAvatarStateAsync(id: string):Promise<IResponse> 
  {
    const delet:URLSearchParams = new URLSearchParams();
    delet.append('id', id.toString())

    const url = 'api/avatarState/delete';

    const response = await this.delete<IResponse>(url, {params: delet});
    return response.data;
  }    
}

/**
 * Глобальный экземпляр для доступа к Api для работы с аватаром персонажа
 */
export const AvatarStateApi = AvatarStateApiService.Instance;