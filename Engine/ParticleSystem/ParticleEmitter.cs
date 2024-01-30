using Engine.Modular;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace Engine.ParticleSystem
{
    public class ParticleEmitter : IComponent
    {

        public override string Type => "ParticleEmitter";


        protected ParticleEmitterData _emitterData;

        private ParticleManager _particleManager;
        private ParticleData _particleData;


        private float _tilNextEmit;

        public ParticleEmitter(
                               ParticleManager particleManager, 
                               ParticleEmitterData emitterData, 
                               ParticleData particleData)
        {
            _emitterData = emitterData;
            _particleData = particleData;
            _particleManager = particleManager;
            _tilNextEmit = 0;

            Name = emitterData.name;

        }

        public override void Initilize()
        {

        }

        public virtual Vector2 GetVelocity(ParticleData particleData, float dt)
        {
            return new Vector2();
        }

        public override void Process(float dt)
        {

            if (_tilNextEmit <= 0f)
            {

                _tilNextEmit = _emitterData.emitInterval;

                for (int i = 0; i < _emitterData.emitCount; i++)
                {
                    _particleManager.ActivateParticles(Owner.WorldPosition,
                                                       this,
                                                       getParticleData(_particleData),
                                                       1);
                }
            }

            _tilNextEmit -= dt;

        }


        protected virtual ParticleData getParticleData(ParticleData template)
        {
            ParticleData data = new ParticleData(template);

            return data;
        }

    }
}
