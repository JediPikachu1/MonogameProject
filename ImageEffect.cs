﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace MonogameProject
{
    public class ImageEffect
    {
        protected Image Image;

        public bool isActive;

        protected float Alpha = 0;

        public ImageEffect()
        {

        }

        public virtual void LoadContent(ref Image Image)
        {
            this.Image = Image;
            this.Alpha = Image.Alpha;
        }

        public virtual void UnloadContent()
        {

        }

        public virtual void Update(GameTime gameTime)
        {

        }
    }
}
