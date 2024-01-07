import { Game } from 'phaser';
import React, { useEffect, useRef } from 'react';
import { setCommandsLeftPanelLayoutAction, useActualGraphicsSize } from 'src/app/layout';
import { useAppDispatch } from 'src/app/store';
import { PlayerService } from 'src/modules/player-context';
import { usePhaserGame } from 'src/phaser/hooks/usePhaserGame';
import { configPhaser } from 'src/phaser/PhaserGame';
import { PhaserGameComponent } from 'src/phaser/PhaserGameComponent';
import { IRectOffset } from 'src/shared/types/RectOffset';


export const GameMapPage: React.FC = () => 
{
  const marginMap:IRectOffset = {left: 1, top: 1, right: 1, bottom: 1};

  const dispatch = useAppDispatch();

  const GameInitHandle = (game: Game) =>
  {

  }

  useEffect(()=>
  {
    const commandsName = PlayerService.getCommandsName();
    dispatch(setCommandsLeftPanelLayoutAction(commandsName));
  }, []);

  console.log('render');

  return (<PhaserGameComponent config={configPhaser} margin={marginMap} onGameInit={GameInitHandle} />);
};
