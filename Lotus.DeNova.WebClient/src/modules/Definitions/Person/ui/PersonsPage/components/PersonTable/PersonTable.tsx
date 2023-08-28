import React, { ReactElement } from 'react';
import { PersonApi } from 'src/modules/Definitions/Person/api/PersonApiService';
import { IPerson } from 'src/modules/Definitions/Person/domain/Person';
import { PersonProperties } from 'src/modules/Definitions/Person/domain/PersonPropertiesInfo';
import { TableViewEdit } from 'src/ui/components/DataView/TableViewEdit';
import { IFormCreatedItem } from 'src/ui/components/DataView/TableViewEdit/TableViewEdit';
import { usePersonPropertiesInfo } from 'src/modules/Definitions/Person/hooks/usePersonPropertiesInfo';
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