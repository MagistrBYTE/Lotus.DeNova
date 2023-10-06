import { AuthApiService } from 'src/modules/auth';
import { IResponse } from 'src/shared/types/Response';
import { createURLSearchParamsFromRequest } from 'src/shared/utils/utilsRequest';
import { IIdentityStateCreateRequest } from './IdentityStateCreateRequest';
import { IIdentityStatesRequest } from './IdentityStatesRequest';
import { IIdentityStatesResponse } from './IdentityStatesResponse';
import { IIdentityStateResponse } from './IdentityStateResponse';
import { IIdentityStateRequest } from './IdentityStateRequest';

class IdentityStateApiService extends AuthApiService 
{
  private static _IdentityStateApi: IdentityStateApiService;

  public static get Instance(): IdentityStateApiService 
  {
    return (this._IdentityStateApi || (this._IdentityStateApi = new this()));
  }

  constructor()
  {
    super();
    this.createIdentityStateAsync = this.createIdentityStateAsync.bind(this);
    this.updateIdentityStateAsync = this.updateIdentityStateAsync.bind(this);
    this.getIdentityStateAsync = this.getIdentityStateAsync.bind(this);
    this.getIdentityStatesAsync = this.getIdentityStatesAsync.bind(this);
    this.removeIdentityStateAsync = this.removeIdentityStateAsync.bind(this);
  } 

  public async createIdentityStateAsync(createParams: IIdentityStateCreateRequest):Promise<IIdentityStateResponse> 
  {
    const url = 'api/identityState/create';

    const response = await this.post<IIdentityStateResponse, IIdentityStateCreateRequest>(url, createParams);
    return response.data;
  }

  public async updateIdentityStateAsync(updatedIdentityState: IIdentityStateRequest):Promise<IIdentityStateResponse> 
  {
    const url = 'api/identityState/update';

    const response = await this.put<IIdentityStateResponse, IIdentityStateRequest>(url, updatedIdentityState);
    return response.data;
  }   

  public async getIdentityStateAsync(id: string):Promise<IIdentityStateResponse> 
  {
    const query:URLSearchParams = new URLSearchParams();
    query.append('id', id.toString());

    const url = 'api/identityState/get';

    const response = await this.get<IIdentityStateResponse>(url, query);
    return response.data;
  }    

  public async getIdentityStatesAsync(request: IIdentityStatesRequest):Promise<IIdentityStatesResponse>
  {
    const search:URLSearchParams = createURLSearchParamsFromRequest(request);

    const url = 'api/identityState/getall';

    const response = await this.get<IIdentityStatesResponse>(url, {params: search});
    return response.data;
  }  

  public async removeIdentityStateAsync(id: string):Promise<IResponse> 
  {
    const delet:URLSearchParams = new URLSearchParams();
    delet.append('id', id.toString())

    const url = 'api/identityState/delete';

    const response = await this.delete<IResponse>(url, {params: delet});
    return response.data;
  }    
}

/**
 * Глобальный экземпляр для доступа к Api для работы с идентификационными сведениями о персонаже
 */
export const IdentityStateApi = IdentityStateApiService.Instance;