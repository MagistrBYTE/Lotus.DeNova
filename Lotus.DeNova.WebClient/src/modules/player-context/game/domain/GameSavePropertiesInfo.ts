import { localization } from 'src/resources/localization';
import { ObjectInfoBase } from 'src/shared/objectInfo/ObjectInfo';
import { IPropertyDescriptor } from 'src/shared/objectInfo/PropertyDescriptor';
import { PropertyTypeEnum } from 'src/shared/objectInfo/PropertyType';
import { IGameSave } from './GameSave';

export class GameSaveObjectInfo extends ObjectInfoBase<IGameSave>
{
  private static _gameSaveObjectInfo: GameSaveObjectInfo;

  public static get Instance(): GameSaveObjectInfo 
  {
    return (this._gameSaveObjectInfo || (this._gameSaveObjectInfo = new this()));
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
      name: localization.gameSave.id,
      desc: localization.gameSave.idDesc,
      propertyType: PropertyTypeEnum.Integer,
      sorting:
      {
        enabled: true
      }
    }

    this.descriptors.push(idProp);

    const nameProp:IPropertyDescriptor = 
    {
      fieldName: 'name',
      name: localization.gameSave.name,
      desc: localization.gameSave.nameDesc,
      propertyType: PropertyTypeEnum.String,
      sorting: 
      {
        enabled: true
      }      
    }

    this.descriptors.push(nameProp);  
  }
}

/**
 * Глобальный экземпляр для доступа к описанию свойств сохранения игры
 */
export const GameSaveProperties = GameSaveObjectInfo.Instance;