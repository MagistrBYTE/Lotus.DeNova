import React, { ReactElement } from 'react';
import { TableViewEdit } from 'src/ui/components/DataView/TableViewEdit';
import { PersonApi } from 'src/modules/UserSlice/Person/api/PersonApiService';
import { IPerson } from 'src/modules/UserSlice/Person/domain/Person';
import { usePersonPropertiesInfo } from 'src/modules/UserSlice/Person/hooks/usePersonPropertiesInfo';
import { IFormCreatedItem } from 'src/ui/components/DataView/TableViewEdit/TableViewEdit';
import { CreatePersonForm } from '../CreatePersonForm/CreatePersonForm';

export const PersonTable: React.FC = () => 
{
  const propertiesInfo = usePersonPropertiesInfo();

  const onSetCreatedPersonHandle = (args: IFormCreatedItem<IPerson|null>):ReactElement =>
  {
    return <CreatePersonForm 
      open={args.open}
      onClose={args.onClose}
      onCreate={args.onCreate}
      onCreatePerson={args.onCreatedItem} />
  }

  return (
    <TableViewEdit<IPerson> 
      propertiesInfo={propertiesInfo}
      columns={[]}
      data={[]}
      enableColumnResizing={true}
      onGetItems={PersonApi.getPersonsAsync}
      onUpdateItemAsync={PersonApi.updatePersonAsync}
      onDeleteItemAsync={PersonApi.removePersonAsync}
      formCreated={onSetCreatedPersonHandle}/>
  );
};