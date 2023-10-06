import { AuthApiService } from 'src/modules/auth';
import { TKey } from 'src/shared/types/Key';
import { IResponse } from 'src/shared/types/Response';
import { ISelectOption } from 'src/shared/types/SelectOption';
import { createURLSearchParamsFromRequest } from 'src/shared/utils/utilsRequest';
import { IParameterType } from '../domain/ParameterType';
import { IParameterTypeCreateRequest } from './ParameterTypeCreateRequest';
import { IParameterTypesRequest } from './ParameterTypesRequest';
import { IParameterTypesResponse } from './ParameterTypesResponse';
import { IParameterTypeResponse } from './ParameterTypeResponse';
import { IParameterTypeRequest } from './ParameterTypeRequest';

class ParameterTypeApiService extends AuthApiService 
{
  private static _ParameterTypeApi: ParameterTypeApiService;

  public static get Instance(): ParameterTypeApiService 
  {
    return (this._ParameterTypeApi || (this._ParameterTypeApi = new this()));
  }

  constructor()
  {
    super();
    this.createParameterTypeAsync = this.createParameterTypeAsync.bind(this);
    this.updateParameterTypeAsync = this.updateParameterTypeAsync.bind(this);
    this.getParameterTypeAsync = this.getParameterTypeAsync.bind(this);
    this.getParameterTypesAsync = this.getParameterTypesAsync.bind(this);
    this.removeParameterTypeAsync = this.removeParameterTypeAsync.bind(this);
    this.getParameterTypesAsOptionsAsync = this.getParameterTypesAsOptionsAsync.bind(this);
  } 

  public async createParameterTypeAsync(createParams: IParameterTypeCreateRequest):Promise<IParameterTypeResponse> 
  {
    const url = 'api/parameterType/create';

    const response = await this.post<IParameterTypeResponse, IParameterTypeCreateRequest>(url, createParams);
    return response.data;
  }

  public async updateParameterTypeAsync(updatedParameterType: IParameterTypeRequest):Promise<IParameterTypeResponse> 
  {
    const url = 'api/parameterType/update';

    const response = await this.put<IParameterTypeResponse, IParameterTypeRequest>(url, updatedParameterType);
    return response.data;
  }   

  public async getParameterTypeAsync(id: number):Promise<IParameterTypeResponse> 
  {
    const query:URLSearchParams = new URLSearchParams();
    query.append('id', id.toString());

    const url = 'api/parameterType/get';

    const response = await this.get<IParameterTypeResponse>(url, query);
    return response.data;
  }    

  public async getParameterTypesAsync(request: IParameterTypesRequest):Promise<IParameterTypesResponse>
  {
    const search:URLSearchParams = createURLSearchParamsFromRequest(request);

    const url = 'api/parameterType/getall';

    const response = await this.get<IParameterTypesResponse>(url, {params: search});
    return response.data;
  }  

  public async removeParameterTypeAsync(id: number):Promise<IResponse> 
  {
    const delet:URLSearchParams = new URLSearchParams();
    delet.append('id', id.toString())

    const url = 'api/parameterType/delete';

    const response = await this.delete<IResponse>(url, {params: delet});
    return response.data;
  }

  public async getParameterTypesAsOptionsAsync():Promise<ISelectOption[]>
  {
    const search:URLSearchParams = createURLSearchParamsFromRequest();

    const url = 'api/parameterType/getall';

    const response = await this.get<IParameterTypesResponse>(url, {params: search});

    const payload:IParameterType[] = response.data.payload!;

    const options:ISelectOption[] = payload.map((x)=>
    {
      const option: ISelectOption = {text: x.displayName!, value: x.id};
      return option;
    });

    return Promise.resolve<ISelectOption[]>(options); 
  }
}

/**
 * Глобальный экземпляр для доступа к Api для работы с параметрами существ
 */
export const ParameterTypeApi = ParameterTypeApiService.Instance;