import { Typography } from '@mui/material';
import React from 'react';
import { PageContainer } from 'src/ui/components/Layout';

export const HomePage: React.FC = () => 
{
  return (
    <PageContainer>
      <Typography variant='h6'>
      Добро пожаловать в игровой мир Sentra
      </Typography>
      <Typography variant='body1'>
      До начала игры вы должны создать персонажей
      </Typography>
      <Typography variant='body1'>
      Вы можете создать новую игру или продолжить существующую
      </Typography>
      <Typography variant='body1'>
      Весь игровой процесс автоматически сохраняется после любого игрового действия
      </Typography>
    </PageContainer>
  );
};