using Engine.Modular;
using Engine.SpriteManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Engine.SpriteManagement
{
    public class Sprite : IComponent
    {


        public String TextureOffsetName = "Default";
        public Rectangle RenderRectangle { get; set; }

        public Color Color { get; set; }
        public Vector2 RenderOrigin { get; set; }
        public override string Type => "Sprite";

        public bool DoRender { get; set; } = false;


        public Sprite(SpriteData spriteData, SpriteSheet spriteSheet)
        {
            Name = spriteData.Name;

            TextureOffsetName = spriteData.TextureOffsetName;

            RenderRectangle = spriteSheet.GetBounds(TextureOffsetName);

            if (spriteData.RenderOrigin.ToLower() == "center")
            {
                Rectangle srcRect = spriteSheet.GetBounds(TextureOffsetName);

                float x = (float)(srcRect.Width)*.5f;
                float y = (float)(srcRect.Height)*.5f;

                RenderOrigin = new Vector2(x, y);
            }
            else
            {
                RenderOrigin = new Vector2(0, 0);
            }


            Color = Color.White;


        }

        public override void Initilize()
        {
           
        }

        public override void Process(float deltaTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
