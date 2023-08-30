import { Card, CardHeader } from '@mui/material';
import React from 'react';
import { IPerson } from 'src/modules/UserSlice/Person/domain/Person';

export const PersonCard: React.FC<IPerson> = ({id, name}:IPerson) => 
{
  return (
    <Card sx={{ minWidth: 280, margin: 2 }}>
      <CardHeader title={name} />
    </Card>
  );
};