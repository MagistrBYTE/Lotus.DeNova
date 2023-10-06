import { useEffect, useState } from 'react';
import { RaceTypeApi } from 'src/modules/game-types/race-type';
import { ISelectOption } from 'src/shared/types/SelectOption';
import { PersonObjectInfo, PersonProperties } from '../domain/PersonPropertiesInfo';


export const usePersonObjectInfo = ():PersonObjectInfo => 
{
  const [raceOptions, setRaceTypeOptions] = useState<ISelectOption[]>([]);

  useEffect(() => 
  {
    const response = RaceTypeApi.getRaceTypesAsOptionsAsync();
    response.then((value)=>
    {
      setRaceTypeOptions(value);
    })
  }, []);

  const prop = PersonProperties.getPropertyByName('raceId');
  prop.options = raceOptions;

  return PersonProperties;
};