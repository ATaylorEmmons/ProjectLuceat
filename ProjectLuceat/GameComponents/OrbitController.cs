using Engine.Modular;
using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;

namespace ProjectLuceat.GameComponents
{
    public class OrbitController : IComponent
    {
        public override string Type => "OrbitController";

        public float ShiftTheta { get; set; } = 0.0f;
        public float R { get; set; } = 1.0f;
        public float OrbitSpeed { get; set; } = 1.0f;



        private float _elapsedTime;


        public override void Initilize()
        {
            _elapsedTime = 0;

        }

        public override void Process(float deltaTime)
        {
            _elapsedTime += deltaTime;

            float theta = ShiftTheta + OrbitSpeed * _elapsedTime;

            float x = R * MathF.Cos(theta);
            float y = R * MathF.Sin(theta);

            Owner.Position = new Vector2(x, y);

            Owner.Rotation = theta + .5f*MathF.PI;

        }
    }
}
