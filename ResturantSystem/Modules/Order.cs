


using Resturant_Project.Modules;
using ResturantSystem.Enums;

namespace ResturantSystem.Modules
{
    public class Order
    {
        public int OrderId { get; set; }

        // Dictionary to hold each MenuItem and its quantity
        public Dictionary<MenuItem, int> Items { get; set; }

        public OrderStatus OrderStatus { get; set; } // Fixed naming rule violation (IDE1006)

        // Default Constructor
        public Order()
        {
            OrderId = 0;
            Items = new Dictionary<MenuItem, int>();
            OrderStatus = OrderStatus.Pending;
        }

        // Parameterized Constructor
        public Order(int orderId, Dictionary<MenuItem, int>? items)
        {
            OrderId = orderId;
            Items = items ?? new Dictionary<MenuItem, int>();
            OrderStatus = OrderStatus.Pending;
        }

        // Copy Constructor
        public Order(Order order)
        {
            OrderId = order.OrderId;
            Items = new Dictionary<MenuItem, int>(order.Items);
            OrderStatus = order.OrderStatus;
        }

        // Collect Order from user
      

       
        public void CancelOrder()
        {
            OrderStatus = OrderStatus.Cancelled;
            Items?.Clear();
        }

        // Display the order
        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine($"Order ID: {OrderId}");
            sb.AppendLine($"Status: {OrderStatus}");

            if (Items == null || Items.Count == 0)
            {
                sb.AppendLine("No items in this order.");
            }
            else
            {
                sb.AppendLine("Items:");
                foreach (var kvp in Items)
                {
                    var item = kvp.Key;
                    int quantity = kvp.Value;
                    sb.AppendLine($"- {item.Title} ({item.ItemSize}) x{quantity} - ${item.Price * quantity:F2}");
                }
            }

            return sb.ToString();
        }
    }
}
