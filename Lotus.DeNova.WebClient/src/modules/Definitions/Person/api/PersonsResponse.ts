import { IResponsePage } from 'src/core/types/Response';
import { IPerson } from '../domain/Person';

export interface IPersonsResponse extends IResponsePage<IPerson>
{
  
}