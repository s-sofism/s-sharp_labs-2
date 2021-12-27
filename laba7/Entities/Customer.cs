using laba6;
using System.Collections.Generic;

namespace Entities
{
    public class Customer
    {
        public delegate void OrderHandler(EventNotify e);
        public event OrderHandler Notify;

        public uint id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();

        public Customer(uint id, string name, string surname)
        {
            Name = name;
            Surname = surname;
            this.id = id;
        }

        public void PushOrder(Order order)
        {
            Orders.Add(order);
            Notify?.Invoke(new EventNotify("Pushed order", order.Tariff.ToString()));
        }
    }
}