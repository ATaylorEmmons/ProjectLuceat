using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Engine.Input;
using Engine.ParticleSystem;
using Engine.SpriteManagement;


using ProjectLuceat.Scenes;
using Engine.Modular;
using Engine;

namespace ProjectLuceat
{
    public class Game1 : Game
    {

        private GraphicsDeviceManager _graphics;

        private SpriteSystem _spriteSystem;
        private ParticleManager _particleManager;

        private Window _window;

        private Scene MainScene;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);


            Content.RootDirectory = "Content";

            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            _window = new Window(GraphicsDevice);
            base.Initialize();
        }

        protected override void LoadContent()
        {


            _spriteSystem = new SpriteSystem(_graphics.GraphicsDevice);
            //_particleManager = new ParticleManager(_graphics.GraphicsDevice, _spriteSheet, 100);

            MainScene = new MainScene(_window, _spriteSystem, _particleManager);

            MainScene.Initilize(Content);



        }

        protected override void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            InputManager.Update();



            MainScene.Update(dt);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);

            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            MainScene.Draw(dt); 

            base.Draw(gameTime);
        }
    }
}