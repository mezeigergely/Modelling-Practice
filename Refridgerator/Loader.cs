using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Refridgerator
{
    class Loader : ILogger
    {
        string filename = "data.xml";
        public List<Fridge> Load(string filename)
        {
            var item = new List<Fridge>();
            XmlSerializer fridgeSER = new XmlSerializer(typeof(List<Fridge>));
            using (FileStream fileStream = File.OpenRead(filename))
            {
                item = (List<Fridge>)fridgeSER.Deserialize(fileStream);
            }
            return item;
        }

        public void Save(List<Fridge> fridges)
        {
            using (Stream stream = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite, FileShare.None))
            {
                XmlSerializer fridgeSER = new XmlSerializer(typeof(List<Fridge>));
                fridgeSER.Serialize(stream, fridges);
            }
        }
        public List<Food> LoadFood(string filename)
        {
            var item = new List<Food>();
            XmlSerializer foodSER = new XmlSerializer(typeof(List<Food>));
            using (FileStream fileStream = File.OpenRead(filename))
            {
                item = (List<Food>)foodSER.Deserialize(fileStream);
            }
            return item;
        }
        public void SaveFood(List<Food> foodList, string filename)
        {
            using (Stream fileStream = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite, FileShare.None))
            {
                XmlSerializer foodSER = new XmlSerializer(typeof(List<Food>));
                foodSER.Serialize(fileStream, foodList);
            }
        }
    }
}
