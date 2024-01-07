import Phaser from 'phaser'

export default class HelloWorldScene extends Phaser.Scene 
{
  frame:Phaser.GameObjects.Rectangle|undefined = undefined;

  constructor() 
  {
    super('helloworld')
  }

  preload() 
  {

  }

  create() 
  {
    const rect = this.game.canvas.getBoundingClientRect();
    this.frame = this.add.rectangle((rect.width)/2, (rect.height)/2, rect.width - 8, rect.height - 8, 0xff33cc);

    this.frame.setStrokeStyle(2, 0x6666ff);


    // const line = new Phaser.Geom.Line(1, 1, rect.width-2, 1);
    // const line1 = new Phaser.Geom.Line(rect.width - 2, 1, rect.width - 2, rect.height - 2);
    // const line2 = new Phaser.Geom.Line(rect.width - 2, rect.height - 2, 1, rect.height - 2);
    // const line3 = new Phaser.Geom.Line(1, rect.height - 2, 1, 1);

    // const graphics = this.add.graphics({ lineStyle: { width: 4, color: 0xaa00aa } });

    // graphics.strokeLineShape(line);
    // graphics.strokeLineShape(line1);
    // graphics.strokeLineShape(line2);
    // graphics.strokeLineShape(line3);

    // const r1 = this.add.circle(200, 200, 80, 0x6666ff);

    // const r2 = this.add.circle(400, 200, 80, 0x9966ff);

    // r2.setStrokeStyle(4, 0xefc53f);

    // const r3 = this.add.circle(600, 200, 80);

    // r3.setStrokeStyle(2, 0x1a65ac);

    // const r4 = this.add.circle(200, 400, 80, 0xff6699);

    // const r5 = this.add.circle(400, 400, 80, 0xff33cc);

    // const r6 = this.add.circle(600, 400, 80, 0xff66ff);

    // //  WebGL only
    // r6.setIterations(0.2);

    // this.tweens.add({
    //   targets: r4,
    //   scaleX: 0.25,
    //   scaleY: 0.5,
    //   yoyo: true,
    //   repeat: -1,
    //   ease: 'Sine.easeInOut'
    // });

    // this.tweens.add({
    //   targets: r5,
    //   alpha: 0.2,
    //   yoyo: true,
    //   repeat: -1,
    //   ease: 'Sine.easeInOut'
    // });

    // this.tweens.add({
    //   targets: r6,
    //   angle: 90,
    //   yoyo: true,
    //   repeat: -1,
    //   ease: 'Sine.easeInOut'
    // });    
  }

  update(time: number, delta: number): void 
  {
    // this.cameras.default.centerOn(500, 500);

    // const rect = this.game.canvas.getBoundingClientRect();
    // this.frame!.x = 73;
    // this.frame!.y = 1;
    // this.frame!.width = 100;
    // this.frame!.height = 100;
    // console.log(rect);
  }
}
