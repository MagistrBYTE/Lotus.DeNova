import { AuthApiService } from 'src/modules/auth';
import { IResponse } from 'src/shared/types/Response';
import { createURLSearchParamsFromRequest } from 'src/shared/utils/utilsRequest';
import { IPlacementStateCreateRequest } from './PlacementStateCreateRequest';
import { IPlacementStatesRequest } from './PlacementStatesRequest';
import { IPlacementStatesResponse } from './PlacementStatesResponse';
import { IPlacementStateResponse } from './PlacementStateResponse';
import { IPlacementStateRequest } from './PlacementStateRequest';

class PlacementStateApiService extends AuthApiService 
{
  private static _PlacementStateApi: PlacementStateApiService;

  public static get Instance(): PlacementStateApiService 
  {
    return (this._PlacementStateApi || (this._PlacementStateApi = new this()));
  }

  constructor()
  {
    super();
    this.createPlacementStateAsync = this.createPlacementStateAsync.bind(this);
    this.updatePlacementStateAsync = this.updatePlacementStateAsync.bind(this);
    this.getPlacementStateAsync = this.getPlacementStateAsync.bind(this);
    this.getPlacementStatesAsync = this.getPlacementStatesAsync.bind(this);
    this.removePlacementStateAsync = this.removePlacementStateAsync.bind(this);
  } 

  public async createPlacementStateAsync(createParams: IPlacementStateCreateRequest):Promise<IPlacementStateResponse> 
  {
    const url = 'api/placementState/create';

    const response = await this.post<IPlacementStateResponse, IPlacementStateCreateRequest>(url, createParams);
    return response.data;
  }

  public async updatePlacementStateAsync(updatedPlacementState: IPlacementStateRequest):Promise<IPlacementStateResponse> 
  {
    const url = 'api/placementState/update';

    const response = await this.put<IPlacementStateResponse, IPlacementStateRequest>(url, updatedPlacementState);
    return response.data;
  }   

  public async getPlacementStateAsync(id: string):Promise<IPlacementStateResponse> 
  {
    const query:URLSearchParams = new URLSearchParams();
    query.append('id', id.toString());

    const url = 'api/placementState/get';

    const response = await this.get<IPlacementStateResponse>(url, query);
    return response.data;
  }    

  public async getPlacementStatesAsync(request: IPlacementStatesRequest):Promise<IPlacementStatesResponse>
  {
    const search:URLSearchParams = createURLSearchParamsFromRequest(request);

    const url = 'api/placementState/getall';

    const response = await this.get<IPlacementStatesResponse>(url, {params: search});
    return response.data;
  }  

  public async removePlacementStateAsync(id: string):Promise<IResponse> 
  {
    const delet:URLSearchParams = new URLSearchParams();
    delet.append('id', id.toString())

    const url = 'api/placementState/delete';

    const response = await this.delete<IResponse>(url, {params: delet});
    return response.data;
  }    
}

/**
 * Глобальный экземпляр для доступа к Api для работы с местоположением персонажа
 */
export const PlacementStateApi = PlacementStateApiService.Instance;