using System;
using System.Collections.Generic;

namespace Refridgerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu(new Loader());
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = menu.MainMenu();
            }
        }

    }
}

