using ResturantSystem.Enums;
using ResturantSystem.Modules;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ResturantSystem.Modules
{
    public class OrderManager
    {
        private List<Order> orders;
        private int nextOrderId;

        public OrderManager()
        {
            orders = new List<Order>();
            nextOrderId = 1;
        }

        // Create new order with items and assign unique ID
        public Order CreateOrder(Dictionary<MenuItem, int> items)
        {
            var order = new Order(nextOrderId++, items);
            orders.Add(order);
            return order;
        }

        // Add or update item quantity in an existing order
        public void AddItemToOrder(int orderId, MenuItem item, int quantity)
        {
            var order = FindOrderById(orderId);
            if (order != null && quantity > 0)
            {
                if (order.Items.ContainsKey(item))
                    order.Items[item] += quantity;
                else
                    order.Items.Add(item, quantity);
            }
        }

        // Remove an item from the order
        public void RemoveItemFromOrder(int orderId, MenuItem item)
        {
            var order = FindOrderById(orderId);
            if (order != null && order.Items.ContainsKey(item))
            {
                order.Items.Remove(item);
            }
        }

        // Update the status of an order
        public void UpdateOrderStatus(int orderId, OrderStatus status)
        {
            var order = FindOrderById(orderId);
            if (order != null)
            {
                order.OrderStatus = status;
            }
        }

        // Cancel order by clearing items and changing status
        public void CancelOrder(int orderId)
        {
            var order = FindOrderById(orderId);
            if (order != null)
            {
                order.CancelOrder();
            }
        }

        // Get order by ID
        public Order GetOrderDetails(int orderId)
        {
            return FindOrderById(orderId);
        }

        // List all existing orders
        public List<Order> ListAllOrders()
        {
            return new List<Order>(orders);
        }

        // Helper method to find order
        private Order FindOrderById(int orderId)
        {
            return orders.FirstOrDefault(o => o.OrderId == orderId);
        }
    }
}
