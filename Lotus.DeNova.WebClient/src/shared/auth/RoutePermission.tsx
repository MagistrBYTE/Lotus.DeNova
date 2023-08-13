import React from 'react';
import { Navigate, useLocation } from 'react-router-dom';
import { ProfilePage } from '../account';
import { MainLayout } from '../layout/ui';
import { AuthApi } from './api/AuthApiService';
import { TokenHelper } from './utils/TokenHelper';
import { authNavigation } from './authNavigation';

interface IRoutePermissionProps 
{
  children: React.ReactElement;
  permissions?: string[];
  isShouldBeAuthorized?: boolean;
};

export const RoutePermission = ({ children, permissions = undefined,
  isShouldBeAuthorized = true }: IRoutePermissionProps): React.ReactElement | null => 
{
  const isAuth = TokenHelper.isAccessToken();
  const isAuthCookie = AuthApi.IsAuthCookie();
  const location = useLocation();
  const state = location.state as { from: Location };
  const prevPageUrl = state ? state.from.pathname : '/';

  // Пользователь должен быть авторизован
  if(isShouldBeAuthorized)
  {
    // Если он авторизован
    if(isAuth)
    {
      // Если нужен доступ
      if(permissions)
      {
        // Проверяем права
        if (TokenHelper.checkUserPermissions(permissions)) 
        {
          // Права нужне есть
          return children;
        }
        else
        {
          // Доступа нет, возвращаем страницу профиля
          return <MainLayout page={<ProfilePage/>}/>
        }
      }
      else
      {
        // Доступ к ресурсу не нужен
        return children;
      }
    }
    else
    {
      if(isAuthCookie)
      {
        // Пользователь не авторизован - Но есть куки
        return <Navigate to={authNavigation.autoLogin.path} state={{ from: location }} />
      }
      else
      {
        // Пользователь не авторизован - возвращаем страницу авторизации
        return <Navigate to={authNavigation.login.path} state={{ from: location }} />
      }
    }
  }
  else
  {
    // Он авторизован, но не должен быть
    if(isAuth)
    {
      // Переходим на предыдущую страницу
      return <Navigate to={prevPageUrl} state={{ from: location }} />
    }
    else
    {
      return children;
    }
  }
}
