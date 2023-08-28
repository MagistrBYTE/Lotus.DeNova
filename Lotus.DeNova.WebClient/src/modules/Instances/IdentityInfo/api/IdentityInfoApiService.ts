import { IResponse } from 'src/core/types/Response';
import { TKey } from 'src/core/types/Key';
import { createURLSearchParamsFromRequest } from 'src/shared/request/utils';
import { AuthApiService } from 'src/shared/auth/api/AuthApiService';
import { IIdentityInfoCreateRequest } from './IdentityInfoCreateRequest';
import { IIdentityInfosRequest } from './IdentityInfosRequest';
import { IIdentityInfosResponse } from './IdentityInfosResponse';
import { IIdentityInfoResponse } from './IdentityInfoResponse';
import { IIdentityInfoRequest } from './IdentityInfoRequest';

class IdentityInfoApiService extends AuthApiService 
{
  private static _IdentityInfoApi: IdentityInfoApiService;

  public static get Instance(): IdentityInfoApiService 
  {
    return (this._IdentityInfoApi || (this._IdentityInfoApi = new this()));
  }

  constructor()
  {
    super();
    this.createIdentityInfoAsync = this.createIdentityInfoAsync.bind(this);
    this.updateIdentityInfoAsync = this.updateIdentityInfoAsync.bind(this);
    this.getIdentityInfoAsync = this.getIdentityInfoAsync.bind(this);
    this.getIdentityInfosAsync = this.getIdentityInfosAsync.bind(this);
    this.removeIdentityInfoAsync = this.removeIdentityInfoAsync.bind(this);
  } 

  public async createIdentityInfoAsync(createParams: IIdentityInfoCreateRequest):Promise<IIdentityInfoResponse> 
  {
    const url = 'api/identityInfo/create';

    const response = await this.post<IIdentityInfoResponse, IIdentityInfoCreateRequest>(url, createParams);
    return response.data;
  }

  public async updateIdentityInfoAsync(updatedIdentityInfo: IIdentityInfoRequest):Promise<IIdentityInfoResponse> 
  {
    const url = 'api/identityInfo/update';

    const response = await this.put<IIdentityInfoResponse, IIdentityInfoRequest>(url, updatedIdentityInfo);
    return response.data;
  }   

  public async getIdentityInfoAsync(id: number):Promise<IIdentityInfoResponse> 
  {
    const url = 'api/identityInfo/get';

    const response = await this.get<IIdentityInfoResponse>(url);
    return response.data;
  }    

  public async getIdentityInfosAsync(request: IIdentityInfosRequest):Promise<IIdentityInfosResponse>
  {
    const search:URLSearchParams = createURLSearchParamsFromRequest(request);

    const url = 'api/identityInfo/getall';

    const response = await this.get<IIdentityInfosResponse>(url, {params: search});
    return response.data;
  }  

  public async removeIdentityInfoAsync(id: TKey):Promise<IResponse> 
  {
    const delet:URLSearchParams = new URLSearchParams();
    delet.append('id', id.toString())

    const url = 'api/identityInfo/delete';

    const response = await this.delete<IResponse>(url, {params: delet});
    return response.data;
  }    
}

/**
 * Глобальный экземпляр для доступа к Api для работы с идентификационными сведениями о персонаже
 */
export const IdentityInfoApi = IdentityInfoApiService.Instance;