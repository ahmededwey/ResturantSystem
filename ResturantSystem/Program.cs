// Program.cs - Entry Point for Restaurant Order Management System
// ==============================================================

using Resturant_Project.Modules;
using ResturantSystem.Enums;
using ResturantSystem.Modules;
using System;
using System.Collections.Generic;

namespace ResturantSystem
{
    internal class Program
    {
        private static Order currentOrder;
        private static readonly OrderManager orderManager = new();
        private static readonly ReservationManager reservationManager = new();

        private static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("🍽️ Welcome to the Restaurant Order Management System\n");
                Console.WriteLine("1. 🛒 Create Order");
                Console.WriteLine("2. 💵 View Bill");
                Console.WriteLine("3. 📅 Make Reservation");
                Console.WriteLine("4. 📋 View Reservations");
                Console.WriteLine("5. ❌ Exit\n");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        CreateOrder();
                        break;
                    case "2":
                        ViewBill();
                        break;
                    case "3":
                        MakeReservation();
                        break;
                    case "4":
                        ViewReservations();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("❌ Invalid choice. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void CreateOrder()
        {
            Console.Clear();
            Console.WriteLine("📝 Creating a New Order\n");
            Console.Write("Enter customer name: ");
            var customer = new Customer { Name = Console.ReadLine() };
            var order = new Order();
            orderManager.CreateOrder(order);
            Console.WriteLine("\n✅ Order Created Successfully.");
            Console.ReadKey();
        }

        private static void ViewBill()
        {
            Console.Clear();
            Console.WriteLine("💰 Viewing Bill\n");
            if (currentOrder != null)
            {
                BillManager.PrintBill(currentOrder);
            }
            else
            {
                Console.WriteLine("⚠️ No order found. Please create an order first.");
            }
            Console.ReadKey();
        }

        private static void MakeReservation()
        {
            Console.Clear();
            reservationManager.MakeReservation();
            Console.ReadKey();
        }

        private static void ViewReservations()
        {
            Console.Clear();
            Console.WriteLine("📋 Current Reservations:\n");
           reservationManager.ViewAllReservations();

            
            
            Console.ReadKey();
        }
    }
}
