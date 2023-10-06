import { localization } from 'src/resources/localization';
import { ObjectInfoBase } from 'src/shared/objectInfo/ObjectInfo';
import { IPropertyDescriptor } from 'src/shared/objectInfo/PropertyDescriptor';
import { PropertyTypeEnum } from 'src/shared/objectInfo/PropertyType';
import { FilterFunctionEnum } from 'src/shared/types/FilterFunction';
import { ValidationResultSuccess } from 'src/shared/validation/ValidationResult';
import { IPerson } from './Person';

export class PersonObjectInfo extends ObjectInfoBase<IPerson>
{
  private static _personObjectInfo: PersonObjectInfo;

  public static get Instance(): PersonObjectInfo 
  {
    return (this._personObjectInfo || (this._personObjectInfo = new this()));
  }

  public descriptors: IPropertyDescriptor[] = [];

  constructor() 
  {
    super();
    this.Init();
  }

  private Init()
  {
    const idProp:IPropertyDescriptor = 
    {
      fieldName: 'id',
      name: localization.person.id,
      desc: localization.person.idDesc,
      propertyType: PropertyTypeEnum.Integer,
      sorting:
      {
        enabled: true
      }
    }

    this.descriptors.push(idProp);

    const avatarProp:IPropertyDescriptor = 
    {
      fieldName: 'avatarId',
      name: localization.person.avatar,
      desc: localization.person.avatarDesc,
      propertyType: PropertyTypeEnum.Integer,
      viewImage: true,
      editing: 
      {
        enabled: true,
        required: false,
        editorType: 'select',
        onValidation: (item: IPerson|null)=> { return ValidationResultSuccess } 
      }      
    }

    this.descriptors.push(avatarProp);    

    const nameProp:IPropertyDescriptor = 
    {
      fieldName: 'name',
      name: localization.person.name,
      desc: localization.person.nameDesc,
      propertyType: PropertyTypeEnum.String,
      editing: 
      {
        enabled: true,
        required: true,
        editorType: 'text',
        onValidation: (item: IPerson|null)=>
        {
          if(item && item.name === '')
          {
            return {error: true, text: localization.validation.required};
          }
          if(item && item.name.length > 20)
          {
            return {error: true, text: localization.validation.maxLength(20)};
          }        
          return {error: false, text: ''};
        }
      },
      filtering:
      {
        functionDefault: FilterFunctionEnum.Contains,
        enabled: true
      },
      sorting:
      {
        enabled: true
      }
    }

    this.descriptors.push(nameProp);

    const raceIdProp:IPropertyDescriptor = 
    {
      fieldName: 'raceId',
      name: localization.person.raceId,
      desc: localization.person.raceIdDesc,
      propertyType: PropertyTypeEnum.Integer,
      editing: 
      {
        enabled: true,
        required: true,
        editorType: 'select',
        onValidation: (item: IPerson|null)=> { return ValidationResultSuccess } 
      },
      filtering:
      {
        functionDefault: FilterFunctionEnum.IncludeAny,
        variant: 'multi-select',
        enabled: true
      },
      sorting:
      {
        enabled: true
      }
    }

    this.descriptors.push(raceIdProp);       
  }
}

/**
 * Глобальный экземпляр для доступа к описанию свойств персонажа
 */
export const PersonProperties = PersonObjectInfo.Instance;