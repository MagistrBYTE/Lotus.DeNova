import React from 'react';
import FiberNewIcon from '@mui/icons-material/FiberNew';
import PeopleIcon from '@mui/icons-material/People';
import DownloadIcon from '@mui/icons-material/Download';
import ArrowRightIcon from '@mui/icons-material/ArrowRight';
import MapIcon from '@mui/icons-material/Map';
import { CommandService, CommandServiceClass } from 'src/shared/command/CommandService';
import { BaseCommand, ICommand } from 'src/shared/command/Command';
import { localization } from 'src/resources/localization';
import { NavigationCommand } from 'src/shared/command/NavigationCommand';
import { routes } from 'src/app/routes';

class PlayerCommandsClass extends CommandServiceClass
{
  private static _PlayerCommands: PlayerCommandsClass;

  public static get Instance(): PlayerCommandsClass 
  {
    return (this._PlayerCommands || (this._PlayerCommands = new this()));
  }  

  // #region СВОЙСТВА
  /**
   * Продолжить игру
   */    
  continueGame: ICommand;

  /**
   * Новая игра
   */  
  newGame: ICommand;

  /**
   * Загрузить игру
   */
  loadGame: ICommand;

  /**
   * Персонажи
   */
  persons: ICommand;

  /**
   * Карта
   */
  map: ICommand;  
  // #endregion 

  constructor() 
  {
    super();
    
    this.continueGame = new BaseCommand('continueGame');
    this.continueGame.icon = <ArrowRightIcon/>;
    this.continueGame.label = localization.game.continueGame;
    this.continueGame.group = 'player';
    this.commands.push(this.continueGame);

    this.newGame = new BaseCommand('newGame');
    this.newGame.icon = <FiberNewIcon/>;
    this.newGame.label = localization.game.newGame;
    this.newGame.group = 'player'; 
    this.commands.push(this.newGame);
    
    this.loadGame = new BaseCommand('loadGame');
    this.loadGame.icon = <DownloadIcon/>;
    this.loadGame.label = localization.game.loadGame;
    this.loadGame.group = 'player';
    this.commands.push(this.loadGame);
    
    this.persons = new NavigationCommand('persons', routes.persons);
    this.persons.icon = <PeopleIcon/>;
    this.persons.label = localization.person.person;
    this.persons.group = 'player';
    this.commands.push(this.persons);

    this.map = new NavigationCommand('map', routes.gameMap);
    this.map.icon = <MapIcon/>;
    this.map.label = localization.map.map;
    this.map.group = 'player';
    this.commands.push(this.map);

    CommandService.addCommands(this.commands);
  }
}

/**
 * Глобальный доступ к командам связанным с контекстом игрока
 */
export const PlayerCommands = PlayerCommandsClass.Instance;