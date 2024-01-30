using Microsoft.Xna.Framework;


namespace Engine.Modular
{

    public class Transform
    {

        public Vector2 WorldPosition { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Scale { get; set; }

        public float Rotation { get; set; }

        public float PixelsPerMeter { get; set; } = 128f;



        public Vector2 GetScreenPosition() { 
            return WorldPosition * PixelsPerMeter; 
        }

        public Vector2 GetScreenScale()
        {
            return Scale * PixelsPerMeter;
        }

        public Transform()
        {
            this.WorldPosition = new Vector2(0.0f, 0.0f);
            this.Rotation = 0.0f;
            this.Scale = new Vector2(1.0f, 1.0f);
        }

    }
}