using Engine.SpriteManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Engine.SpriteManagement
{
    public class SpriteSystem
    {

        /* TODO:
         *  Make more explicit the order that a layer is rendered
         * 
         */

        private List<SpriteLayer> _spriteLayers;
        private List<Sprite> _sprites;

        private GraphicsDevice _graphicsDevice;

        public SpriteSystem(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;

            _spriteLayers = new List<SpriteLayer>();
            _sprites = new List<Sprite>();


        }

        public SpriteLayer CreateLayer(SpriteGraphicsState state, 
                                       SpriteSheet spriteSheet,
                                       string name)
        {

            SpriteLayer layer = new SpriteLayer(this._graphicsDevice, state, spriteSheet, name);
            _spriteLayers.Add(layer);

            return layer;

        }

        public Sprite CreateSprite(SpriteData spriteData)
        {

            SpriteLayer layer = getLayerByName(spriteData.LayerName);

            Sprite sprite = new Sprite(spriteData, layer.SpriteSheet);
            _sprites.Add(sprite);
            layer.AddSprite(sprite);

            return sprite;

        }

        private SpriteLayer getLayerByName(string name)
        {
            foreach(var spriteLayer in _spriteLayers)
            {
                if( spriteLayer.Name == name ) return spriteLayer;
            }

            throw new Exception("Layer not found: " + name);
        }


        public void Update(Rectangle bounds)
        {

            /*
             * TODO: Use the cullBounds and a 
             *  Quadtree to query which sprites get drawn.
             */

            //List<Sprite> renderList = quadtree.cull(bounds)


            List<Sprite> renderList = _sprites;

            foreach(var sprite in renderList)
            {
                sprite.DoRender = true;
            }
        }

        public void Draw()
        {

            foreach(var layer in _spriteLayers)
            {
                layer.Draw();
            }
        }

    }

}
