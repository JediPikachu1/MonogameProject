using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameProject
{


    public class SplashScreen : GameScreen
    {
        [XmlElement("Path")]
        public string path;

        public Image Image;
        
        Texture2D image;


        public override void LoadContent()
        {
            
            base.LoadContent();
            Image.LoadContent();
            // path = "scourgekeyart";
            // image = content.Load<Texture2D>(path);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            Image.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Image.Update(gameTime);

            if (InputManager.Instance.KeyPressed(Keys.Enter, Keys.Z))
                ScreenManager.Instance.ChangeScreens("MainMenu");
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            
            // spriteBatch.Draw(image, destinationRectangle: new Rectangle(0, 0, 1920, 1080), Color.White);
            Image.Draw(spriteBatch);
        }
    }
}
