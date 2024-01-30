using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Engine.Modular;
using Engine.ParticleSystem;
using Microsoft.Xna.Framework.Content;
using Engine.SpriteManagement;
using Engine;
using System;
using Engine.TileEngine;
using GameComponents;

namespace ProjectLuceat.Scenes
{

    class MainScene : Scene
    {
        SpriteLayer tileLayer;
        SpriteLayer objectLayer;
        SpriteSheet mainSprites;

        Entity player;

        Entity bottomTileMap;

        float elapsedTime = 0.0f;

        public MainScene(Window window, SpriteSystem spriteSystem) : base(window, spriteSystem){}
        public MainScene(Window window, SpriteSystem spriteSystem,
                        ParticleManager particleManager) 
                            : base(window, spriteSystem, particleManager) { }

        public override void Initilize(ContentManager Content)
        {


            mainSprites = new SpriteSheet(Content,
                                          Content.Load<SpriteSheetData>("xml/MainObjects"));


            tileLayer = _spriteSystem.CreateLayer(SpriteGraphicsState.PixelArt(), mainSprites, "TileLayer");
            objectLayer = _spriteSystem.CreateLayer(SpriteGraphicsState.PixelArt(), mainSprites, "ObjectLayer");


            player = new Entity(
                        "Player",
                        new Vector2(0.0f, 0.0f),
                        new Vector2(1.0f)
                        );


            SpriteData spriteData = new SpriteData();
            spriteData.SpriteSheetName = "SpriteSheet1";
            spriteData.TextureOffsetName = "BlueShip";
            spriteData.LayerName = "ObjectLayer";

            Sprite playerSprite = _spriteSystem.CreateSprite(spriteData);

            ShipController shpController = new ShipController("shipcontroller");
            player.AddComponent(shpController);
            player.AddComponent(playerSprite);

            Root.AddChild(player);


            bottomTileMap = new Entity(
                        "BottomTileMap",
                        new Vector2(0.0f, 0.0f),
                        new Vector2(1.0f)
                        );

            TileMapGenerator tmp = new TileMapGenerator(
                                            "tmp1",
                                            _spriteSystem,
                                            Content.Load<TileMapData>("xml/KingdomMap")
                                            );


            bottomTileMap.AddComponent(tmp);


            Root.AddChild(bottomTileMap);


            Root.Initilize();

            Camera.Scale = new Vector2(.5f);
        }


        public override void Update(float dt)
        {

            elapsedTime += dt;

            tileLayer.Matrix = Camera.GetMatrix();
            objectLayer.Matrix = Camera.GetMatrix();
            base.Update(dt);
        }

        public override void Draw(float dt)
        {


            base.Draw(dt);
        }

    }
}
