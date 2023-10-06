import { useEffect, useState } from 'react';
import { ISelectOption } from 'src/shared/types/SelectOption';
import { RaceTypeApi } from '../api/RaceTypeApiService';


export const useRaceTypeOptions = ():ISelectOption[] => 
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

  return raceOptions;
};