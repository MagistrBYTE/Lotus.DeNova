import { MenuItem, Select } from '@mui/material';
import React, { useEffect } from 'react';
import { useState } from 'react';
import { ISelectOption, getSelectOptionText } from 'src/core/types/SelectOption';
import { RaceApi } from '../../../api/RaceApiService';
import { useRaceOptions } from '../../../hooks/useRaceOptions';

export interface ISelectRaceProps 
{
  initialRaceId?:number;
  onSetRaceId: (raceId: number)=>void;
}

export const SelectRace: React.FC<ISelectRaceProps> = (props: ISelectRaceProps) => 
{
  const { initialRaceId, onSetRaceId } = props;
  const [selectedValue, setSelectedValue] = useState<number>(initialRaceId ?? 1);
  const optionsRace = useRaceOptions();

  const handleSelect = () => (option: ISelectOption) =>
  {
    setSelectedValue(option.value as number);
    onSetRaceId(option.value as number);
  }

  return <Select 
    value={selectedValue} 
    renderValue={(selected)=>{ return getSelectOptionText(optionsRace, selected)}}>
    {optionsRace.map((option) => (
      <MenuItem key={option.value} value={option.value} onClick={handleSelect}>
        {(option.text)}
      </MenuItem>
    ))}
  </Select>
};
