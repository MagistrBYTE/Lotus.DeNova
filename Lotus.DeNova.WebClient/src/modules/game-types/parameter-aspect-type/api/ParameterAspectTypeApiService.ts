import { AuthApiService } from 'src/modules/auth';
import { TKey } from 'src/shared/types/Key';
import { IResponse } from 'src/shared/types/Response';
import { ISelectOption } from 'src/shared/types/SelectOption';
import { createURLSearchParamsFromRequest } from 'src/shared/utils/utilsRequest';
import { IParameterAspectType } from '../domain/ParameterAspectType';
import { IParameterAspectTypeCreateRequest } from './ParameterAspectTypeCreateRequest';
import { IParameterAspectTypesRequest } from './ParameterAspectTypesRequest';
import { IParameterAspectTypesResponse } from './ParameterAspectTypesResponse';
import { IParameterAspectTypeResponse } from './ParameterAspectTypeResponse';
import { IParameterAspectTypeRequest } from './ParameterAspectTypeRequest';

class ParameterAspectTypeApiService extends AuthApiService 
{
  private static _ParameterAspectTypeApi: ParameterAspectTypeApiService;

  public static get Instance(): ParameterAspectTypeApiService 
  {
    return (this._ParameterAspectTypeApi || (this._ParameterAspectTypeApi = new this()));
  }

  constructor()
  {
    super();
    this.createParameterAspectTypeAsync = this.createParameterAspectTypeAsync.bind(this);
    this.updateParameterAspectTypeAsync = this.updateParameterAspectTypeAsync.bind(this);
    this.getParameterAspectTypeAsync = this.getParameterAspectTypeAsync.bind(this);
    this.getParameterAspectTypesAsync = this.getParameterAspectTypesAsync.bind(this);
    this.removeParameterAspectTypeAsync = this.removeParameterAspectTypeAsync.bind(this);
    this.getParameterAspectTypesAsOptionsAsync = this.getParameterAspectTypesAsOptionsAsync.bind(this);
  } 

  public async createParameterAspectTypeAsync(createParams: IParameterAspectTypeCreateRequest):Promise<IParameterAspectTypeResponse> 
  {
    const url = 'api/parameterAspectType/create';

    const response = await this.post<IParameterAspectTypeResponse, IParameterAspectTypeCreateRequest>(url, createParams);
    return response.data;
  }

  public async updateParameterAspectTypeAsync(updatedParameterAspectType: IParameterAspectTypeRequest):Promise<IParameterAspectTypeResponse> 
  {
    const url = 'api/parameterAspectType/update';

    const response = await this.put<IParameterAspectTypeResponse, IParameterAspectTypeRequest>(url, updatedParameterAspectType);
    return response.data;
  }   

  public async getParameterAspectTypeAsync(id: number):Promise<IParameterAspectTypeResponse> 
  {
    const query:URLSearchParams = new URLSearchParams();
    query.append('id', id.toString());

    const url = 'api/parameterAspectType/get';

    const response = await this.get<IParameterAspectTypeResponse>(url, query);
    return response.data;
  }    

  public async getParameterAspectTypesAsync(request: IParameterAspectTypesRequest):Promise<IParameterAspectTypesResponse>
  {
    const search:URLSearchParams = createURLSearchParamsFromRequest(request);

    const url = 'api/parameterAspectType/getall';

    const response = await this.get<IParameterAspectTypesResponse>(url, {params: search});
    return response.data;
  }  

  public async removeParameterAspectTypeAsync(id: number):Promise<IResponse> 
  {
    const delet:URLSearchParams = new URLSearchParams();
    delet.append('id', id.toString())

    const url = 'api/parameterAspectType/delete';

    const response = await this.delete<IResponse>(url, {params: delet});
    return response.data;
  }

  public async getParameterAspectTypesAsOptionsAsync():Promise<ISelectOption[]>
  {
    const search:URLSearchParams = createURLSearchParamsFromRequest();

    const url = 'api/parameterAspectType/getall';

    const response = await this.get<IParameterAspectTypesResponse>(url, {params: search});

    const payload:IParameterAspectType[] = response.data.payload!;

    const options:ISelectOption[] = payload.map((x)=>
    {
      const option: ISelectOption = {text: x.displayName!, value: x.id};
      return option;
    });

    return Promise.resolve<ISelectOption[]>(options); 
  }
}

/**
 * Глобальный экземпляр для доступа к Api для работы с аспектами параметров существ
 */
export const ParameterAspectTypeApi = ParameterAspectTypeApiService.Instance;