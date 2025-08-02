using Resturant_Project.Modules;
using ResturantSystem.Modules;
using System;
using System.Collections.Generic;

namespace Resturant_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = PlaceOrder();

            var operations = new Dictionary<int, Action>
            {
                { 1, ViewMenu },
                { 2, () => PlaceOrder() },
                { 3, () => ManageOrder(order) },
                { 4, MakeReservation },
                { 5, ViewBill }
            };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("🔘 Select an option:");
                Console.WriteLine("1. View Menu");
                Console.WriteLine("2. Place Order");
                Console.WriteLine("3. Manage Order");
                Console.WriteLine("4. Make Reservation");
                Console.WriteLine("5. View Bill");
                Console.WriteLine("0. Exit");

                Console.Write("\nYour choice: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice == 0)
                        break;

                    if (operations.TryGetValue(choice, out var operation))
                    {
                        operation.Invoke(); // Run the function dynamically
                    }
                    else
                    {
                        Console.WriteLine("❌ Invalid choice. Try again.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("❌ Please enter a valid number.");
                    Console.ReadKey();
                }
            }
        }

        static void ViewMenu()
        {
            Console.WriteLine("🧾 Viewing Menu...");
            Menu.showMenu();
            Console.ReadKey();
        }

        static Order PlaceOrder()
        {
            Console.WriteLine("🛒 Placing Order...");
            var order = new Order();
            order.SetOrder();
            Console.ReadKey();
            return order;
        }

        static void MakeReservation()
        {
            var manager = new ReservationManager();
            // Add reservation logic here
            manager.MakeReservation();
            manager.ViewAllReservations();
            Console.ReadLine();
        }

        static void ViewBill()
        {
            Console.WriteLine("💰 Viewing Bill...");
            // Add billing logic here
            Console.ReadKey();
        }

        static void ManageOrder(Order o)
        {
            Console.Clear();
            Console.WriteLine("⚙️ Manage Order Options:");

            var orderManager = new OrderManager();

            var operations = new Dictionary<int, (string Description, Action Action)>
    {
        { 1, ("Create Order", () => orderManager.CreateOrder(o.Items)) },
        { 2, ("Cancel Order", () => orderManager.CancelOrder(o.OrderId)) },
        { 3, ("Add Item To Order", () => orderManager.AddItemToOrder(o.OrderId, new MenuItem(), 1)) },
        { 4, ("Remove Item From Order", () => orderManager.RemoveItemFromOrder(o.OrderId, new MenuItem { Id = 4 })) }
    };

            while (true)
            {
                Console.WriteLine("\nSelect an operation to perform:");
                foreach (var op in operations)
                {
                    Console.WriteLine($"{op.Key}. {op.Value.Description}");
                }
                Console.WriteLine("0. Return to main menu");

                Console.Write("\nYour choice: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice == 0)
                        break;

                    if (operations.TryGetValue(choice, out var selectedOp))
                    {
                        Console.WriteLine($"\n🔧 Running: {selectedOp.Description}");
                        selectedOp.Action.Invoke();
                    }
                    else
                    {
                        Console.WriteLine("❌ Invalid choice. Try again.");
                    }
                }
                else
                {
                    Console.WriteLine("❌ Please enter a valid number.");
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

    }
}
