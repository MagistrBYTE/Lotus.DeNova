import { IResponse } from 'src/core/types/Response';
import { TKey } from 'src/core/types/Key';
import { createURLSearchParamsFromRequest } from 'src/shared/request/utils';
import { AuthApiService } from 'src/shared/auth/api/AuthApiService';
import { IAstrologyCreateRequest } from './AstrologyCreateRequest';
import { IAstrologiesRequest } from './AstrologiesRequest';
import { IAstrologiesResponse } from './AstrologiesResponse';
import { IAstrologyResponse } from './AstrologyResponse';
import { IAstrologyRequest } from './AstrologyRequest';

class AstrologyApiService extends AuthApiService 
{
  private static _AstrologyApi: AstrologyApiService;

  public static get Instance(): AstrologyApiService 
  {
    return (this._AstrologyApi || (this._AstrologyApi = new this()));
  }

  constructor()
  {
    super();
    this.createAstrologyAsync = this.createAstrologyAsync.bind(this);
    this.updateAstrologyAsync = this.updateAstrologyAsync.bind(this);
    this.getAstrologyAsync = this.getAstrologyAsync.bind(this);
    this.getAstrologiesAsync = this.getAstrologiesAsync.bind(this);
    this.removeAstrologyAsync = this.removeAstrologyAsync.bind(this);
  } 

  public async createAstrologyAsync(createParams: IAstrologyCreateRequest):Promise<IAstrologyResponse> 
  {
    const url = 'api/astrology/create';

    const response = await this.post<IAstrologyResponse, IAstrologyCreateRequest>(url, createParams);
    return response.data;
  }

  public async updateAstrologyAsync(updatedAstrology: IAstrologyRequest):Promise<IAstrologyResponse> 
  {
    const url = 'api/astrology/update';

    const response = await this.put<IAstrologyResponse, IAstrologyRequest>(url, updatedAstrology);
    return response.data;
  }   

  public async getAstrologyAsync(id: number):Promise<IAstrologyResponse> 
  {
    const url = 'api/astrology/get';

    const response = await this.get<IAstrologyResponse>(url);
    return response.data;
  }    

  public async getAstrologiesAsync(request: IAstrologiesRequest):Promise<IAstrologiesResponse>
  {
    const search:URLSearchParams = createURLSearchParamsFromRequest(request);

    const url = 'api/astrology/getall';

    const response = await this.get<IAstrologiesResponse>(url, {params: search});
    return response.data;
  }  

  public async removeAstrologyAsync(id: TKey):Promise<IResponse> 
  {
    const delet:URLSearchParams = new URLSearchParams();
    delet.append('id', id.toString())

    const url = 'api/astrology/delete';

    const response = await this.delete<IResponse>(url, {params: delet});
    return response.data;
  }    
}

/**
 * Глобальный экземпляр для доступа к Api для работы с астрологическими данными
 */
export const AstrologyApi = AstrologyApiService.Instance;