import { DelimiterCommandDefault } from 'src/shared/command/DelimiterCommand';
import { TokenHelper } from '../auth';
import { BaseCommands } from '../base';
import { PlayerCommands } from './PlayerCommands';

class PlayerServiceClass 
{
  private static _PlayerService: PlayerServiceClass;

  public static get Instance(): PlayerServiceClass 
  {
    return (this._PlayerService || (this._PlayerService = new this()));
  }

  constructor()
  {
    this.createNewGame = this.createNewGame.bind(this);
  }

  public getCommandsName():string[]
  {
    const isAuth = true; // TokenHelper.isAccessToken();
    
    const commandsName: string[] = [];

    if(isAuth)
    {
      commandsName.push(PlayerCommands.newGame.name, 
        PlayerCommands.loadGame.name, 
        PlayerCommands.persons.name, 
        PlayerCommands.map.name, 
        DelimiterCommandDefault.name,
        BaseCommands.home.name, 
        BaseCommands.about.name);
    }
    else
    {
      commandsName.push(BaseCommands.home.name, 
        BaseCommands.about.name);      
    }

    return commandsName;
  }

  public createNewGame()
  {

  }
}

/**
 * Глобальный экземпляр сервиса для управления действиями игрока
 */
export const PlayerService = PlayerServiceClass.Instance;