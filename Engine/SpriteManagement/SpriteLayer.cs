
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace Engine.SpriteManagement
{
    public class SpriteLayer
    {

        public string Name {get; private set;}


        GraphicsDevice _graphicsDevice;
        SpriteGraphicsState _graphicsState;

        SpriteBatch _spriteBatch;
        List<Sprite> _sprites;


        public SpriteSheet SpriteSheet { get; private set; }
        public Matrix Matrix { get; set; }

        public SpriteLayer(GraphicsDevice graphicsDevice, 
                           SpriteGraphicsState state, 
                           SpriteSheet spriteSheet,
                           string name)
        {
            Name = name;

            _graphicsDevice = graphicsDevice;
            _graphicsState = state;
            SpriteSheet = spriteSheet;

            _spriteBatch = new SpriteBatch(_graphicsDevice);
            _sprites = new List<Sprite>();

            Matrix = Matrix.Identity;

        }

        public void AddSprite(Sprite sprite)
        {
            _sprites.Add(sprite);
        }


        public void Draw()
        {

            _spriteBatch.Begin(blendState: _graphicsState.blendState,
                               samplerState: _graphicsState.samplerState,
                               depthStencilState: _graphicsState.depthStencilState,
                               effect: _graphicsState.effect,
                               transformMatrix: this.Matrix

                               ); 

            foreach (var sprite in _sprites)
            {
                if (sprite.DoRender)
                {
                    //sprite.Draw(_spriteBatch);

                    _spriteBatch.Draw(
                      SpriteSheet.Texture,
                      sprite.Owner.GetScreenPosition(),
                      sprite.RenderRectangle,
                      sprite.Color,
                      sprite.Owner.Rotation,
                      sprite.RenderOrigin,
                      sprite.Owner.Scale,
                      SpriteEffects.None,
                      1.0f
                  );
                }
            }
            _spriteBatch.End();
        }


    }
}
