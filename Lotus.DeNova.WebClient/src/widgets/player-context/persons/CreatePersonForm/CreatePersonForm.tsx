import { Button, Dialog, DialogActions, DialogContent } from '@mui/material';
import React, { useState } from 'react';
import { TokenHelper } from 'src/modules/auth';
import { useRaceTypeOptions } from 'src/modules/game-types/race-type';
import { IPerson, PersonApi } from 'src/modules/player-context/person';
import { IImageSource, ImageDatabase } from 'src/resources/image';
import { localization } from 'src/resources/localization';
import { DialogAppBar } from 'src/ui/components/Display';
import { ImageGallery, InputText, OneSelect } from 'src/ui/components/Editor';
import { VerticalStack } from 'src/ui/components/Layout';

export interface ICreatePersonFormProps
{
  open: boolean;
  onClose: ()=>void;
  onCreate: ()=>void;
  onCreatePerson: (createdItem: IPerson|null)=>void
}

export const CreatePersonForm: React.FC<ICreatePersonFormProps> = ({open, onClose, onCreate, onCreatePerson}:ICreatePersonFormProps) => 
{
  const [personName, setPersonName] = useState<string>('');
  const [personRaceTypeId, setPersonRaceTypeId] = useState<number>(1);
  const [personAvatar, setPersonAvatar] = useState<IImageSource|null>(null);
  const optionsRaceType = useRaceTypeOptions();

  const handleCreatePerson = async () =>
  {
    const userId = TokenHelper.getUserId()!;
    const response = await PersonApi.createPersonAsync(
      {
        userId: userId,
        name: personName, 
        raceId: personRaceTypeId, 
        avatarId:personAvatar?.id,  
        isLocalAvatar: true
      });
    if(response.payload)
    {
      onCreatePerson(response.payload);
      onCreate();
    }
    else
    {
      onClose();
    }
  }

  return (
    <Dialog
      open={open}
      onClose={onClose}>
      <DialogAppBar title={localization.person.createPerson} onClose={onClose}/>          
      <DialogContent>
        <VerticalStack gap={1}>
          <ImageGallery 
            label={localization.person.avatar}
            fullWidth
            variant='outlined'
            sx={{paddingLeft: '0px', minHeight: '40px'}}
            labelStyle={{p:1, width: '100px'}}
            images={ImageDatabase.avatars} 
            onSetSelectedImage={setPersonAvatar} />
          <InputText
            fullWidth
            size='small'
            label={localization.person.name}
            labelStyle={{p:1, width: '100px'}}
            variant='outlined'
            value={personName}
            onSetValue={setPersonName}
          />
          <OneSelect<number>
            fullWidth
            size='small'
            label={localization.person.raceId}
            labelStyle={{p:1, width: '100px'}}
            options={optionsRaceType} 
            onSetSelectedValue={setPersonRaceTypeId} />
        </VerticalStack>
      </DialogContent>
      <DialogActions>
        <Button variant='outlined' onClick={onClose}>{localization.actions.cancel}</Button>
        <Button variant='outlined' color='primary' onClick={handleCreatePerson}>{localization.actions.confirm}</Button>
      </DialogActions>
    </Dialog>
  );
};