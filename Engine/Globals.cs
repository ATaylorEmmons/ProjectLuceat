using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace Engine
{
    public static class Globals
    {

        public static float HALF_PI = MathF.PI / 2;

        public static Random Random { get; set; } = new();

        public static float RandomFloat(float min, float max)
        {
            return (float)(Random.NextDouble() * (max - min) + min);
        }

    }
}
