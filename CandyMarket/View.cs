using System;
using System.Collections.Generic;

namespace CandyMarket
{
    internal class View
    {
        string companyName = @"
           ██████╗██████╗  ██████╗ ███████╗███████╗
          ██╔════╝██╔══██╗██╔═══██╗██╔════╝██╔════╝
          ██║     ██████╔╝██║   ██║███████╗███████╗
          ██║     ██╔══██╗██║   ██║╚════██║╚════██║
          ╚██████╗██║  ██║╚██████╔╝███████║███████║
           ╚═════╝╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚══════╝
  
     ██████╗ █████╗ ███╗   ██╗██████╗ ██╗███████╗███████╗
    ██╔════╝██╔══██╗████╗  ██║██╔══██╗██║██╔════╝██╔════╝
    ██║     ███████║██╔██╗ ██║██║  ██║██║█████╗  ███████╗
    ██║     ██╔══██║██║╚██╗██║██║  ██║██║██╔══╝  ╚════██║
    ╚██████╗██║  ██║██║ ╚████║██████╔╝██║███████╗███████║
     ╚═════╝╚═╝  ╚═╝╚═╝  ╚═══╝╚═════╝ ╚═╝╚══════╝╚══════╝
";
        IList<string> _menuItems;
        int itemNumber = 0;

        internal View()
        {
            _menuItems = new List<string> { companyName };
        }

        internal View AddMenuText(string text)
        {
            var menuText = $"{Environment.NewLine}{text}{Environment.NewLine}";
            _menuItems.Add(menuText);
            return this;
        }

        internal View AddMenuOption(string menuItem)
        {
            ++itemNumber;
            var menuEntry = $"{itemNumber}. {menuItem}";
            _menuItems.Add(menuEntry);
            return this;
        }

        internal View EatMenuOption(string candy, int count)
        {
            ++itemNumber;
            var menuEntry = $"{itemNumber}. {candy}: {count}";
            _menuItems.Add(menuEntry);
            return this;
        }

        internal View AddMenuOptions(IList<string> menuItems)
        {
            foreach (var menuItem in menuItems)
            {
                AddMenuOption(menuItem);
            }

            return this;
        }

        internal View RemoveMenuOptions(Dictionary<string, int> menuItems)
        {
            foreach (var menuItem in menuItems)
            {
                {
                    EatMenuOption(menuItem.Key, menuItem.Value);
                }
               
            }

            return this;
        }

        internal string GetFullMenu()
        {
            Console.Clear();
            var menu = string.Join(Environment.NewLine, _menuItems);
            return $"{menu}{Environment.NewLine}> ";
        }
    }
}