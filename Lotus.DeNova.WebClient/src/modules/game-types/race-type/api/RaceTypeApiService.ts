import { AuthApiService } from 'src/modules/auth';
import { TKey } from 'src/shared/types/Key';
import { IResponse } from 'src/shared/types/Response';
import { ISelectOption } from 'src/shared/types/SelectOption';
import { createURLSearchParamsFromRequest } from 'src/shared/utils/utilsRequest';
import { IRaceType } from '../domain/RaceType';
import { IRaceTypeCreateRequest } from './RaceTypeCreateRequest';
import { IRaceTypesRequest } from './RaceTypesRequest';
import { IRaceTypesResponse } from './RaceTypesResponse';
import { IRaceTypeResponse } from './RaceTypeResponse';
import { IRaceTypeRequest } from './RaceTypeRequest';

class RaceTypeApiService extends AuthApiService 
{
  private static _RaceTypeApi: RaceTypeApiService;

  public static get Instance(): RaceTypeApiService 
  {
    return (this._RaceTypeApi || (this._RaceTypeApi = new this()));
  }

  constructor()
  {
    super();
    this.createRaceTypeAsync = this.createRaceTypeAsync.bind(this);
    this.updateRaceTypeAsync = this.updateRaceTypeAsync.bind(this);
    this.getRaceTypeAsync = this.getRaceTypeAsync.bind(this);
    this.getRaceTypesAsync = this.getRaceTypesAsync.bind(this);
    this.removeRaceTypeAsync = this.removeRaceTypeAsync.bind(this);
    this.getRaceTypesAsOptionsAsync = this.getRaceTypesAsOptionsAsync.bind(this);
  } 

  public async createRaceTypeAsync(createParams: IRaceTypeCreateRequest):Promise<IRaceTypeResponse> 
  {
    const url = 'api/raceType/create';

    const response = await this.post<IRaceTypeResponse, IRaceTypeCreateRequest>(url, createParams);
    return response.data;
  }

  public async updateRaceTypeAsync(updatedRaceType: IRaceTypeRequest):Promise<IRaceTypeResponse> 
  {
    const url = 'api/raceType/update';

    const response = await this.put<IRaceTypeResponse, IRaceTypeRequest>(url, updatedRaceType);
    return response.data;
  }   

  public async getRaceTypeAsync(id: number):Promise<IRaceTypeResponse> 
  {
    const query:URLSearchParams = new URLSearchParams();
    query.append('id', id.toString());    

    const url = 'api/raceType/get';

    const response = await this.get<IRaceTypeResponse>(url, query);
    return response.data;
  }    

  public async getRaceTypesAsync(request: IRaceTypesRequest):Promise<IRaceTypesResponse>
  {
    const search:URLSearchParams = createURLSearchParamsFromRequest(request);

    const url = 'api/raceType/getall';

    const response = await this.get<IRaceTypesResponse>(url, {params: search});
    return response.data;
  }  

  public async removeRaceTypeAsync(id: number):Promise<IResponse> 
  {
    const delet:URLSearchParams = new URLSearchParams();
    delet.append('id', id.toString())

    const url = 'api/raceType/delete';

    const response = await this.delete<IResponse>(url, {params: delet});
    return response.data;
  }

  public async getRaceTypesAsOptionsAsync():Promise<ISelectOption[]>
  {
    const search:URLSearchParams = createURLSearchParamsFromRequest();

    const url = 'api/raceType/getall';

    const response = await this.get<IRaceTypesResponse>(url, {params: search});

    const payload:IRaceType[] = response.data.payload!;

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
export const RaceTypeApi = RaceTypeApiService.Instance;