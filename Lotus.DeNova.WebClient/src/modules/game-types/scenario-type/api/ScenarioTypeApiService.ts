import { AuthApiService } from 'src/modules/auth';
import { TKey } from 'src/shared/types/Key';
import { IResponse } from 'src/shared/types/Response';
import { ISelectOption } from 'src/shared/types/SelectOption';
import { createURLSearchParamsFromRequest } from 'src/shared/utils/utilsRequest';
import { IScenarioType } from '../domain/ScenarioType';
import { IScenarioTypeCreateRequest } from './ScenarioTypeCreateRequest';
import { IScenarioTypesRequest } from './ScenarioTypesRequest';
import { IScenarioTypesResponse } from './ScenarioTypesResponse';
import { IScenarioTypeResponse } from './ScenarioTypeResponse';
import { IScenarioTypeRequest } from './ScenarioTypeRequest';

class ScenarioTypeApiService extends AuthApiService 
{
  private static _ScenarioTypeApi: ScenarioTypeApiService;

  public static get Instance(): ScenarioTypeApiService 
  {
    return (this._ScenarioTypeApi || (this._ScenarioTypeApi = new this()));
  }

  constructor()
  {
    super();
    this.createScenarioTypeAsync = this.createScenarioTypeAsync.bind(this);
    this.updateScenarioTypeAsync = this.updateScenarioTypeAsync.bind(this);
    this.getScenarioTypeAsync = this.getScenarioTypeAsync.bind(this);
    this.getScenarioTypesAsync = this.getScenarioTypesAsync.bind(this);
    this.removeScenarioTypeAsync = this.removeScenarioTypeAsync.bind(this);
    this.getScenarioTypesAsOptionsAsync = this.getScenarioTypesAsOptionsAsync.bind(this);
  } 

  public async createScenarioTypeAsync(createParams: IScenarioTypeCreateRequest):Promise<IScenarioTypeResponse> 
  {
    const url = 'api/scenarioType/create';

    const response = await this.post<IScenarioTypeResponse, IScenarioTypeCreateRequest>(url, createParams);
    return response.data;
  }

  public async updateScenarioTypeAsync(updatedScenarioType: IScenarioTypeRequest):Promise<IScenarioTypeResponse> 
  {
    const url = 'api/scenarioType/update';

    const response = await this.put<IScenarioTypeResponse, IScenarioTypeRequest>(url, updatedScenarioType);
    return response.data;
  }   

  public async getScenarioTypeAsync(id: number):Promise<IScenarioTypeResponse> 
  {
    const query:URLSearchParams = new URLSearchParams();
    query.append('id', id.toString());

    const url = 'api/scenarioType/get';

    const response = await this.get<IScenarioTypeResponse>(url, query);
    return response.data;
  }    

  public async getScenarioTypesAsync(request: IScenarioTypesRequest):Promise<IScenarioTypesResponse>
  {
    const search:URLSearchParams = createURLSearchParamsFromRequest(request);

    const url = 'api/scenarioType/getall';

    const response = await this.get<IScenarioTypesResponse>(url, {params: search});
    return response.data;
  }  

  public async removeScenarioTypeAsync(id: number):Promise<IResponse> 
  {
    const delet:URLSearchParams = new URLSearchParams();
    delet.append('id', id.toString())

    const url = 'api/scenarioType/delete';

    const response = await this.delete<IResponse>(url, {params: delet});
    return response.data;
  }

  public async getScenarioTypesAsOptionsAsync():Promise<ISelectOption[]>
  {
    const search:URLSearchParams = createURLSearchParamsFromRequest();

    const url = 'api/scenarioType/getall';

    const response = await this.get<IScenarioTypesResponse>(url, {params: search});

    const payload:IScenarioType[] = response.data.payload!;

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
export const ScenarioTypeApi = ScenarioTypeApiService.Instance;