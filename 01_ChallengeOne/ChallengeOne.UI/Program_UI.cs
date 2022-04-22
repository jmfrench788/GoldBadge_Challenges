using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class Program_UI
    {
        private readonly Menu_Repository _mRepo = new Menu_Repository();
        public void Run()
        {
            SeedData();
            RunApplication();
        }
        private void RunApplication()
        {
            bool isRunning = true;
            while(isRunning)
            {
                Console.Clear();
                System.Console.WriteLine("===Komodo Cafe Menu===");
                System.Console.WriteLine("Please make a selection.");
                System.Console.WriteLine("1. View All Menu Items");
                System.Console.WriteLine("2. Add an Item to the Menu");
                System.Console.WriteLine("3. Delete an Item From the Menu");
                System.Console.WriteLine("0. Exit the application.");

                var userInput = Console.ReadLine();

                switch(userInput)
                {
                    case "1":
                    ViewAllItems();
                    break;

                    case "2":
                    AddAnItem();
                    break;

                    case "3":
                    DeleteAnItem();
                    break;

                    case "0":
                    isRunning = CloseApplication();
                    break;

                    default:
                    System.Console.WriteLine("Invalid Input");
                    PressAnyKeyToContinue();
                    break;
                }
            }
        }
        private void DeleteAnItem()
        {
            Console.Clear();
            System.Console.WriteLine("=== Delete an Item ===");

            var menuItems = _mRepo.GetAllMenuItems();
            foreach(Menu item in menuItems)
            {
                DisplayItemInformation(item);
            }

            try
            {
                System.Console.WriteLine("Please select an item by its ID.");
                var userInputSelectedItem = int.Parse(Console.ReadLine());
                bool isSuccessful = _mRepo.RemoveFromMenu(userInputSelectedItem);

                if(isSuccessful)
                {
                    System.Console.WriteLine("   " );
                    System.Console.WriteLine($"The item was deleted from the menu.");
                }
                else
                {
                    System.Console.WriteLine("       ");
                    System.Console.WriteLine("The item failed to be deleted.");
                }
            }
            catch
            {
                System.Console.WriteLine("Sorry, invalid selection.");
            }
        }
        private void AddAnItem()
        {
            Console.Clear();
            var newItem = new Menu();

            System.Console.WriteLine("=== Add an Item ===");

            System.Console.WriteLine("Please enter the name of the item.");
            newItem.Name = Console.ReadLine();

            System.Console.WriteLine("Please enter the price.");
            newItem.Price = Double.Parse(Console.ReadLine());

            System.Console.WriteLine("Please enter the item's description.");
            newItem.Description = Console.ReadLine();

            System.Console.WriteLine("Please enter the ingredients (all on one line.)");
            newItem.Ingredients = Console.ReadLine();

            bool isSuccessful = _mRepo.AddToMenu(newItem);
            if(isSuccessful)
            {
                System.Console.WriteLine("      ");
                System.Console.WriteLine($"{newItem.Name} has been added to the menu.");
            }
            else
            {
                System.Console.WriteLine("Item failed to be added to the menu.");
            }

            PressAnyKeyToContinue();
        }
        private void ViewAllItems()
        {
            Console.Clear();
            List<Menu> itemsInMenu = _mRepo.GetAllMenuItems();

            if(itemsInMenu.Count > 0)
            {
                foreach(Menu item in itemsInMenu)
                {
                    DisplayItemInformation(item);
                }
            }
            else
            {
                System.Console.WriteLine("There are no items in the menu.");
            }
            PressAnyKeyToContinue();
        }
        private void DisplayItemInformation(Menu item)
        {
            System.Console.WriteLine($"Item ID: {item.ID}\n"+
            $"Item: {item.Name}\n" +
            $"Price: {item.Price}\n" +
            $"Description: {item.Description}\n" +
            $"Ingredients: {item.Ingredients}\n"
            );
        }
        private bool CloseApplication()
        {
            Console.Clear();
            System.Console.WriteLine("Thanks!!!");
            PressAnyKeyToContinue();
            return false;
        }
        private void PressAnyKeyToContinue()
        {
            System.Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        private void SeedData()
    {
      

        var burger = new Menu("Burger", 4.99, "The classic hamburger.", "tomato, ketchup, hamburger, lettuce, and cheese.");

        var macNCheese = new Menu("Mac & Cheese", 2.99, "Noodles and cheese, everyone's favorite.", "penne noodles and cheese");
        
        var ceasarSalad = new Menu("Ceasar Salad", 3.59, "Classic Ceasar with housemade dressing", "ceasar dressing, iceburg lettuce, cheese, and cherry tomatos.");

        _mRepo.AddToMenu(burger);
        _mRepo.AddToMenu(macNCheese);
        _mRepo.AddToMenu(ceasarSalad);

    }
}
