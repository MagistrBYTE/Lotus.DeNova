import PeopleIcon from '@mui/icons-material/People';
import WorkspacePremiumIcon from '@mui/icons-material/WorkspacePremium';
import PermDeviceInformationIcon from '@mui/icons-material/PermDeviceInformation';
import GroupIcon from '@mui/icons-material/Group';
import MapIcon from '@mui/icons-material/Map';
import { localization } from 'src/shared/localization';
import React from 'react';
import { INavigationPath } from 'src/shared/navigation';

export const mainNavigations: 
{
  home: INavigationPath,
  dummy: INavigationPath,

  persons: INavigationPath,
  map: INavigationPath,
  forge: INavigationPath,
} = 
{
  /**
   * Домашняя страница
   */
  home: 
  {
    label: '',
    path: '/',
    group: 'home' 
  } as const,   

  /**
   * Пустышка
   */
  dummy: 
  {
    label: 'Пустышка',
    path: '/dummy',
    group: 'dummy' 
  } as const,   

  /**
   * Персонажи
   */
  persons:
  {
    icon: <PeopleIcon/>,
    label: localization.person.person,
    isShouldBeAuthorized: true,
    path: '/persons',
    group: 'main'    
  } as const,

  /**
   * Карта
   */
  map:
  {
    icon: <MapIcon/>,
    label: localization.map.map,
    isShouldBeAuthorized: true,
    path: '/map',  
    group: 'main' 
  } as const,

  /**
   * Кузница
   */  
  forge:
  {
    icon: <PermDeviceInformationIcon/>,
    label: localization.permission.permissions,
    isShouldBeAuthorized: true,
    path: '/forge',  
    group: 'main'  
  } as const
}; 