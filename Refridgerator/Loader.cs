using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Refridgerator
{
    class Loader : ILogger
    {
        string path = "data.xml";
        public List<Fridge> Load(string path)
        {
            var result = new List<Fridge>();
            XmlSerializer serializer3 = new XmlSerializer(typeof(List<Fridge>));
            using (FileStream fs2 = File.OpenRead(path))
            {
                result = (List<Fridge>)serializer3.Deserialize(fs2);
            }
            return result;
        }

        public void Save(List<Fridge> refigrigators)
        {
            using (Stream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.None))
            {
                XmlSerializer serializer2 = new XmlSerializer(typeof(List<Fridge>));
                serializer2.Serialize(fs, refigrigators);
            }
        }
        public List<Food> LoadFood(string path)
        {
            var result = new List<Food>();
            XmlSerializer serializer3 = new XmlSerializer(typeof(List<Food>));
            using (FileStream fs2 = File.OpenRead(path))
            {
                result = (List<Food>)serializer3.Deserialize(fs2);
            }
            return result;
        }
        public void SaveFood(List<Food> foodList, string path)
        {
            using (Stream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.None))
            {
                XmlSerializer serializer2 = new XmlSerializer(typeof(List<Food>));
                serializer2.Serialize(fs, foodList);
            }
        }
    }
}
