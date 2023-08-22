import * as React from 'react';
import { Route, Routes  } from 'react-router-dom';
import { LoginPage, AutoLoginPage, RegisterPage, RestorePasswordPage, authNavigation } from 'src/shared/auth';
import { useScreenTypeChanged } from 'src/shared/layout';
import { MapPage } from 'src/modules/map';
import { ConfigurationPage, NotificationsPage, ProfilePage } from 'src/shared/account';
import { accountNavigation } from 'src/shared/account/accountNavigation';
import { MainLayoutPermission } from 'src/shared/layout/ui/MainLayoutPermission';
import { MainLayout } from 'src/shared/layout/ui';
import { HomePage } from './HomePage';
import { mainNavigations } from './mainNavigations';

export const App: React.FC = () => 
{
  useScreenTypeChanged();

  return (
    <React.Suspense fallback={<div>Loading...</div>}>
      <Routes>
        <Route 
          path={mainNavigations.home.path} 
          element={<MainLayout page={<HomePage/>}/>}/>

        {/* Авторизация и регистрация */}
        <Route
          path={authNavigation.login.path}
          element={<LoginPage pathSuccess={accountNavigation.profile.path} />}/>
        <Route
          path={authNavigation.autoLogin.path}
          element={<AutoLoginPage pathSuccess={accountNavigation.profile.path} />}/> 
        <Route
          path={authNavigation.registr.path}
          element={<RegisterPage pathSuccess={authNavigation.login.path} />}/>
        <Route
          path={authNavigation.restorePassword.path}
          element={<RestorePasswordPage pathSuccess={authNavigation.login.path} />}/>                 

        {/* Личные страницы */}
        <Route 
          path={accountNavigation.profile.path} 
          element={<MainLayoutPermission {...accountNavigation.profile}  page={<ProfilePage />} />}/>
        <Route 
          path={accountNavigation.notification.path} 
          element={<MainLayoutPermission {...accountNavigation.notification} page={<NotificationsPage/>}/>}/>
        <Route 
          path={accountNavigation.configuration.path} 
          element={<MainLayoutPermission {...accountNavigation.configuration} page={<ConfigurationPage/>}/>}/>


        {/* Карта */} 
        <Route
          path={mainNavigations.map.path}
          element={<MainLayout {...mainNavigations.map} page={<MapPage/>}/>}/>
      </Routes>
    </React.Suspense>
  );
};

