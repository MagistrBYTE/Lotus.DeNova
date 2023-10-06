import { useEffect, useState } from 'react';
import { ISelectOption } from 'src/shared/types/SelectOption';
import { ScenarioTypeApi } from '../api/ScenarioTypeApiService';


export const useScenarioTypeOptions = ():ISelectOption[] => 
{
  const [scenarioOptions, setScenarioTypeOptions] = useState<ISelectOption[]>([]);

  useEffect(() => 
  {
    const response = ScenarioTypeApi.getScenarioTypesAsOptionsAsync();
    response.then((value)=>
    {
      setScenarioTypeOptions(value);
    })
  }, []);

  return scenarioOptions;
};