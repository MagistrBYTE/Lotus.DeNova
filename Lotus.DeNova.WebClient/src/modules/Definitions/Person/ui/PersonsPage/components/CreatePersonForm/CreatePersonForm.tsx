import { AppBar, Box, Button, Dialog, DialogActions, DialogContent, DialogTitle, IconButton, Paper, PaperProps, Stack, TextField, Toolbar } from '@mui/material';
import React, { ChangeEvent, useState } from 'react';
import { IPerson } from 'src/modules/Definitions/Person/domain/Person';
import { localization } from 'src/shared/localization';
import CloseIcon from '@mui/icons-material/Close';
import { PersonApi } from 'src/modules/Definitions/Person/api/PersonApiService';
import { SelectRace, useRaceOptions } from 'src/modules/Definitions/Race';
import { OneSelect } from 'src/ui/components/Editor/OneSelect';
import { InputText } from 'src/ui/components/Editor';
import { ISelectOption } from 'src/core/types/SelectOption';

export interface ICreatePersonFormProps
{
  open: boolean;
  onClose: ()=>void;
  onCreate: ()=>void;
  onCreatePerson: (createdItem: IPerson|null)=>void
}

export const CreatePersonForm: React.FC<ICreatePersonFormProps> = ({open, onClose, onCreate, onCreatePerson}:ICreatePersonFormProps) => 
{
  const personEmpty:IPerson = {id:-1, name: 'Новый персонаж', raceId: 1}

  const [person, setPerson] = useState<IPerson|null>(null);

  const [personName, setPersonName] = useState<string>('');
  const [personRaceId, setPersonRaceId] = useState(1);
  const [personAvatarId, setPersonAvatarId] = useState(1);
  const optionsRace = useRaceOptions();

  const optionsAvatars:ISelectOption[] = 
  [
    {
      text: 'halk',
      value: 1,
      icon: '/images/Avatar/Fatcow_user_halk_32.png'
    },
    {
      text: 'ironman',
      value: 2,
      icon: '/images/Avatar/Fatcow_user_ironman_32.png'
    },
    {
      text: 'leprechaun',
      value: 3,
      icon: '/images/Avatar/Fatcow_user_leprechaun_32.png'
    } 
  ]

  const handleCreatePerson = async () =>
  {
    const result = await PersonApi.createPersonAsync({name: personName, raceId: personRaceId});
    if(result.payload)
    {
      onCreatePerson(result.payload);
      onCreate();
    }
    else
    {
      onClose();
    }
  }

  const handleNamePerson = (event: ChangeEvent<HTMLTextAreaElement | HTMLInputElement>) =>
  {
    setPersonName(event.target.value);
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
          Создание персонажа
        </Toolbar>
      </AppBar>            
      <DialogContent>
        <Stack display={'flex'} flexDirection={'column'} gap={1} justifyContent={'flex-start'}>
          <Box>
            
          </Box>

          <OneSelect<number> 
            size='small'
            fullWidth
            label='Аватар персонажа'
            labelProps={{p:1, width: '230px'}}
            options={optionsAvatars} onSetSelectedValue={setPersonAvatarId} />

          <InputText
            fullWidth
            size='small'
            label='Имя персонажа'
            labelProps={{p:1, width: '230px'}}
            variant='outlined'
            value={personName}
            id="outlined-error"
          />
          <OneSelect<number> 
            size='small'
            fullWidth
            label='Раса персонажа'
            labelProps={{p:1, width: '230px'}}
            options={optionsRace} onSetSelectedValue={setPersonRaceId} />
        </Stack>
      </DialogContent>
      <DialogActions>
        <Button variant='outlined' onClick={onClose}>{localization.actions.cancel}</Button>
        <Button variant='outlined' color='primary' onClick={handleCreatePerson}>{localization.actions.confirm}</Button>
      </DialogActions>
    </Dialog>
  );
};