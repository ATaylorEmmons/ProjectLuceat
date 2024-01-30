
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Engine.Modular;
using Engine.SpriteManagement;

namespace Engine.ParticleSystem
{
    public class Particle : Transform
    {

        private Vector2 _renderOrigin;


        private ParticleEmitter? _emitter;
        private ParticleManager _manager;

        private float _lifeRemaining;
        private Color _color;
        private float _opacity;

        public bool isDead = true;

        private ParticleData? _data;
        private SpriteSheet _spriteSheet;

        public Particle(ParticleManager manager, SpriteSheet spriteSheet) {

            _manager = manager;
            _spriteSheet = spriteSheet;


        }


        public void Activate(Vector2 worldPos, ParticleEmitter emitter, ParticleData particleData)
        {
            WorldPosition = worldPos;
            _emitter = emitter;
            isDead = false;

            _data = particleData;
            _lifeRemaining = _data.lifespan;


            Rectangle srcRect = _spriteSheet.GetBounds(particleData.TextureOffsetName);

            float x = (float)(srcRect.Width) * .5f;
            float y = (float)(srcRect.Height) * .5f;

            _renderOrigin = new Vector2(x, y);
        }

        public void Update(float dt)
        {

            _lifeRemaining -= dt;


            if (_lifeRemaining < 0f)
            {
                isDead = true;
                return;
            }

            _data.lifeSpanRatio = _lifeRemaining / _data.lifespan;

            float s = MathHelper.Lerp(_data.endScale, _data.startScale, _data.lifeSpanRatio);
            Scale = new Vector2(s, s);

            WorldPosition += _emitter.GetVelocity(_data, dt);

            _color = Color.Lerp(_data.endColor, _data.startColor, _data.lifeSpanRatio);

            _opacity = MathHelper.Lerp(_data.endOpacity, _data.startOpacity, _data.lifeSpanRatio);
            _opacity = MathHelper.Clamp(_opacity, 0, 1);

        }

        public void Draw(SpriteBatch sb, SpriteSheet spriteSheet)
        {
            sb.Draw(
                spriteSheet.Texture,
                WorldPosition,
                spriteSheet.GetBounds(_data.TextureOffsetName),
                _color * _opacity,
                Rotation,
                _renderOrigin,
                Scale,
                SpriteEffects.None,
                1f);

        }

    }
}
