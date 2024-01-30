
using Microsoft.Xna.Framework;

using Engine.Modular;
using Engine.Input;
using System;

namespace GameComponents
{
    public class ShipController : IComponent
    {

        public override string Type => "ShipController";

        float forwardSpeed = 550.0f;

        public Vector2 Velocity { get; private set; }

        Vector2 acceleration;
        Vector2 drag;

        float driftSpeed = 2.5f;
        Vector2 driftVelocity;
        Vector2 driftAcceleration;
        Vector2 driftDrag;

        public ShipController(string name) {
            Name = name;
        
        }

        public override void Initilize()
        {
            
        }
        public override void Process(float dt)
        {

            Vector2 forward = Vector2.Zero;

            Vector2 posToMouse = InputManager.MousePos - Owner.WorldPosition;
            float angle = MathF.Atan2(posToMouse.Y, posToMouse.X);

            Owner.Rotation = angle + .5f * MathF.PI;

            if (InputManager.W)
            {
                forward = new Vector2(MathF.Cos(angle), MathF.Sin(angle));
            }

            Velocity = dt * acceleration + Velocity;
            acceleration = forwardSpeed * dt * forward - drag;
            drag = 2.0f * Velocity;

            Owner.Position += Velocity;
        }
    }
}
