using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantSystem.Modules
{
    public class BillManager
    {
        private const double TaxRate = 0.14; // 14% VAT
        private const double DiscountThreshold = 300.0; // Discount for orders >= 300
        private const double DiscountRate = 0.10; // 10%

        public static double CalculateSubtotal(Dictionary<MenuItem, int> items)
        {
            return items.Sum(item => item.Key.Price * item.Value);
        }

        public static double CalculateTax(double subtotal)
        {
            return subtotal * TaxRate;
        }

        public static double CalculateDiscount(double subtotal)
        {
            return subtotal >= DiscountThreshold ? subtotal * DiscountRate : 0;
        }

        public static double CalculateTotal(double subtotal, double tax, double discount)
        {
            return subtotal + tax - discount;
        }

        public static void PrintBill(Order order)
        {
            var subtotal = CalculateSubtotal(order.Items);
            var tax = CalculateTax(subtotal);
            var discount = CalculateDiscount(subtotal);
            var total = CalculateTotal(subtotal, tax, discount);

            Console.WriteLine("\n🧾 BILL DETAILS:");
            Console.WriteLine($"Order ID: {order.OrderId}");
            foreach (var item in order.Items)
            {
                Console.WriteLine($"- {item.Key.Title} x{item.Value} = {item.Key.Price * item.Value:C2}");
            }
            Console.WriteLine($"Subtotal: {subtotal:C2}");
            Console.WriteLine($"Tax (14%): {tax:C2}");
            Console.WriteLine($"Discount: -{discount:C2}");
            Console.WriteLine($"Total: {total:C2}");
        }
    }
}

