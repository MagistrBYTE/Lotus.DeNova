import Phaser from 'phaser'
import MineralMarble_03 from 'src/assets/MineralMarble_03.png'

export class HappyFaceScene extends Phaser.Scene 
{
  preload() 
  {
    // A convention of mine to avoid `this` confusion with sub classes is to 
    // give it a better reference name at the top of every function.
    const scene = this;
    scene.load.image('happyFace', MineralMarble_03)
  }

  create() 
  {
    const scene = this;

    // Add your game objects and all that other stuff. It's just a simple image.
    scene.add.image(0, 0, 'happyFace').setOrigin(0, 0).setDisplaySize(480, 142)

    // Finally trigger an event so that the scene is now visible. This is optional 
    // but useful if you want to transition your game's appearance.
    scene.game.events.emit('putOnAHappyFace', true)
  }

  update(time: number, delta: number) 
  {
    const scene = this
    // const { lives, progress } = scene;

    // For example, monitor the number of lives and exit when 
    if (1) 
    {
      // Save the progress.
      // this.game.registry.merge(progress)
      // Trigger the game end.
      // scene.game.events.emit('putOnAHappyFace', false)
    }
  }
}