using Newtonsoft.Json;
using ResturantSystem.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Resturant_Project.Modules
{
    public static class Menu
    {
        private static readonly string filePath = "C:\\Users\\USER\\source\\repos\\ResturantSystem\\ResturantSystem\\OurData\\MenuItems.json";

        // Public property to access all menu items
        public static List<MenuItem> AllMenuItems 
        {
            get
            {
                if (File.Exists(filePath))
                {
                    string jsonData = File.ReadAllText(filePath);
                    return JsonConvert.DeserializeObject<List<MenuItem>>(jsonData);
                }
                return new List<MenuItem>();
            }
        }

        public static void showMenu()
        {
            var menuItems = AllMenuItems;

            if (menuItems.Any())
            {
                Console.WriteLine("Loaded Menu Items:");
                foreach (var item in menuItems.OrderBy(n => n.Category))
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("JSON file not found or empty.");
            }
        }
    }
}
