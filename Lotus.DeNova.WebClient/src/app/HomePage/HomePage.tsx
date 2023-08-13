import React from 'react';
import { Link } from 'react-router-dom';
import { accountNavigation } from 'src/shared/account/accountNavigation';
import { authNavigation } from 'src/shared/auth';

export const HomePage: React.FC = () => 
{
  return (
    <div>
        Модуль управления пользователями
      <div>
        <Link to={authNavigation.login.path} >Страница входа</Link>
      </div>
      <div>
        <Link to={accountNavigation.profile.path} >Страница профиля</Link>
      </div>
    </div>
  );
};