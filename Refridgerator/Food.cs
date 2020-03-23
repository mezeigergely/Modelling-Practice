using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Refridgerator
{
    
    public class Food
    {
        public int id;
        public string name;
        public int quantity;
        public int calories;
        public int size;
        public List<Food> foodontable = new List<Food>();
        //public string filename;

        public int ID => id;
        public string Name => name;
        public int Quantity => quantity;
        public int Calories => calories;

        public Food()
        {

        }

        //public Food(string filename)
        //{
        //    this.filename = filename;
        //    LoadFile();

        //}

        public Food(int id, string name, int quantity, int calories, int size)
        {
            this.id = id;
            this.name = name;
            this.quantity = quantity;
            this.calories = calories;
            this.size = size;

        }

        public void LoadFile(string filepath = "food.csv")
        {
            Console.Clear();
            try
            {
                string[] lines = File.ReadAllLines(filepath);
                foreach (string line in lines)
                {
                    string[] temp = line.Split(",");
                    Console.WriteLine("ID: {0}, {1}, {2} gr/ml, {3} kcal, Size: {4}", temp[0], temp[1], temp[2], temp[3], temp[4]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("\n\nPress key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public void RemoveFoodFromTheTable(Food food)
        {
            foodontable.Remove(food);
        }

        public void AddNewFood(Food food)
        {
            foodontable.Add(food);
        }

        public void DisplayTable()
        {
            if (foodontable.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There are no foods on the table");
                Console.ForegroundColor = ConsoleColor.White;
            }
            foreach (var item in foodontable)
            {
                Console.WriteLine(item.id + ", " + item.name.ToUpper() + ", " + item.quantity + " gr/ml, " + item.calories + " kcal, Size: " + item.size);
            }
        }
    }



}
