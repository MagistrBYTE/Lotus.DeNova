import { IResponse } from 'src/core/types/Response';
import { TKey } from 'src/core/types/Key';
import { createURLSearchParamsFromRequest } from 'src/shared/request/utils';
import { AuthApiService } from 'src/shared/auth/api/AuthApiService';
import { IImageCreateRequest } from './ImageCreateRequest';
import { IImagesRequest } from './ImagesRequest';
import { IImagesResponse } from './ImagesResponse';
import { IImageResponse } from './ImageResponse';
import { IImageRequest } from './ImageRequest';

class ImageApiService extends AuthApiService 
{
  private static _ImageApi: ImageApiService;

  public static get Instance(): ImageApiService 
  {
    return (this._ImageApi || (this._ImageApi = new this()));
  }

  constructor()
  {
    super();
    this.createImageAsync = this.createImageAsync.bind(this);
    this.updateImageAsync = this.updateImageAsync.bind(this);
    this.getImageAsync = this.getImageAsync.bind(this);
    this.getImagesAsync = this.getImagesAsync.bind(this);
    this.removeImageAsync = this.removeImageAsync.bind(this);
  } 

  public async createImageAsync(createParams: IImageCreateRequest):Promise<IImageResponse> 
  {
    const url = 'api/image/create';

    const response = await this.post<IImageResponse, IImageCreateRequest>(url, createParams);
    return response.data;
  }

  public async updateImageAsync(updatedImage: IImageRequest):Promise<IImageResponse> 
  {
    const url = 'api/image/update';

    const response = await this.put<IImageResponse, IImageRequest>(url, updatedImage);
    return response.data;
  }   

  public async getImageAsync(id: number):Promise<IImageResponse> 
  {
    const url = 'api/image/get';

    const response = await this.get<IImageResponse>(url);
    return response.data;
  }    

  public async getImagesAsync(request: IImagesRequest):Promise<IImagesResponse>
  {
    const search:URLSearchParams = createURLSearchParamsFromRequest(request);

    const url = 'api/image/getall';

    const response = await this.get<IImagesResponse>(url, {params: search});
    return response.data;
  }  

  public async removeImageAsync(id: TKey):Promise<IResponse> 
  {
    const delet:URLSearchParams = new URLSearchParams();
    delet.append('id', id.toString())

    const url = 'api/image/delete';

    const response = await this.delete<IResponse>(url, {params: delet});
    return response.data;
  }    
}

/**
 * Глобальный экземпляр для доступа к Api для работы с изображениями
 */
export const ImageApi = ImageApiService.Instance;