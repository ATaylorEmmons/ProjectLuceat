using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace Engine.SpriteManagement
{
    public class SpriteSheet
    {
        public Texture2D Texture { get; private set; }

        private Dictionary<string, Rectangle> _spriteBounds;

        public SpriteSheet(ContentManager Content, SpriteSheetData data)
        {
            Texture = Content.Load<Texture2D>(data.TextureName);

            _spriteBounds = data.GetSpriteBounds();

        }

        public Rectangle GetBounds(string name)
        {
            return _spriteBounds[name];
        }
    }
}
