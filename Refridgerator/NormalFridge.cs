﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Refridgerator
{
    public class NormalFridge : Fridge
    {
        public NormalFridge(string name, int capacity, int varicapacity)
        {
            this.name = name;
            this.capacity = capacity;
            this.variCapacity = varicapacity;
        }
        public NormalFridge() { }

        public override void AddFood(Food food)
        {
            int temp = 0;
            foreach (var item in foodinfridge)
            {
                temp = temp + item.size;
            }
            if (temp + food.size > variCapacity)
            {
                throw new Exception("Error 2");
            }
            else
            {
                foodinfridge.Add(food);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(food.name + " added");
            }
        }
        public override void RemoveFood(Food food)
        {
            foodinfridge.Remove(food);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(food.name + " is on the Table now!");
            Console.ForegroundColor = ConsoleColor.Gray;
            variCapacity += food.size;

        }
    }
}
