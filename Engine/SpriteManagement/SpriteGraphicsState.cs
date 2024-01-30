

using Microsoft.Xna.Framework.Graphics;

namespace Engine.SpriteManagement
{
    public struct SpriteGraphicsState
    {
        public BlendState blendState = BlendState.AlphaBlend;
        public SamplerState samplerState = SamplerState.LinearClamp;
        public DepthStencilState depthStencilState = DepthStencilState.None;

        public Effect? effect = null;

        public SpriteGraphicsState()
        {

        }

        public static SpriteGraphicsState PixelArt()
        {
            return new SpriteGraphicsState
            {
                samplerState = SamplerState.PointClamp
            };
        }

    }
}
