import React from 'react';
import { ListView } from 'src/ui/components/DataView/ListView/ListView';
import { PersonApi } from 'src/modules/UserSlice/Person/api/PersonApiService';
import { IPerson } from 'src/modules/UserSlice/Person/domain/Person';
import { PersonProperties } from 'src/modules/UserSlice/Person/domain/PersonPropertiesInfo';
import { PersonCard } from '../PersonCard';

export const PersonList: React.FC = () => 
{
  return (
    <ListView 
      onGetItems={PersonApi.getPersonsAsync}
      propertiesInfo={PersonProperties}
      renderList={(list)=>
      {
        const groups:IPerson[] = list as IPerson[];
        return (<>
          {
            groups.map((group, index)=>
            {
              return <PersonCard key={index} {...group}/>
            })
          }
        </>)
      }}
    />
  );
};