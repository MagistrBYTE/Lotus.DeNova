import { useEffect, useState } from 'react';
import { ISelectOption } from 'src/shared/types/SelectOption';
import { ParameterTypeApi } from '../api/ParameterTypeApiService';


export const useParameterTypeOptions = ():ISelectOption[] => 
{
  const [parameterOptions, setParameterTypeOptions] = useState<ISelectOption[]>([]);

  useEffect(() => 
  {
    const response = ParameterTypeApi.getParameterTypesAsOptionsAsync();
    response.then((value)=>
    {
      setParameterTypeOptions(value);
    })
  }, []);

  return parameterOptions;
};