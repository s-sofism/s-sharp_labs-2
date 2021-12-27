using Entities;
using laba6.Entities;
using System;
using System.Collections.Generic;

namespace laba6
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal customerJournal = new Journal();
            Journal orderJournal = new Journal();

            CustomerList customerList = new CustomerList();
            customerList.Notify += customerJournal.RegistrationEvent;
            customerList.Notify += ev =>
                Console.WriteLine($"{ev.mess} - {ev.name}");

            //var orders = new MyCustomCollection<Order>();
            //orders.Add(new Order(100, 5, Tariffs.ECONOM));
            //orders.Add(new Order(50, 15, Tariffs.STANDART));

            var customers = new List<Customer>();
            Customer Bob = new Customer(1, "Bob", "Marley");
            Bob.Notify += orderJournal.RegistrationEvent;
            Bob.PushOrder(new Order(100, 5, Tariffs.ECONOM));
            Bob.PushOrder(new Order(50, 15, Tariffs.STANDART));
            Bob.PushOrder(new Order(37, 6, Tariffs.STANDART));
            customerList.Register(Bob);

            Customer John = new Customer(2, "John", "Travolta");
            John.Notify += orderJournal.RegistrationEvent;
            John.PushOrder(new Order(15, 12, Tariffs.PREMIUM));
            customerList.Register(John);
            customerJournal.PrintInfo();
            orderJournal.PrintInfo();

            Customer Mia = new Customer(3, "Mia", "Walles");
            Mia.Notify += orderJournal.RegistrationEvent;
            Mia.PushOrder(new Order(33, 6, Tariffs.STANDART));
            customerList.Register(Mia);
            customerList.ShowCustomers();
            customerList.ShowOrders();
            customerList.ShowCustomerOrder(1);
            customerList.ShowCustomerExactOrder(1);
            customerList.ShowTariffs();
            customerList.ShowMostPaid(300);
            customerList.ShowBigiestPaid();
        }
    }
}

