using Engine.SpriteManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace Engine.ParticleSystem
{
    public class ParticleManager
    {
        private Particle[] _particles;

        private GraphicsDevice _graphicsDevice;
        private SpriteBatch _spriteBatch;
        private SpriteSheet _spriteSheet;

        private int _deadParticleOffset;
        private int _maxParticles;


        public ParticleManager(GraphicsDevice graphicsDevice, 
                               SpriteSheet spriteSheet, 
                               int particleCount) { 

            _graphicsDevice = graphicsDevice;
            _spriteBatch = new SpriteBatch(_graphicsDevice);
            _spriteSheet = spriteSheet;

            _deadParticleOffset = 0;
            _maxParticles = particleCount;

            _particles = new Particle[particleCount];

            for(int i = 0; i < _maxParticles; i++)
            {
                _particles[i] = new Particle(this, _spriteSheet);
            }

        }

        public void ActivateParticles(Vector2 position, ParticleEmitter emitter, ParticleData particleData, int count)
        {

            int newActiveParticles = count;
            if (_deadParticleOffset + count > _particles.Length)
            {
                newActiveParticles = _particles.Length - _deadParticleOffset;
            }

            for (int i = _deadParticleOffset; i < _deadParticleOffset + newActiveParticles; i++)
            {
                _particles[i].Activate(position, emitter, particleData);
            }

            _deadParticleOffset += newActiveParticles;

        }

        public void Update(float dt)
        {
  
            for(int i = 0; i < _deadParticleOffset; i++)
            {
                _particles[i].Update(dt);
            }

            //Sort out dead particles

            for (int i = 0; i < _deadParticleOffset; i++)
            {
                _particles[i].Update(dt);

                if (_particles[i].isDead)
                {
                    Particle temp = _particles[i];
                    _particles[i] = _particles[_deadParticleOffset - 1];
                    _particles[_deadParticleOffset - 1] = temp;
                    _deadParticleOffset--;
                }
            }


        }

        public void Draw(float dt)
        {
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            for (int i = 0; i < _deadParticleOffset; i++)
            {
                _particles[i].Draw(_spriteBatch, _spriteSheet);
            }
            _spriteBatch.End();
        }
    }
}
