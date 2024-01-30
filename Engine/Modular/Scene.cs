
using Engine.SpriteManagement;
using Engine.ParticleSystem;
using Microsoft.Xna.Framework.Content;

namespace Engine.Modular
{
    public class Scene
    {
        public Camera2D Camera { get; private set; }
        public Entity Root { get; private set; }
 

        protected SpriteSystem _spriteSystem;
        protected ParticleManager? _particleManager;



        public Scene(Window window, SpriteSystem spriteSystem)
        {
            Camera = new Camera2D(window);
            Root = new Entity();
            _spriteSystem = spriteSystem;
            _particleManager = null;
        }

        public Scene(Window viewport, SpriteSystem spriteSystem, 
                     ParticleManager particleManager)
        {
            Camera = new Camera2D(viewport);
            Root = new Entity();
            _spriteSystem = spriteSystem;
            _particleManager = particleManager;
        }

        public virtual void Initilize(ContentManager Content) { }

        public virtual void Update(float dt)
        {
   
            for (int i = 0; i < Root.Count(); i++) {
                Root.Update(dt);
            }


            if (_particleManager != null)
            {
                _particleManager.Update(dt);
            }

            _spriteSystem.Update(Camera.GetViewBounds());
        }

        public virtual void Draw(float dt)
        {
            /**
             *   TODO: 
             *      
             *   - Do optimization to only draw what the camera
             *      can see here or elsewhere?
             *   
             */



            if( _particleManager != null )
            {
                _particleManager.Draw(dt);
            }

            _spriteSystem.Draw();
        }

    }
}
