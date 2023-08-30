import { AppBar, Button, Dialog, DialogActions, DialogContent, IconButton, Toolbar } from '@mui/material';
import React, { ChangeEvent, useState } from 'react';
import { localization } from 'src/shared/localization';
import CloseIcon from '@mui/icons-material/Close';
import { OneSelect } from 'src/ui/components/Editor/OneSelect';
import { InputText } from 'src/ui/components/Editor';
import { useRaceOptions } from 'src/modules/DefinitionsSlice/Race';
import { PersonApi } from 'src/modules/UserSlice/Person/api/PersonApiService';
import { IPerson } from 'src/modules/UserSlice/Person/domain/Person';
import { ImageGallery } from 'src/ui/components/Editor/ImageGallery';
import { IImageSource, ImageDatabase } from 'src/shared/image';
import { VerticalStack } from 'src/ui/components/Layout';
import { TokenHelper } from 'src/shared/auth';

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
  const [personRaceId, setPersonRaceId] = useState<number>(1);
  const [personAvatar, setPersonAvatar] = useState<IImageSource|null>(null);
  const optionsRace = useRaceOptions();

  const handleCreatePerson = async () =>
  {
    const userId = TokenHelper.getUserId()!;
    const response = await PersonApi.createPersonAsync(
      {
        userId: userId,
        name: personName, 
        raceId: personRaceId, 
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
      <AppBar sx={{ position: 'relative'}}>
        <Toolbar>
          <IconButton
            edge="start"
            color="inherit"
            onClick={onClose}
            aria-label="close">
            <CloseIcon />
          </IconButton>
          {localization.person.createPerson}
        </Toolbar>
      </AppBar>            
      <DialogContent>
        <VerticalStack gap={1}>
          <ImageGallery 
            label={localization.person.avatar}
            fullWidth
            variant='outlined'
            sx={{paddingLeft: '0px', minHeight: '24px'}}
            labelProps={{p:1, width: '100px'}}
            images={ImageDatabase.avatars} 
            onSetSelectedImage={setPersonAvatar} />

          <InputText
            fullWidth
            size='small'
            label={localization.person.name}
            labelProps={{p:1, width: '100px'}}
            variant='outlined'
            value={personName}
            onSetValue={setPersonName}
          />
          <OneSelect<number>
            fullWidth
            size='small'
            label={localization.person.raceId}
            labelProps={{p:1, width: '100px'}}
            options={optionsRace} 
            onSetSelectedValue={setPersonRaceId} />
        </VerticalStack>
      </DialogContent>
      <DialogActions>
        <Button variant='outlined' onClick={onClose}>{localization.actions.cancel}</Button>
        <Button variant='outlined' color='primary' onClick={handleCreatePerson}>{localization.actions.confirm}</Button>
      </DialogActions>
    </Dialog>
  );
};