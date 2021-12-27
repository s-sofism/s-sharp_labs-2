using Entities;
using laba5.Entities;
using System;

namespace laba5
{
    static class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            var orders = new MyCustomCollection<Order>();
            orders.Add(new Order(100, 5, TariffsEnum.ECONOM));
            orders.Add(new Order(50, 15, TariffsEnum.STANDART));

            var customers = new MyCustomCollection<Customer>();
            Customer Bob = new Customer(1, "Bob", "Marley");
            Bob.Orders = orders;
            journal.Register(Bob);

            Customer John = new Customer(2, "John", "Travolta");
            John.Orders.Add(new Order(15, 12, TariffsEnum.PREMIUM));
            journal.Register(John);

            Customer Mia = new Customer(3, "Mia", "Walles");
            Mia.Orders.Add(new Order(33, 6, TariffsEnum.STANDART));
            journal.Register(Mia);

            journal.ShowCustomers();
            journal.ShowOrders();
            journal.ShowCurrentOrder(1);
        }
    }
}
