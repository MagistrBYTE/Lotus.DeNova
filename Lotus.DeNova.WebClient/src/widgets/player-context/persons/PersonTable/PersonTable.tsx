import React, { ReactElement } from 'react';
import { IPerson, PersonApi } from 'src/modules/player-context/person';
import { usePersonObjectInfo } from 'src/modules/player-context/person/hooks/usePersonPropertiesInfo';
import { IFormCreatedItem, TableView } from 'src/ui/components/DataView';
import { CreatePersonForm } from '../CreatePersonForm/CreatePersonForm';

export const PersonTable: React.FC = () => 
{
  const objectInfo = usePersonObjectInfo();

  const onSetCreatedPersonHandle = (args: IFormCreatedItem<IPerson|null>):ReactElement =>
  {
    return <CreatePersonForm 
      open={args.open}
      onClose={args.onClose}
      onCreate={args.onCreate}
      onCreatePerson={args.onCreatedItem} />
  }

  return (
    <TableView<IPerson> 
      objectInfo={objectInfo}
      enableColumnResizing={true}
      onGetItems={PersonApi.getPersonsAsync}
      onUpdateItem={PersonApi.updatePersonAsync}
      onDeleteItem={PersonApi.removePersonAsync}
      formCreated={onSetCreatedPersonHandle}/>
  );
};