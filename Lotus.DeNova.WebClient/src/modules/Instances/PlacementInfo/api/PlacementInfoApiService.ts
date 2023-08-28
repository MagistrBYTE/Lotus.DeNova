import { IResponse } from 'src/core/types/Response';
import { TKey } from 'src/core/types/Key';
import { createURLSearchParamsFromRequest } from 'src/shared/request/utils';
import { AuthApiService } from 'src/shared/auth/api/AuthApiService';
import { IPlacementInfoCreateRequest } from './PlacementInfoCreateRequest';
import { IPlacementInfosRequest } from './PlacementInfosRequest';
import { IPlacementInfosResponse } from './PlacementInfosResponse';
import { IPlacementInfoResponse } from './PlacementInfoResponse';
import { IPlacementInfoRequest } from './PlacementInfoRequest';

class PlacementInfoApiService extends AuthApiService 
{
  private static _PlacementInfoApi: PlacementInfoApiService;

  public static get Instance(): PlacementInfoApiService 
  {
    return (this._PlacementInfoApi || (this._PlacementInfoApi = new this()));
  }

  constructor()
  {
    super();
    this.createPlacementInfoAsync = this.createPlacementInfoAsync.bind(this);
    this.updatePlacementInfoAsync = this.updatePlacementInfoAsync.bind(this);
    this.getPlacementInfoAsync = this.getPlacementInfoAsync.bind(this);
    this.getPlacementInfosAsync = this.getPlacementInfosAsync.bind(this);
    this.removePlacementInfoAsync = this.removePlacementInfoAsync.bind(this);
  } 

  public async createPlacementInfoAsync(createParams: IPlacementInfoCreateRequest):Promise<IPlacementInfoResponse> 
  {
    const url = 'api/placementInfo/create';

    const response = await this.post<IPlacementInfoResponse, IPlacementInfoCreateRequest>(url, createParams);
    return response.data;
  }

  public async updatePlacementInfoAsync(updatedPlacementInfo: IPlacementInfoRequest):Promise<IPlacementInfoResponse> 
  {
    const url = 'api/placementInfo/update';

    const response = await this.put<IPlacementInfoResponse, IPlacementInfoRequest>(url, updatedPlacementInfo);
    return response.data;
  }   

  public async getPlacementInfoAsync(id: number):Promise<IPlacementInfoResponse> 
  {
    const url = 'api/placementInfo/get';

    const response = await this.get<IPlacementInfoResponse>(url);
    return response.data;
  }    

  public async getPlacementInfosAsync(request: IPlacementInfosRequest):Promise<IPlacementInfosResponse>
  {
    const search:URLSearchParams = createURLSearchParamsFromRequest(request);

    const url = 'api/placementInfo/getall';

    const response = await this.get<IPlacementInfosResponse>(url, {params: search});
    return response.data;
  }  

  public async removePlacementInfoAsync(id: TKey):Promise<IResponse> 
  {
    const delet:URLSearchParams = new URLSearchParams();
    delet.append('id', id.toString())

    const url = 'api/placementInfo/delete';

    const response = await this.delete<IResponse>(url, {params: delet});
    return response.data;
  }    
}

/**
 * Глобальный экземпляр для доступа к Api для работы с местоположением персонажа
 */
export const PlacementInfoApi = PlacementInfoApiService.Instance;