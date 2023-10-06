import React from 'react';
import { ListView } from 'src/ui/components/DataView/ListView/ListView';
import { TPlacementDensity } from 'src/ui/types/PlacementDensity';
import { IPerson, PersonApi } from 'src/modules/player-context/person';
import { usePersonObjectInfo } from 'src/modules/player-context/person/hooks/usePersonPropertiesInfo';
import { IGrouping } from 'src/shared/types/Grouping';
import { PersonCard } from '../PersonCard';

export const PersonList: React.FC = () => 
{
  const objectInfo = usePersonObjectInfo();
  
  const renderList = (list: IPerson[] | IGrouping<IPerson>[], density: TPlacementDensity) =>
  {
    const persons:IPerson[] = list as IPerson[];
    return (<>
      {
        persons.map((person, index)=>
        {
          return <PersonCard key={index} person={person} objectInfo={objectInfo} density={density} />
        })
      }
    </>)
  }

  return (
    <ListView 
      onGetItems={PersonApi.getPersonsAsync}
      objectInfo={objectInfo}
      renderList={renderList}
    />
  );
};