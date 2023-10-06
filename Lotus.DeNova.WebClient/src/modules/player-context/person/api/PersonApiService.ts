import { AuthApiService } from 'src/modules/auth';
import { IResponse } from 'src/shared/types/Response';
import { createURLSearchParamsFromRequest } from 'src/shared/utils/utilsRequest';
import { TKey } from 'src/shared/types/Key';
import { IPersonCreateRequest } from './PersonCreateRequest';
import { IPersonsRequest } from './PersonsRequest';
import { IPersonsResponse } from './PersonsResponse';
import { IPersonResponse } from './PersonResponse';
import { IPersonRequest } from './PersonRequest';

class PersonApiService extends AuthApiService 
{
  private static _PersonApi: PersonApiService;

  public static get Instance(): PersonApiService 
  {
    return (this._PersonApi || (this._PersonApi = new this()));
  }

  constructor()
  {
    super();
    this.createPersonAsync = this.createPersonAsync.bind(this);
    this.updatePersonAsync = this.updatePersonAsync.bind(this);
    this.getPersonAsync = this.getPersonAsync.bind(this);
    this.getPersonsAsync = this.getPersonsAsync.bind(this);
    this.removePersonAsync = this.removePersonAsync.bind(this);
  } 

  public async createPersonAsync(createParams: IPersonCreateRequest):Promise<IPersonResponse> 
  {
    const url = 'api/person/create';

    const response = await this.post<IPersonResponse, IPersonCreateRequest>(url, createParams);
    return response.data;
  }

  public async updatePersonAsync(updatedPerson: IPersonRequest):Promise<IPersonResponse> 
  {
    const url = 'api/person/update';

    const response = await this.put<IPersonResponse, IPersonRequest>(url, updatedPerson);
    return response.data;
  }   

  public async getPersonAsync(id: string):Promise<IPersonResponse> 
  {
    const query:URLSearchParams = new URLSearchParams();
    query.append('id', id.toString());

    const url = 'api/person/get';

    const response = await this.get<IPersonResponse>(url, query);
    return response.data;
  }    

  public async getPersonsAsync(request: IPersonsRequest):Promise<IPersonsResponse>
  {
    const search:URLSearchParams = createURLSearchParamsFromRequest(request);

    const url = 'api/person/getall';

    const response = await this.get<IPersonsResponse>(url, {params: search});
    return response.data;
  }  

  public async removePersonAsync(id: TKey):Promise<IResponse> 
  {
    const delet:URLSearchParams = new URLSearchParams();
    delet.append('id', id.toString())

    const url = 'api/person/delete';

    const response = await this.delete<IResponse>(url, {params: delet});
    return response.data;
  }    
}

/**
 * Глобальный экземпляр для доступа к Api для работы с персонажами
 */
export const PersonApi = PersonApiService.Instance;