using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Refridgerator
{
    [XmlInclude(typeof(MiniFridge))]
    [XmlInclude(typeof(NormalFridge))]
    [XmlInclude(typeof(LargeFridge))]
    [XmlInclude(typeof(Food))]
    public abstract class Fridge
    {
        public string name;
        public int capacity;
        public int variCapacity;
        protected List<Food> foodinfridge = new List<Food>();

        //public Fridge(string name, int capacity, int varicapacity)
        //{
        //    this.name = name;
        //    this.capacity = capacity;
        //    variCapacity = varicapacity;
        //}

        public abstract void AddFood(Food food);
        public abstract void RemoveFood(Food food);

        public void DisplayFridgeInfo()
        {
            Console.WriteLine("Fridge(s): ");
            Console.WriteLine(name + ", " + capacity + " / " + variCapacity);
            foreach (var item in foodinfridge)
            {
                Console.WriteLine("ID: " + item.id + ", " + item.name + ", " + item.quantity + "gr/ml, " + item.calories + " kcal, Size: " + item.size);
            }
            
        }
        public Food FindFood(int id)
        {
            foreach (var food in foodinfridge)
            {
                if (food.id.Equals(id))
                {
                    return food;
                }
            }
            throw new Exception();
        }
    }
}
