using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace MonogameProject
{
    public class GameScreen
    {
        protected ContentManager content;

        [XmlIgnore]
        public Type type;

        public string XmlPath;

        public GameScreen()
        {
            type = this.GetType();
            XmlPath = "Load/" + type.ToString().Replace("MonogameProject.", "") + ".xml";
        }

        public virtual void LoadContent()
        {
            content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "Content");
        }

        public virtual void UnloadContent()
        {

        }

        public virtual void Update(GameTime gameTime)
        {
            InputManager.Instance.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }

    }
}
