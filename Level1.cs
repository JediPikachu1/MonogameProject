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
    public class Level1 : GameScreen
    {
        [XmlElement("Path")]
        public string path;



        public Image Image;


        private Sprite stickman;
        private Texture2D stickmanTexture;



        public override void LoadContent()
        {
            content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "Content");




            base.LoadContent();

            Image.LoadContent();

            stickmanTexture = content.Load<Texture2D>("stickmansteve");

            stickman = new Sprite(stickmanTexture);

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

            stickman.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //base.Draw(spriteBatch);
            

            Image.Draw(spriteBatch);

            stickman.Draw(spriteBatch);
        }

    }
}
