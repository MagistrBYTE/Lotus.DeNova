import { IResponse } from 'src/core/types/Response';
import { TKey } from 'src/core/types/Key';
import { createURLSearchParamsFromRequest } from 'src/shared/request/utils';
import { AuthApiService } from 'src/shared/auth/api/AuthApiService';
import { ISelectOption } from 'src/core/types/SelectOption';
import { IRace } from '../domain/Race';
import { IRaceCreateRequest } from './RaceCreateRequest';
import { IRacesRequest } from './RacesRequest';
import { IRacesResponse } from './RacesResponse';
import { IRaceResponse } from './RaceResponse';
import { IRaceRequest } from './RaceRequest';

class RaceApiService extends AuthApiService 
{
  private static _RaceApi: RaceApiService;

  public static get Instance(): RaceApiService 
  {
    return (this._RaceApi || (this._RaceApi = new this()));
  }

  constructor()
  {
    super();
    this.createRaceAsync = this.createRaceAsync.bind(this);
    this.updateRaceAsync = this.updateRaceAsync.bind(this);
    this.getRaceAsync = this.getRaceAsync.bind(this);
    this.getRacesAsync = this.getRacesAsync.bind(this);
    this.removeRaceAsync = this.removeRaceAsync.bind(this);
    this.getRacesAsOptionsAsync = this.getRacesAsOptionsAsync.bind(this);
  } 

  public async createRaceAsync(createParams: IRaceCreateRequest):Promise<IRaceResponse> 
  {
    const url = 'api/race/create';

    const response = await this.post<IRaceResponse, IRaceCreateRequest>(url, createParams);
    return response.data;
  }

  public async updateRaceAsync(updatedRace: IRaceRequest):Promise<IRaceResponse> 
  {
    const url = 'api/race/update';

    const response = await this.put<IRaceResponse, IRaceRequest>(url, updatedRace);
    return response.data;
  }   

  public async getRaceAsync(id: number):Promise<IRaceResponse> 
  {
    const url = 'api/race/get';

    const response = await this.get<IRaceResponse>(url);
    return response.data;
  }    

  public async getRacesAsync(request: IRacesRequest):Promise<IRacesResponse>
  {
    const search:URLSearchParams = createURLSearchParamsFromRequest(request);

    const url = 'api/race/getall';

    const response = await this.get<IRacesResponse>(url, {params: search});
    return response.data;
  }  

  public async removeRaceAsync(id: TKey):Promise<IResponse> 
  {
    const delet:URLSearchParams = new URLSearchParams();
    delet.append('id', id.toString())

    const url = 'api/race/delete';

    const response = await this.delete<IResponse>(url, {params: delet});
    return response.data;
  }

  public async getRacesAsOptionsAsync():Promise<ISelectOption[]>
  {
    const search:URLSearchParams = createURLSearchParamsFromRequest();

    const url = 'api/race/getall';

    const response = await this.get<IRacesResponse>(url, {params: search});

    const payload:IRace[] = response.data.payload!;

    const options:ISelectOption[] = payload.map((x)=>
    {
      const option: ISelectOption = {text: x.displayName!, value: x.id};
      return option;
    });

    return Promise.resolve<ISelectOption[]>(options); 
  }
}

/**
 * Глобальный экземпляр для доступа к Api для работы с расами
 */
export const RaceApi = RaceApiService.Instance;