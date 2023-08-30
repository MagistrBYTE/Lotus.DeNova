import { useEffect, useState } from 'react';
import { ISelectOption } from 'src/core/types/SelectOption';
import { RaceApi } from 'src/modules/DefinitionsSlice/Race';
import { PersonPropertiesInfo, PersonProperties } from '../domain/PersonPropertiesInfo';


export const usePersonPropertiesInfo = ():PersonPropertiesInfo => 
{
  const [raceOptions, setRaceOptions] = useState<ISelectOption[]>([]);

  useEffect(() => 
  {
    const response = RaceApi.getRacesAsOptionsAsync();
    response.then((value)=>
    {
      setRaceOptions(value);
    })
  }, []);

  const prop = PersonProperties.getPropertyDescriptorByName('raceId');
  prop.options = raceOptions;

  return PersonProperties;
};