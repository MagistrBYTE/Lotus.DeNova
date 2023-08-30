import { IResponse } from 'src/core/types/Response';
import { TKey } from 'src/core/types/Key';
import { createURLSearchParamsFromRequest } from 'src/shared/request/utils';
import { AuthApiService } from 'src/shared/auth/api/AuthApiService';
import { IAddressInfoCreateRequest } from './AddressInfoCreateRequest';
import { IAddressInfosRequest } from './AddressInfosRequest';
import { IAddressInfosResponse } from './AddressInfosResponse';
import { IAddressInfoResponse } from './AddressInfoResponse';
import { IAddressInfoRequest } from './AddressInfoRequest';

class AddressInfoApiService extends AuthApiService 
{
  private static _AddressInfoApi: AddressInfoApiService;

  public static get Instance(): AddressInfoApiService 
  {
    return (this._AddressInfoApi || (this._AddressInfoApi = new this()));
  }

  constructor()
  {
    super();
    this.createAddressInfoAsync = this.createAddressInfoAsync.bind(this);
    this.updateAddressInfoAsync = this.updateAddressInfoAsync.bind(this);
    this.getAddressInfoAsync = this.getAddressInfoAsync.bind(this);
    this.getAddressInfosAsync = this.getAddressInfosAsync.bind(this);
    this.removeAddressInfoAsync = this.removeAddressInfoAsync.bind(this);
  } 

  public async createAddressInfoAsync(createParams: IAddressInfoCreateRequest):Promise<IAddressInfoResponse> 
  {
    const url = 'api/addressInfo/create';

    const response = await this.post<IAddressInfoResponse, IAddressInfoCreateRequest>(url, createParams);
    return response.data;
  }

  public async updateAddressInfoAsync(updatedAddressInfo: IAddressInfoRequest):Promise<IAddressInfoResponse> 
  {
    const url = 'api/addressInfo/update';

    const response = await this.put<IAddressInfoResponse, IAddressInfoRequest>(url, updatedAddressInfo);
    return response.data;
  }   

  public async getAddressInfoAsync(id: number):Promise<IAddressInfoResponse> 
  {
    const url = 'api/addressInfo/get';

    const response = await this.get<IAddressInfoResponse>(url);
    return response.data;
  }    

  public async getAddressInfosAsync(request: IAddressInfosRequest):Promise<IAddressInfosResponse>
  {
    const search:URLSearchParams = createURLSearchParamsFromRequest(request);

    const url = 'api/addressInfo/getall';

    const response = await this.get<IAddressInfosResponse>(url, {params: search});
    return response.data;
  }  

  public async removeAddressInfoAsync(id: TKey):Promise<IResponse> 
  {
    const delet:URLSearchParams = new URLSearchParams();
    delet.append('id', id.toString())

    const url = 'api/addressInfo/delete';

    const response = await this.delete<IResponse>(url, {params: delet});
    return response.data;
  }    
}

/**
 * Глобальный экземпляр для доступа к Api для работы с местом жительства персонажа
 */
export const AddressInfoApi = AddressInfoApiService.Instance;