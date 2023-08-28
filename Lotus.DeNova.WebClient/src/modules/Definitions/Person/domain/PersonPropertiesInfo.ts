import { FilterFunctionEnum } from 'src/shared/filtering/FilterFunction';
import { localization } from 'src/shared/localization';
import { IPropertiesInfo, PropertiesInfoBase } from 'src/shared/reflection/PropertiesInfo';
import { IPropertyDescriptor } from 'src/shared/reflection/PropertyDescriptor';
import { PropertyTypeEnum } from 'src/shared/reflection/PropertyType';
import { ValidationResultSuccess } from 'src/shared/validation/ValidationResult';
import { IPerson } from './Person';

export class PersonPropertiesInfo extends PropertiesInfoBase<IPerson>
{
  private static _rolePropertiesInfo: PersonPropertiesInfo;

  public static get Instance(): PersonPropertiesInfo 
  {
    return (this._rolePropertiesInfo || (this._rolePropertiesInfo = new this()));
  }

  public descriptors: IPropertyDescriptor[] = [];

  constructor() 
  {
    super();
    this.Init();
    this.getProperties = this.getProperties.bind(this);
    this.getPropertyDescriptorByName = this.getPropertyDescriptorByName.bind(this);    
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
      fieldName: 'avatar',
      name: localization.person.avatar,
      desc: localization.person.avatarDesc,
      propertyType: PropertyTypeEnum.Integer,
      viewImage: true
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
        functionDefault: FilterFunctionEnum.Equals,
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
export const PersonProperties = PersonPropertiesInfo.Instance;