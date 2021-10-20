using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using System.Xml.Serialization;


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameProject
{
    public class XmlManager<T>
    {
        public Type type { get; set; }

        public XmlManager()
        {
            type = typeof(T);
        }
        public T Load(string path)
        {
            T instance;
            using (TextReader reader = new StreamReader(path))
            {
                XmlSerializer xml = new XmlSerializer(type);
                instance = (T)xml.Deserialize(reader);
            }
            return instance;
        }

        public void Save(String path, object obj)
        {
            using (TextWriter writer = new StreamWriter(path))
            {
                XmlSerializer xml = new XmlSerializer(type);
                xml.Serialize(writer, obj);
            }
        }
    }
}
