import Phaser from 'phaser'

import HelloWorldScene from './scenes/HelloWorldScene'
import { TileMapScene } from './scenes/TileMapScene'

export const configPhaser: Phaser.Types.Core.GameConfig = 
{
  type: Phaser.AUTO,
  parent: 'canvasMap',
  backgroundColor: '#282c34',
  scene: [TileMapScene],
  pixelArt: true,
  roundPixels: true,        

  scale: 
  {
    // Except this should match the ID of your component host element.
    mode: Phaser.Scale.NONE,
  },  
}
