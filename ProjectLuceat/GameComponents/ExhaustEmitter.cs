using Engine.ParticleSystem;
using GameComponents;
using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;

using static Engine.Globals;

namespace ProjectLuceat.GameComponents
{
    public class ExhaustEmitter : ParticleEmitter
    {
        public override string Type => "ExhaustPath";

        public float Speed = 1.0f;


        private ShipController _shipController;


        public ExhaustEmitter(
                               ParticleManager particleManager,
                               ParticleEmitterData emitterData,
                               ParticleData particleData,
                               ShipController shipController) 

        : base(particleManager, emitterData, particleData)
        {

            Name = emitterData.name;
            _shipController = shipController;

        
        }

        public override void Initilize()
        {

        }

        public override Vector2 GetVelocity(ParticleData data, float dt)
        {

            /** To do jitter, ye can simply introduce randomness here **/
            return Speed*new Vector2(MathF.Cos(data.theta), MathF.Sin(data.theta));
        }

        protected override ParticleData getParticleData(ParticleData template)
        {
            /**
             * Called whenever a new particle gets activated. Not on every update.
             */
            ParticleData data = new ParticleData(template);
            
            Vector2 vel = _shipController.Velocity;
            float variance = RandomFloat(-.5f*_emitterData.angleVariance, .5f*_emitterData.angleVariance);

            data.theta = Owner.Parent.Rotation + variance + .5f*MathF.PI;

            return data;
        }


        public override void Process(float deltaTime)
        {
            float r = Owner.Position.Length();
            float theta = .5f * MathF.PI + _shipController.Owner.Rotation;
            float x = r*MathF.Cos(theta);
            float y = r*MathF.Sin(theta);

            Owner.Position = new Vector2(x, y);

            base.Process(deltaTime);
        }


    }
}
