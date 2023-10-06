import { Card, CardHeader } from '@mui/material';
import React from 'react';
import { IPerson } from 'src/modules/player-context/person';
import { IObjectInfo } from 'src/shared/objectInfo/ObjectInfo';
import { ImageBox } from 'src/ui/components/Display';
import { TPlacementDensity } from 'src/ui/types/PlacementDensity';

export interface IPersonCardProps
{
  /**
   * Данные персонажа
   */
  person:IPerson;

  /**
   * Описание свойств и связанные данные для персонажа
   */
  objectInfo: IObjectInfo;
  
  /**
   * Плотность отображения информации
   */
  density: TPlacementDensity
}

export const PersonCard: React.FC<IPersonCardProps> = (props:IPersonCardProps) => 
{
  const {person, objectInfo, density} = props;

  const raceName = objectInfo.getPropertyByName('raceId').options?.find(x => x.value === person.raceId)?.text;

  const margin = density === TPlacementDensity.Normal ? 1.5 : density === TPlacementDensity.Density ? 0.5 : 3;

  return (
    <Card sx={{ minWidth: 280, margin: margin }}>
      <CardHeader 
        avatar={
          <ImageBox id={person.avatarId}/>
        }
        title={person.name}
        subheader={raceName}
      />
    </Card>
  );
};