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

  public createNewGame()
  {

  }
}

/**
 * Глобальный экземпляр сервиса для управления действиями игрока
 */
export const PlayerService = PlayerServiceClass.Instance;