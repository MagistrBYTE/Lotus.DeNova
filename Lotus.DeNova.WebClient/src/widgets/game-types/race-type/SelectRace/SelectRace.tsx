import { MenuItem, Select } from '@mui/material';
import React, { useEffect } from 'react';
import { useState } from 'react';
import { useRaceTypeOptions } from 'src/modules/game-types/race-type';
import { ISelectOption, getSelectOptionText } from 'src/shared/types/SelectOption';

export interface ISelectRaceTypeProps 
{
  initialRaceTypeId?:number;
  onSetRaceTypeId: (raceId: number)=>void;
}

export const SelectRaceType: React.FC<ISelectRaceTypeProps> = (props: ISelectRaceTypeProps) => 
{
  const { initialRaceTypeId, onSetRaceTypeId } = props;
  const [selectedValue, setSelectedValue] = useState<number>(initialRaceTypeId ?? 1);
  const optionsRaceType = useRaceTypeOptions();

  const handleSelect = () => (option: ISelectOption) =>
  {
    setSelectedValue(option.value as number);
    onSetRaceTypeId(option.value as number);
  }

  return <Select 
    value={selectedValue} 
    renderValue={(selected)=>{ return getSelectOptionText(optionsRaceType, selected)}}>
    {optionsRaceType.map((option) => (
      <MenuItem key={option.value} value={option.value} onClick={handleSelect}>
        {(option.text)}
      </MenuItem>
    ))}
  </Select>
};
