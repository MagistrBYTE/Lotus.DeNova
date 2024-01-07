import { Game } from 'phaser';
import Phaser from 'phaser'
import React, { useEffect, useRef, useState } from 'react';
import { ISize } from 'src/shared/types/Size';

export function usePhaserGame(config: Phaser.Types.Core.GameConfig, 
  containerRef: React.RefObject<HTMLDivElement>, gameSize: ISize):Game|undefined
{
  const [game, setGame] = useState<Game>();

  useEffect(() => 
  {
    if (!game && containerRef.current) 
    {
      const newGame = new Game({ ...config, width:gameSize.width, height:gameSize.height, parent: containerRef.current })
      setGame(newGame);
    }
    return () => 
    {
      game?.destroy(true);
    }
  }, [config, containerRef, gameSize, game])

  return game;
}