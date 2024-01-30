
using Microsoft.Xna.Framework;

using Engine.Modular;
using Engine.SpriteManagement;
using System.Diagnostics;

namespace Engine.TileEngine
{
    public class TileMapGenerator : IComponent
    {
        /**
         * TileMap is a component that adds tile entity children to the 
         *      entity it (TileMap) is attached to.
         *      
         * 
         */

        public override string Type => "TileMap";

        public int Width { get; private set; }
        public int Height { get; private set; }

        private List<Entity> _tiles;
        private const int TILE_SIZE = 128;

        private SpriteSystem _spriteSystem;
        private TileMapData _tmpData;

        public TileMapGenerator(string name, SpriteSystem spriteSystem, TileMapData data)
        {

            Name = name;
            _spriteSystem = spriteSystem;
            _tmpData = data;
            

        }


        public override void Initilize()
        {
            /* This indicates to me that "TileMapGenerator" isn't a component or entity
     * but rather should be a TileMapSystem
     *  vvvvvvvvvvvvvvvvvvvvvvvvvv     */
            Width = _tmpData.Width;
            Height = _tmpData.Height;

            _tiles = new List<Entity>();


            List<int> tilesIDs = _tmpData.getTiles();
            Debug.WriteLine("Length: " +  tilesIDs.Count);
            for (int i = 0; i < tilesIDs.Count; i++)
            {
                int tileType = tilesIDs[i];

                Entity tile = new Entity("IDC_FN");

                float posX = i % Width;
                float posY = i / Width;

                Debug.WriteLine("" + posX + ", " + posY);

                tile.Position = new Vector2(posX, posY);

                string textureBounds = "Default";
                switch (tileType)
                {
                    case 0:
                        textureBounds = "Water";
                        break;

                    case 1:
                        textureBounds = "Stone";
                        break;
                    case 2:
                        textureBounds = "Grass";
                        break;

                    case 3:
                        textureBounds = "Dirt";
                        break;
                }

                SpriteData spriteData = new SpriteData();
                spriteData.SpriteSheetName = "SpriteSheet1";
                spriteData.TextureOffsetName = textureBounds;
                spriteData.LayerName = "TileLayer";

                Sprite sprite = _spriteSystem.CreateSprite(spriteData);
                tile.AddComponent(sprite);

                Owner.AddChild(tile);

            }
        }

        public Entity getTileTypeAt(int x, int y)
        {
            return _tiles[y * Width + x];
        }

        public override void Process(float deltaTime)
        {

        }
    }
}
