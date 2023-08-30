import { IResponse } from 'src/core/types/Response';
import { TKey } from 'src/core/types/Key';
import { createURLSearchParamsFromRequest } from 'src/shared/request/utils';
import { AuthApiService } from 'src/shared/auth/api/AuthApiService';
import { IAvatarInfoCreateRequest } from './AvatarInfoCreateRequest';
import { IAvatarInfosRequest } from './AvatarInfosRequest';
import { IAvatarInfosResponse } from './AvatarInfosResponse';
import { IAvatarInfoResponse } from './AvatarInfoResponse';
import { IAvatarInfoRequest } from './AvatarInfoRequest';

class AvatarInfoApiService extends AuthApiService 
{
  private static _AvatarInfoApi: AvatarInfoApiService;

  public static get Instance(): AvatarInfoApiService 
  {
    return (this._AvatarInfoApi || (this._AvatarInfoApi = new this()));
  }

  constructor()
  {
    super();
    this.createAvatarInfoAsync = this.createAvatarInfoAsync.bind(this);
    this.updateAvatarInfoAsync = this.updateAvatarInfoAsync.bind(this);
    this.getAvatarInfoAsync = this.getAvatarInfoAsync.bind(this);
    this.getAvatarInfosAsync = this.getAvatarInfosAsync.bind(this);
    this.removeAvatarInfoAsync = this.removeAvatarInfoAsync.bind(this);
  } 

  public async createAvatarInfoAsync(createParams: IAvatarInfoCreateRequest):Promise<IAvatarInfoResponse> 
  {
    const url = 'api/avatarInfo/create';

    const response = await this.post<IAvatarInfoResponse, IAvatarInfoCreateRequest>(url, createParams);
    return response.data;
  }

  public async updateAvatarInfoAsync(updatedAvatarInfo: IAvatarInfoRequest):Promise<IAvatarInfoResponse> 
  {
    const url = 'api/avatarInfo/update';

    const response = await this.put<IAvatarInfoResponse, IAvatarInfoRequest>(url, updatedAvatarInfo);
    return response.data;
  }   

  public async getAvatarInfoAsync(id: number):Promise<IAvatarInfoResponse> 
  {
    const url = 'api/avatarInfo/get';

    const response = await this.get<IAvatarInfoResponse>(url);
    return response.data;
  }    

  public async getAvatarInfosAsync(request: IAvatarInfosRequest):Promise<IAvatarInfosResponse>
  {
    const search:URLSearchParams = createURLSearchParamsFromRequest(request);

    const url = 'api/avatarInfo/getall';

    const response = await this.get<IAvatarInfosResponse>(url, {params: search});
    return response.data;
  }  

  public async removeAvatarInfoAsync(id: TKey):Promise<IResponse> 
  {
    const delet:URLSearchParams = new URLSearchParams();
    delet.append('id', id.toString())

    const url = 'api/avatarInfo/delete';

    const response = await this.delete<IResponse>(url, {params: delet});
    return response.data;
  }    
}

/**
 * Глобальный экземпляр для доступа к Api для работы с аватаром персонажа
 */
export const AvatarInfoApi = AvatarInfoApiService.Instance;