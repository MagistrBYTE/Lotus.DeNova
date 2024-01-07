export class TileMapScene extends Phaser.Scene
{
  map:Phaser.Tilemaps.Tilemap|undefined = undefined;
  mapDesert:Phaser.Tilemaps.Tilemap|undefined = undefined;
  mapJeremi:Phaser.Tilemaps.Tilemap|undefined = undefined;
  textPointer: Phaser.GameObjects.Text|undefined = undefined;
  layerBackground: Phaser.Tilemaps.TilemapLayer | null = null;
  selectedTile:Phaser.Tilemaps.Tile|null = null; 
  mapSentra:Phaser.Tilemaps.Tilemap|undefined = undefined;
  
  isDrag:boolean = false;
  posX:number = 0;
  posY:number = 0;
  startPosX:number = 0;
  startPosY:number = 0;
  startCenterX:number = 0;
  startCenterY:number = 0;
  deltaX:number = 0;
  deltaY:number = 0;
  centerX:number = 0;
  centerY:number = 0;
  oldPositionX:number = 0;
  oldPositionY:number = 0;
  controls:Phaser.Cameras.Controls.SmoothedKeyControl|null = null;
  preload ()
  {
    this.load.image('structures', 'images/Frontier/grassland_structures.png');
    this.load.image('trees', 'images/Frontier/grassland_trees.png');
    this.load.image('water', 'images/Frontier/grassland_water.png');
    this.load.image('grassland', 'images/Frontier/grassland.png');
    this.load.image('collision', 'images/Frontier/tiled_collision.png');
    this.load.image('tiled_grassland_2x2', 'images/Frontier/tiled_grassland_2x2.png');

    this.load.tilemapTiledJSON('map', 'images/Frontier/frontier_plains.json');

    this.load.image('tiles', 'images/Tiles/tmw_desert_spacing.png');
    this.load.tilemapTiledJSON('mapDesert', 'images/Tiles/tmw_desert_spacing.json');

    this.load.image('JeremiTiles', 'images/Jeremi/tilesheet_iso.png');
    this.load.tilemapTiledJSON('JeremiGround', 'images/Jeremi/iso80x80.json');    

    this.load.image('Sentra_HMM3', 'images/Sentra/HMM3_Tile.png');
    this.load.tilemapTiledJSON('Sentra', 'images/Sentra/Sentra.json');      
  }

  create ()
  {
    this.map = this.make.tilemap({ key: 'map' });
    this.map.orientation = 'isometric';
    // this.mapDesert = this.make.tilemap({ key: 'mapDesert' });

    // The first parameter is the name of the tileset in Tiled and the second parameter is the key
    // of the tileset image used when loading the file in preload.
    // const tiles = this.mapDesert.addTilesetImage('Desert', 'tiles');

    // You can load a layer from the map using the layer name from Tiled ('Ground' in this case), or
    // by using the layer index. Since we are going to be manipulating the map, this needs to be a
    // dynamic tilemap layer, not a static one.
    // const layer = this.mapDesert.createLayer('Ground', tiles!, 0, 0);   

    // console.log(this.game.textures);
    // console.log(this.mapDesert);

    // const tilesStructures = this.map.addTilesetImage('structures', 'structures');
    // const tilesTrees = this.map.addTilesetImage('trees', 'trees');
    // const tilesWater = this.map.addTilesetImage('water', 'water');
    // const tilesGrassland = this.map.addTilesetImage('grassland', 'grassland');
    // const tilesCollision = this.map.addTilesetImage('collision', 'collision');
    // const tilesTiled2 = this.map.addTilesetImage('tiled_grassland_2x2', 'tiled_grassland_2x2');

    // const tiles = [tilesStructures!, tilesTrees!, tilesWater!, tilesGrassland!, tilesCollision!, tilesTiled2!]

    // this.layerBackground = this.map.createLayer('background', tiles);
    // const layerObject = this.map.createLayer('object', tiles);
    // const layerCollision = this.map.createLayer('collision', tiles, 0, -2);
    // this.layerBackground?.setCullPadding(8, 8);
    // layerObject!.setCullPadding(8, 8);

    this.mapSentra= this.make.tilemap({ key: 'Sentra' });
    const tiles = this.mapSentra.addTilesetImage('main', 'Sentra_HMM3');
    const layer = this.mapSentra.createLayer('Ground', tiles!, 0, 0);   

    // this.mapJeremi = this.make.tilemap({ key: 'JeremiGround' });

    // const tilesJeremi = this.mapJeremi.addTilesetImage('tilesheet_iso', 'JeremiTiles');
    // this.mapJeremi.createLayer('Ground', tilesJeremi!);

    // console.log(this.mapJeremi);

    // const tiles = [tilesStructures!, tilesTrees!, tilesWater!, tilesGrassland!, tilesCollision!, tilesTiled2!];
    
    // const layerBackground = this.map.createLayer('background', tiles);

    // this.cameras.main.setBounds(-this.map.widthInPixels/2, -this.map.heightInPixels, this.map.widthInPixels, this.map.heightInPixels*2);
    // this.centerX = this.cameras.main.centerX;
    // this.centerY = this.cameras.main.centerY;

    this.textPointer = this.add.text(10, 10, 'Move the mouse', { font: '16px Courier', color: 'black'});

    this.textPointer.setScrollFactor(0)

    this.input.on('pointerdown', (pointer: Phaser.Input.Pointer) =>
    {
      // if (pointer.leftButtonDown())
      // {
      //   console.log('Left button down');
      //   this.isDrag = true;
      //   this.startPosX = pointer.x;
      // }
      this.startCenterX = this.centerX;
      this.startCenterY = this.centerY;
      this.isDrag = true;

      this.startPosX = pointer.x;  
      this.startPosY = pointer.y;    


      const worldPoint = pointer.positionToCamera(this.cameras.main) as Phaser.Math.Vector2;

      console.log(worldPoint);

      const searchedWorldX = worldPoint.x; // this.mapJeremi?.tileWidth! / 2;
      const searchedWorldY = worldPoint.y; // -  this.mapJeremi?.tileWidth! / 2; // note tileWidth and not height

      const pointResult: Phaser.Math.Vector2 = new Phaser.Math.Vector2(0, 0);
      this.selectedTile = this.mapSentra!.getTileAtWorldXY(worldPoint.x, worldPoint.y);

      // this.selectedTile = this.map!.getTileAt(res.x, res.y);

      // console.log(this.selectedTile);
      // console.log(pointResult);
      // console.log(res);

      if(this.selectedTile != null)
      {
        // this.mapJeremi!.swapByIndex(this.selectedTile!.index, 1);
        this.selectedTile.index = 0;
      }
    }, this);

    this.input.on('pointerup', (pointer: Phaser.Input.Pointer) =>
    {
      // if (pointer.leftButtonReleased())
      // {
      //   console.log('Left button released');
      //   this.posX = this.posX - this.deltaX;
      //   if(this.posX < 0)
      //   {
      //     this.posX = 0;
      //   }
      //   this.deltaX = 0;
      //   this.isDrag = false;
      // }

      this.isDrag = false;
      this.centerX = this.startCenterX - this.deltaX;
      this.centerY = this.startCenterY - this.deltaY;
      // this.centerY = this.centerY + this.deltaY;
      // if(this.posX < 0)
      // {
      //   this.posX = 0;
      // }
      this.deltaX = 0;
      this.deltaY = 0;

      this.checkOffset();
    });  

    const cursors = this.input!.keyboard!.createCursorKeys();

    const controlConfig = {
      camera: this.cameras.main,
      left: cursors.left,
      right: cursors.right,
      up: cursors.up,
      down: cursors.down,
      acceleration: 0.04,
      drag: 0.0005,
      maxSpeed: 0.7
    };

    this.controls = new Phaser.Cameras.Controls.SmoothedKeyControl(controlConfig);    
  }

  update (time:number, delta:number)
  {
    this.controls!.update(delta);

    const pointer = this.input.activePointer;

    if(this.selectedTile != null)
    {
    this.textPointer!.setText([
      `this.selectedTile.index: ${this.selectedTile.index}`,
      `this.layerBackground?.active: ${this.layerBackground?.active}`,
      `this.layerBackground?.visible: ${this.layerBackground?.visible}`,
      `map?.heightInPixels: ${this.map?.heightInPixels}`,         
      `this.centerX: ${this.centerX}`,
      `this.deltaX: ${this.deltaX}`,      
      `this.centerY: ${this.centerY}`,
      `this.deltaY: ${this.deltaY}`,             
      `x: ${pointer.x}`,
      `y: ${pointer.y}`
    ]);
    }

    if(this.isDrag)
    {
      this.deltaX = pointer.x - this.startPosX;
      this.centerX = this.startCenterX - this.deltaX;

      this.deltaY = pointer.y - this.startPosY;
      this.centerY = this.startCenterY - this.deltaY;

      this.checkOffset();    

      // if(currentPos < 0)
      // {
      //   currentPos = 0;
      // }
      // this.cameras.main.setBounds(currentPos, this.posY, this.map!.widthInPixels, this.map!.heightInPixels);  
      // this.centerX += pointer.x - this.oldPositionX;
      // this.centerY += pointer.y - this.oldPositionY;

      // this.cameras.main.centerOn(this.centerX, this.centerY)
    }
    else
    {
      // this.cameras.main.setBounds(this.posX, this.posY, this.map!.widthInPixels, this.map!.heightInPixels); 
    }

    // this.oldPositionX = pointer.position.x;
    // this.oldPositionY = pointer.position.y;
  }

  private checkOffset()
  {
    // if(this.centerX < this.game.canvas.width / 2)
    // {
    //   this.centerX = this.game.canvas.width / 2;
    // } 
    
    // if(this.centerY < this.game.canvas.height / 2)
    // {
    //   this.centerY = this.game.canvas.height / 2;
    // }
    
    const deltaX = this.map!.widthInPixels - this.game.canvas.width;
    const maxOffsetX = this.game.canvas.width / 2 + deltaX;
    // if(this.centerX > maxOffsetX)
    // {
    //   this.centerX = maxOffsetX;
    // }

    const deltaY = this.map!.heightInPixels - this.game.canvas.height;
    const maxOffsetY = this.game.canvas.height / 2 + deltaY;
    // if(this.centerY > maxOffsetY)
    // {
    //   this.centerY = maxOffsetY;
    // }    
  }
}