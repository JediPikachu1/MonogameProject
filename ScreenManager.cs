using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace MonogameProject
{
    
    public class ScreenManager
    {
        private static ScreenManager instance;

        public Image Image;
        [XmlIgnore]
        public Vector2 Dimension { private set; get; }

        [XmlIgnore]
        public bool IsTransitioning { private set; get; }
        [XmlIgnore]
        public ContentManager Content { private set; get; }

        GameScreen currentScreen, newScreen;

        XmlManager<GameScreen> XmlGameScreenManager;

        [XmlIgnore]
        public GraphicsDevice GraphicsDevice;
        [XmlIgnore]
        public SpriteBatch SpriteBatch;
        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                {
                    XmlManager<ScreenManager> xml = new XmlManager<ScreenManager>();
                    instance = xml.Load("Load/ScreenManager.xml");
                    
                    // instance = new ScreenManager();
                }



                return instance;
            }
            
        }

        public ScreenManager()
        {
            Dimension = new Vector2(1920, 1080);

            currentScreen = new SplashScreen();

            XmlGameScreenManager = new XmlManager<GameScreen>();
            XmlGameScreenManager.type = currentScreen.type;
            currentScreen = XmlGameScreenManager.Load("Load/SplashScreen.xml");

        }

        public void ChangeScreens(string screenName)
        {
            newScreen = (GameScreen)Activator.CreateInstance(Type.GetType("MonogameProject." + screenName));
            Image.IsActive = true;
            Image.FadeEffect.Inc = true;
            Image.Alpha = 0.0f;
            IsTransitioning = true;
        }
        public void Transition(GameTime gameTime)
        {
            if (IsTransitioning)
            {
                Image.Update(gameTime);
                if (Image.Alpha == 1.0f)
                {

                    currentScreen.UnloadContent();
                    currentScreen = newScreen;
                    XmlGameScreenManager.type = currentScreen.type;
                    if (File.Exists(currentScreen.XmlPath))
                    {
                        currentScreen = XmlGameScreenManager.Load(currentScreen.XmlPath);
                    }
                    currentScreen.LoadContent();
                }
                else if (Image.Alpha == 0.0f)
                {
                    Image.IsActive = false;
                    IsTransitioning = false;
                }
            }
        }
        public void LoadContent(ContentManager Content)
        {
            this.Content = new ContentManager(Content.ServiceProvider, "Content");
            currentScreen.LoadContent();
            Image.LoadContent();
        }

        public void UnloadContent()
        {
            currentScreen.UnloadContent();
            Image.UnloadContent();
        }

        public void Update(GameTime gametime)
        {
            currentScreen.Update(gametime);
            Transition(gametime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
            if (IsTransitioning)
                Image.Draw(spriteBatch);
        }

        
    }
}
