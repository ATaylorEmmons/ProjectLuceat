using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace Engine.Modular
{
    public class Camera2D : Transform
    {


        public float FoV { get; set; } = MathF.PI / 2;
        public float MinZ { get; set; } = 5.0f;
        public float MaxZ { get; set; } = 1000.0f;



        private float z;
        private float base_z;
        private float aspectRatio;

        private float _screenWidth;
        private float _screenHeight;

        private Rectangle viewBounds;



        public Camera2D(Window window)
        {

            aspectRatio = window.AspectRatio;

            _screenWidth = window.Width;
            _screenHeight = window.Height; 
        }

        public Rectangle GetViewBounds()
        {
            return viewBounds;
        }

        public Matrix GetMatrix()
        {
            Matrix toScreenSpace = Matrix.CreateTranslation(new Vector3(.5f * _screenWidth, .5f * _screenHeight, 0.0f));
            Matrix translation = Matrix.CreateTranslation(new Vector3(-Position.X*PixelsPerMeter, Position.Y*PixelsPerMeter, 0.0f));
            Matrix rotation = Matrix.CreateRotationZ(-Rotation);
            Matrix scale = Matrix.CreateScale(Scale.X, Scale.Y, 1.0f);

            return translation * rotation * scale * toScreenSpace;

        }

    }
}
















