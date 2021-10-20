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
    public class MainMenu : GameScreen
    {
        [XmlElement("Path")]
        public string path;

        

        public Image Image;

        private MouseState currentMouse;
        private MouseState prevMouse;

        private Texture2D _button;

        private SpriteBatch _spriteBatch;

        

        public override void LoadContent()
        {
            content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "Content");

            
            

            base.LoadContent();

            _button = content.Load<Texture2D>("poelogin");
            Image.LoadContent();

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
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //base.Draw(spriteBatch);
            //spriteBatch.Begin();
            //spriteBatch.Draw(_button, new Vector2(1000, 800), Color.White);
            //spriteBatch.End();

            Image.Draw(spriteBatch);
            
            
        }
    }
}
