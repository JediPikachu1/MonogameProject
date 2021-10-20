using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Linq;

using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameProject
{
    public class Sprite
    {
        protected Vector2 position;

        public Texture2D _stickman;

        public float Speed = 4f;
        public Vector2 Velocity;

        public Vector2 Position
        {
            get { return position; }
            set { }
        }
        public Sprite(Texture2D texture)
        {
            _stickman = texture;
        }
        protected virtual void move()
        {
            if (InputManager.Instance.KeyDown(Keys.W))
                Velocity.Y = -Speed;
            if (InputManager.Instance.KeyDown(Keys.S))
                Velocity.Y = Speed;
            if (InputManager.Instance.KeyDown(Keys.A))
                Velocity.X = -Speed;
            if (InputManager.Instance.KeyDown(Keys.D))
                Velocity.X = Speed;
        }

        public virtual void Update(GameTime gameTime)
        {
            move();

            position += Velocity;
            Velocity = Vector2.Zero;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (_stickman != null)
                spriteBatch.Draw(_stickman, position, Color.White);


        }
    }
}
