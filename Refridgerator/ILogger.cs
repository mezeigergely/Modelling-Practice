using System;
using System.Collections.Generic;
using System.Text;

namespace Refridgerator
{
    interface ILogger
    {
        public void Save(List<Fridge> fridges);
        public void SaveFood(List<Food> foods, string filename);
        public List<Fridge> Load(string filename);
        public List<Food> LoadFood(string filename);
    }
}
