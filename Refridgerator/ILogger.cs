using System;
using System.Collections.Generic;
using System.Text;

namespace Refridgerator
{
    interface ILogger
    {
        public void Save(List<Fridge> fridges);
        public void SaveFood(List<Food> foods, string filepath);
        public List<Fridge> Load(string filepath);
        public List<Food> LoadFood(string filepath);
    }
}
