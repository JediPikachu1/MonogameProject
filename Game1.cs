using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System.Collections.Generic;
namespace MonogameProject
{
    public class Game1 : Game
    {


        //private Texture2D button;
       
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        
        private Texture2D _stickmanTexture;
        private Sprite _stickmanTest;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = (int)ScreenManager.Instance.Dimension.X;
            _graphics.PreferredBackBufferHeight = (int)ScreenManager.Instance.Dimension.Y;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //button = Content.Load<Texture2D>("poelogin");

            ScreenManager.Instance.GraphicsDevice = GraphicsDevice;
            ScreenManager.Instance.SpriteBatch = _spriteBatch;

            ScreenManager.Instance.LoadContent(Content);
            _stickmanTexture = Content.Load<Texture2D>("stickmansteve");

            _stickmanTest = new Sprite(_stickmanTexture);
            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            ScreenManager.Instance.UnloadContent();
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            ScreenManager.Instance.Update(gameTime);

            _stickmanTest.Update(gameTime);

            base.Update(gameTime);
            /*
            switch (_state)
            {
                case GameState.SplashScreen:
                    UpdateSplashScreen(gameTime);
                    break;
                case GameState.MainMenu:
                    UpdateMainMenu(gameTime);
                    break;
            }
            */
        }

        /*
         * void UpdateSplashScreen(GameTime gameTime)
        {
            if (InputManager.Instance.KeyPressed(Keys.Enter))
            {
                _state = GameState.MainMenu;
            }
        }

        void UpdateMainMenu(GameTime gameTime)
        {
            if (InputManager.Instance.KeyPressed(Keys.RightShift))
            {
                _state = GameState.SplashScreen;
            }
        }

        */
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            
            ScreenManager.Instance.Draw(_spriteBatch);
            /*
            if (ScreenManager.Instance.currentScreen == ScreenManager.Instance.XmlGameScreenManager.)
            {
                _stickmanTest.Draw(_spriteBatch);
            }
            */
            //_stickmanTest.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
