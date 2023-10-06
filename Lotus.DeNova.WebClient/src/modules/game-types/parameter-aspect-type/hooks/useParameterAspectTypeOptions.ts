import { useEffect, useState } from 'react';
import { ISelectOption } from 'src/shared/types/SelectOption';
import { ParameterAspectTypeApi } from '../api/ParameterAspectTypeApiService';


export const useParameterAspectTypeOptions = ():ISelectOption[] => 
{
  const [parameterOptions, setParameterAspectTypeOptions] = useState<ISelectOption[]>([]);

  useEffect(() => 
  {
    const response = ParameterAspectTypeApi.getParameterAspectTypesAsOptionsAsync();
    response.then((value)=>
    {
      setParameterAspectTypeOptions(value);
    })
  }, []);

  return parameterOptions;
};