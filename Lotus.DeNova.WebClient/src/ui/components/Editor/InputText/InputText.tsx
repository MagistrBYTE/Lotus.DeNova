import React, { ChangeEvent, useState } from 'react';
import { BaseTextFieldProps, TextField } from '@mui/material';
import { ILabelProps, Label } from '../../Info/Label';

export interface IInputTextProps extends BaseTextFieldProps, ILabelProps
{
  /**
   * Функция обратного вызова для установки введеного значения
   * @param value Выбранное значение
   * @returns 
   */
  onSetValue?: (value: string)=>void;

  /**
   * Изначально значение
   */  
  initialValue?: string;
}  

export const InputText: React.FC<IInputTextProps> = ({onSetValue, initialValue, textInfo, textInfoKey, labelProps, ...props}: IInputTextProps) =>
{
  const [value, setValue] = useState<string>(initialValue ?? '');

  const handleChange = (event: ChangeEvent<HTMLTextAreaElement | HTMLInputElement>) =>
  {
    setValue(event.target.value);
    if(onSetValue)
    {
      onSetValue(event.target.value);
    }
  }
 
  return (
    <Label
      label={props.label}
      labelProps={labelProps}
      fullWidth={props.fullWidth} 
      textInfo={textInfo} 
      textInfoKey={textInfoKey} >
      <TextField {...props} onChange={handleChange} label={undefined} value={value} />
    </Label>);  
};
