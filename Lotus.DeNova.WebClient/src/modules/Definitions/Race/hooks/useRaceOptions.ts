import { useEffect, useState } from 'react';
import { ISelectOption } from 'src/core/types/SelectOption';
import { RaceApi } from '../../Race';

export const useRaceOptions = ():ISelectOption[] => 
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

  return raceOptions;
};