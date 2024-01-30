using Engine.ParticleSystem;
using GameComponents;
using Microsoft.Xna.Framework;
using System;


namespace ProjectLuceat.GameComponents
{
    public class CircleExhaustEmitter : ParticleEmitter
    {

        public float A { get; set; }
        public float B { get; set; }

        public float R { get; set; }

        private ShipController _shipController;
        private float totalTime;

        public CircleExhaustEmitter(
                               ParticleManager particleManager,
                               ParticleEmitterData emitterData,
                               ParticleData particleData,
                               ShipController shipController,
                               string name)

        : base(particleManager, emitterData, particleData)
        {

            Name = name;
            _shipController = shipController;

        }

        public override void Initilize()
        {
            A = 1.0f;
            B = 1.0f;
            R = 1.0f;

            totalTime = 0.0f;
        }

        public override Vector2 GetVelocity(ParticleData data, float dt)
        {
            float t = data.lifeSpanRatio;
            Vector2 curl = new Vector2(R * MathF.Cos(2.0f * MathF.PI * t), R * MathF.Sin(2.0f * MathF.PI * t));

            return data.Normal * dt + curl;
        }

        protected override ParticleData getParticleData(ParticleData template)
        {

            return new ParticleData(template);
        }


        public override void Process(float dt)
        {
            totalTime += dt;
            R = 2.0f * MathF.Cos(totalTime);

            base.Process(dt);
        }
    }
}
