import { AuthApiService } from 'src/modules/auth';
import { TKey } from 'src/shared/types/Key';
import { IResponse } from 'src/shared/types/Response';
import { createURLSearchParamsFromRequest } from 'src/shared/utils/utilsRequest';
import { IAstrologyTypeRequest } from './AstrologyTypeRequest';
import { IAstrologyTypeResponse } from './AstrologyTypeResponse';
import { IAstrologyTypeCreateRequest } from './AstrologyTypeCreateRequest';
import { IAstrologyTypesRequest } from './AstrologyTypesRequest';
import { IAstrologyTypesResponse } from './AstrologyTypesResponse';

class AstrologyTypeApiService extends AuthApiService 
{
  private static _AstrologyTypeApi: AstrologyTypeApiService;

  public static get Instance(): AstrologyTypeApiService 
  {
    return (this._AstrologyTypeApi || (this._AstrologyTypeApi = new this()));
  }

  constructor()
  {
    super();
    this.createAstrologyTypeAsync = this.createAstrologyTypeAsync.bind(this);
    this.updateAstrologyTypeAsync = this.updateAstrologyTypeAsync.bind(this);
    this.getAstrologyTypeAsync = this.getAstrologyTypeAsync.bind(this);
    this.getAstrologyTypesAsync = this.getAstrologyTypesAsync.bind(this);
    this.removeAstrologyTypeAsync = this.removeAstrologyTypeAsync.bind(this);
  } 

  public async createAstrologyTypeAsync(createParams: IAstrologyTypeCreateRequest):Promise<IAstrologyTypeResponse> 
  {
    const url = 'api/astrologyType/create';

    const response = await this.post<IAstrologyTypeResponse, IAstrologyTypeCreateRequest>(url, createParams);
    return response.data;
  }

  public async updateAstrologyTypeAsync(updatedAstrologyType: IAstrologyTypeRequest):Promise<IAstrologyTypeResponse> 
  {
    const url = 'api/astrologyType/update';

    const response = await this.put<IAstrologyTypeResponse, IAstrologyTypeRequest>(url, updatedAstrologyType);
    return response.data;
  }   

  public async getAstrologyTypeAsync(id: number):Promise<IAstrologyTypeResponse> 
  {
    const query:URLSearchParams = new URLSearchParams();
    query.append('id', id.toString());

    const url = 'api/astrologyType/get';

    const response = await this.get<IAstrologyTypeResponse>(url, query);
    return response.data;
  }    

  public async getAstrologyTypesAsync(request: IAstrologyTypesRequest):Promise<IAstrologyTypesResponse>
  {
    const search:URLSearchParams = createURLSearchParamsFromRequest(request);

    const url = 'api/astrologyType/getall';

    const response = await this.get<IAstrologyTypesResponse>(url, {params: search});
    return response.data;
  }  

  public async removeAstrologyTypeAsync(id: number):Promise<IResponse> 
  {
    const delet:URLSearchParams = new URLSearchParams();
    delet.append('id', id.toString())

    const url = 'api/astrologyType/delete';

    const response = await this.delete<IResponse>(url, {params: delet});
    return response.data;
  }    
}

/**
 * Глобальный экземпляр для доступа к Api для работы с астрологическими данными
 */
export const AstrologyTypeApi = AstrologyTypeApiService.Instance;