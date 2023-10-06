import { Link, Typography } from '@mui/material';
import React, { useEffect } from 'react';
import { setCommandsLeftPanelLayoutAction } from 'src/app/layout';
import { routes } from 'src/app/routes';
import { useAppDispatch } from 'src/app/store';
import { AdminCommands } from 'src/modules/admin';
import { TokenHelper } from 'src/modules/auth';
import { BaseCommands } from 'src/modules/base';
import { PlayerCommands } from 'src/modules/player-context';
import { DelimiterCommandDefault } from 'src/shared/command/DelimiterCommand';
import { PageContainer } from 'src/ui/components/Layout';

export const HomePage: React.FC = () => 
{
  const isAuth = TokenHelper.isAccessToken();
  const dispatch = useAppDispatch();

  useEffect(()=>
  {
    if(isAuth)
    {
      if(dispatch)
      {
        const commandsName: string[] = [];
        commandsName.push(PlayerCommands.newGame.name, 
          PlayerCommands.loadGame.name, 
          PlayerCommands.persons.name, 
          DelimiterCommandDefault.name,
          BaseCommands.home.name, 
          BaseCommands.about.name);
        console.log(commandsName);
        dispatch(setCommandsLeftPanelLayoutAction(commandsName));
      }      
    }
    else
    {
      if(dispatch)
      {
        dispatch(setCommandsLeftPanelLayoutAction([BaseCommands.home.name, BaseCommands.about.name]));
      }
    }
  }, [])

  return (
    <PageContainer>
      <Typography variant='h6'>
      Добро пожаловать в игровой мир Sentra
      </Typography>      
      {isAuth &&
      <>
        <Typography variant='body1'>
          До начала игры вы должны создать персонажей
        </Typography>
        <Typography variant='body1'>
          Вы можете создать новую игру или продолжить существующую
        </Typography>
        <Typography variant='body1'>
          Весь игровой процесс автоматически сохраняется после любого игрового действия
        </Typography>
      </>}
      {!isAuth &&
      <>
        <Typography variant='body1'>
          Для игры вы должны <Link href={routes.login.path}>войти</Link> или <Link href={routes.register.path}>зарегистрироваться</Link>
        </Typography>
      </>}
    </PageContainer>
  );
};