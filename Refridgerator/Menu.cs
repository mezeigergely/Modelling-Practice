using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.IO;

namespace Refridgerator
{
    class Menu
    {
        private List<Fridge> Fridges = new List<Fridge>();
        private List<Food> table = new List<Food>();
        private ILogger logger;

        //public Menu()
        //{

        //}
        public List<Fridge> fridges
        {
            get { return Fridges; }
            set { Fridges = value; }
        }
        public List<Food> Table
        {
            get { return table; }
            set { table = value; }
        }

        public Menu(ILogger logger)
        {
            this.logger = logger;
        }

        public bool MainMenu()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Add New Food to the Table");
            Console.WriteLine("2) What is on the Table?");
            Console.WriteLine();
            Console.WriteLine("3) Add New Fridge");
            Console.WriteLine("4) My Fridges");
            Console.WriteLine();
            Console.WriteLine("5) Put Food into the Fridge");
            Console.WriteLine();
            Console.WriteLine("6) Remove Food from the Fridge");
            Console.WriteLine("7) Remove Food from the Table");
            Console.WriteLine();
            Console.WriteLine("8) Save");
            Console.WriteLine("9) Load");
            Console.WriteLine();
            Console.WriteLine("0) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    if (name.Length <= 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Minimum 3 characters!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write("Quantity (gr/ml): ");
                        try
                        {
                            int quantity = int.Parse(Console.ReadLine());
                            Console.Write("Calories: ");
                            int calorie = int.Parse(Console.ReadLine());
                            Console.Write("Size: ");
                            int size = int.Parse(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nFood added!");
                            Food food = new Food(IDmaker(), name, quantity, calorie, size);
                            table.Add(food);

                        }
                        catch (Exception)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Not a correct format!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }  
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return true;
                case "2":
                    Console.ForegroundColor = ConsoleColor.White;
                    if (table.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("There are no foods on the table");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    foreach (Food item in table)
                    {
                        Console.WriteLine("ID: " + item.id.ToString() + ", " + item.name + ", " + item.quantity.ToString() + " gr/ml, " + item.calories.ToString() + " kcal, Size: " + item.size.ToString());
                    }
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return true;
                case "3":
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Name of the New Refrigerator: ");
                    string newRefrigName = Console.ReadLine();
                    if (newRefrigName == "")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong Input");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write("Capacity (liter): ");
                    int newRefrigCapacity = 0;
                    try
                    {
                        newRefrigCapacity = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Not a correct format!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        return true;
                    }
                    
                    if (newRefrigCapacity >= 0 && newRefrigCapacity <= 50)
                    {
                        Fridge miniRefrigerator = new MiniFridge(newRefrigName, newRefrigCapacity, newRefrigCapacity);
                        Fridges.Add(miniRefrigerator);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(miniRefrigerator.name + " with " + miniRefrigerator.capacity + " liters capacity added!");
                    }
                    else if (newRefrigCapacity >= 51 && newRefrigCapacity <= 149)
                    {
                        Fridge normailRefrigerator = new NormalFridge(newRefrigName, newRefrigCapacity, newRefrigCapacity);
                        Fridges.Add(normailRefrigerator);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(normailRefrigerator.name + " with " + normailRefrigerator.capacity + " liters capacity added!");
                    }
                    else if (newRefrigCapacity >= 150 && newRefrigCapacity <= 300)
                    {
                        Fridge largeRefrigerator = new LargeFridge(newRefrigName, newRefrigCapacity, newRefrigCapacity);
                        Fridges.Add(largeRefrigerator);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(largeRefrigerator.name + " with " + largeRefrigerator.capacity + " liters capacity added!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong input");
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return true;
                case "4":
                    Console.ForegroundColor = ConsoleColor.White;
                    if (Fridges.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("There are no fridges");
                    }
                    foreach (Fridge fridge in Fridges)
                    {
                        fridge.DisplayFridgeInfo();
                    }
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return true;
                case "5":
                    Console.ForegroundColor = ConsoleColor.White;
                    if (Fridges.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("There are no fridges");
                    }
                    else if (table.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("There are no foods");
                    }
                    else
                    {
                        Console.WriteLine("Fridge(s): ");
                        foreach (Fridge fridge in Fridges)
                        {
                            Console.WriteLine(fridge.name + ", " + fridge.capacity + " liter");
                        }
                        Console.WriteLine();

                        Console.WriteLine("Food(s): ");
                        foreach (Food item in table)
                        {
                            Console.WriteLine("ID: " + item.id.ToString() + ", " + item.name + ", " + item.quantity.ToString() + " gr/ml, " + item.calories.ToString() + " kcal, Size: " + item.size.ToString());
                        }
                        Console.WriteLine();
                        Console.Write("Fridge name: ");
                        string fridgename = Console.ReadLine();
                        Console.Write("Food ID: ");
                        int foodID = int.Parse(Console.ReadLine());
                        
                        int temp = 0;


                        foreach (Fridge fridge in Fridges)
                        {
                            if (fridgename == fridge.name)
                            {
                                foreach (Food food in table)
                                {
                                    if (foodID == food.id)
                                    {
                                        fridge.AddFood(food);
                                        temp = food.id;
                                        fridge.variCapacity -= food.size;
                                    }
                                    else
                                    {
                                        Console.WriteLine("There is no {0} food ID!", foodID);
                                        return true;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("There is no {0} fridge!",fridgename);
                                return true;
                            }
                        }
                        for (int i = table.Count - 1; i >= 0; i--)
                        {
                            if (table[i].id == temp)
                            {
                                table.RemoveAt(i);
                            }
                        }


                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return true;
                case "6":
                    Console.ForegroundColor = ConsoleColor.White;
                    int deletingFoodID = 0;
                    foreach (Fridge fridge in Fridges)
                    {
                        fridge.DisplayFridgeInfo();
                        Console.WriteLine();
                        Console.Write("Removing Food ID: ");
                        try
                        {
                            deletingFoodID = int.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Not a correct format!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            return true;
                        }
                        
                        Food temp = fridge.FindFood(deletingFoodID);
                        fridge.RemoveFood(fridge.FindFood(deletingFoodID));
                        table.Add(temp);
                        

                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return true;
                case "7":
                    Console.ForegroundColor = ConsoleColor.White;
                    if (table.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("There are no foods on the table");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    foreach (Food item in table)
                    {
                        Console.WriteLine("ID: " + item.id.ToString() + ", " + item.name + ", " + item.quantity.ToString() + " gr/ml, " + item.calories.ToString() + " kcal, Size: " + item.size.ToString());
                    }
                    Console.WriteLine();
                    int removingFoodID = 0;
                    Console.Write("Removing Food ID: ");
                    try
                    {
                        removingFoodID = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Not a correct format!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        return true;
                    }
                    
                    for (int i = table.Count - 1; i >= 0; i--)
                    {
                        if (table[i].id == removingFoodID)
                        {
                            table.RemoveAt(i);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Food is removed");
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return true;
                case "8":
                    logger.Save(fridges);
                    if (Table.Count > 0)
                    {
                        logger.SaveFood(Table, "foodsonthetable.xml");
                    }
                    Console.WriteLine("Saved!");
                    return true;
                case "9":
                    try
                    {
                        fridges = logger.Load("data.xml");
                        if (File.Exists("foodsonthetable.xml"))
                        {
                            Table = logger.LoadFood("foodsonthetable.xml");
                        }
                        Console.WriteLine("Loaded!");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("There is no saved data.");
                    }
                    return true;
                case "0":
                    return false;
                default:
                    return true;
            }
        }
        public int IDmaker()
        {
            Random r = new Random();
            int temp = r.Next(100000, 999999);
            return temp;
        }
    }
}
