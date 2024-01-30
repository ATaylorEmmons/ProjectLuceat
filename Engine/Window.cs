using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Window
    {
        public float Width { get; private set; }
        public float Height { get; private set; }
        public float AspectRatio { get; private set; }

        private GraphicsDevice _graphicsDevice;

        public Window(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;

            Width = _graphicsDevice.Viewport.Width;
            Height = _graphicsDevice.Viewport.Height;

            AspectRatio = Width / Height;
        }

        public void Resize()
        {
            throw new NotImplementedException();
        }

    }
}
