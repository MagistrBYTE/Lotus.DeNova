import { AuthApiService } from 'src/modules/auth';
import { TKey } from 'src/shared/types/Key';
import { IResponse } from 'src/shared/types/Response';
import { createURLSearchParamsFromRequest } from 'src/shared/utils/utilsRequest';
import { IAddressStateCreateRequest } from './AddressStateCreateRequest';
import { IAddressStatesRequest } from './AddressStatesRequest';
import { IAddressStatesResponse } from './AddressStatesResponse';
import { IAddressStateResponse } from './AddressStateResponse';
import { IAddressStateRequest } from './AddressStateRequest';

class AddressStateApiService extends AuthApiService 
{
  private static _AddressStateApi: AddressStateApiService;

  public static get Instance(): AddressStateApiService 
  {
    return (this._AddressStateApi || (this._AddressStateApi = new this()));
  }

  constructor()
  {
    super();
    this.createAddressStateAsync = this.createAddressStateAsync.bind(this);
    this.updateAddressStateAsync = this.updateAddressStateAsync.bind(this);
    this.getAddressStateAsync = this.getAddressStateAsync.bind(this);
    this.getAddressStatesAsync = this.getAddressStatesAsync.bind(this);
    this.removeAddressStateAsync = this.removeAddressStateAsync.bind(this);
  } 

  public async createAddressStateAsync(createParams: IAddressStateCreateRequest):Promise<IAddressStateResponse> 
  {
    const url = 'api/addressState/create';

    const response = await this.post<IAddressStateResponse, IAddressStateCreateRequest>(url, createParams);
    return response.data;
  }

  public async updateAddressStateAsync(updatedAddressState: IAddressStateRequest):Promise<IAddressStateResponse> 
  {
    const url = 'api/addressState/update';

    const response = await this.put<IAddressStateResponse, IAddressStateRequest>(url, updatedAddressState);
    return response.data;
  }   

  public async getAddressStateAsync(id: string):Promise<IAddressStateResponse> 
  {
    const query:URLSearchParams = new URLSearchParams();
    query.append('id', id.toString());

    const url = 'api/addressState/get';

    const response = await this.get<IAddressStateResponse>(url, query);
    return response.data;
  }    

  public async getAddressStatesAsync(request: IAddressStatesRequest):Promise<IAddressStatesResponse>
  {
    const search:URLSearchParams = createURLSearchParamsFromRequest(request);

    const url = 'api/addressState/getall';

    const response = await this.get<IAddressStatesResponse>(url, {params: search});
    return response.data;
  }  

  public async removeAddressStateAsync(id: string):Promise<IResponse> 
  {
    const delet:URLSearchParams = new URLSearchParams();
    delet.append('id', id.toString())

    const url = 'api/addressState/delete';

    const response = await this.delete<IResponse>(url, {params: delet});
    return response.data;
  }    
}

/**
 * Глобальный экземпляр для доступа к Api для работы с местом жительства персонажа
 */
export const AddressStateApi = AddressStateApiService.Instance;