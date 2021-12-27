using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using laba6;
using laba6.Entities;

namespace Entities
{
    public class CustomerList
    {
        public delegate void OrderHandler(EventNotify e);
        public event OrderHandler Notify;

        private readonly List<Customer> Customers = new List<Customer>();

        public void Register(Customer customer)
        {
            Customers.Add(customer);
            Notify?.Invoke(new EventNotify("Added new customer", customer.Name));
        }

        public void ShowCustomers()
        {
            foreach (Customer i in Customers)
            {
                Console.WriteLine(i.Name);
            }
        }

        public void ShowOrders()
        {
            /*
            double totalCost = 0;
            foreach (Customer i in Customers)
            {
                foreach (Order u in i.Orders)
                {
                    totalCost += u.GetCost();
                }
            }
            Console.WriteLine(totalCost);
            */
            var selectedTeams = (from t in Customers
                                 from y in t.Orders
                                 select y.GetCost()).Sum();
            Console.WriteLine(selectedTeams);
        }

        public void ShowCustomerOrder(int id)
        {
            /*
            double totalCost = 0;
            foreach (Customer i in Customers)
            {
                if (i.id == id)
                {
                    foreach (Order u in i.Orders)
                    {
                        totalCost += u.GetCost();
                    }
                }
            }
            Console.WriteLine(totalCost);
            */
            var selectedTeams = (from t in Customers
                                 where t.id == id
                                 from y in t.Orders
                                 select y.GetCost()).Sum();
            Console.WriteLine(selectedTeams);
        }

        public void ShowCustomerExactOrder(int id)
        {
            var selectedTeams = from t in Customers
                                where t.id == id
                                from y in t.Orders
                                group y by y.Tariff;

            foreach (IGrouping<Tariffs, Order> g in selectedTeams.OfType<IGrouping<Tariffs, Order>>())
            {
                double total = 0;
                Console.Write($"{g.Key}: ");
                foreach (var t in g)
                {
                    Console.Write($"{t.GetCost()} ");
                    total += t.GetCost();
                }
                Console.WriteLine($"total: {total}");
                Console.WriteLine();
            }
        }

        public void ShowMostPaid(int amount)
        {
            foreach (Customer t in Customers)
            {
                List<double> ord = new List<double>();
                foreach (Order y in t.Orders)
                {
                    ord.Add(y.GetCost());
                }

                double sum = ord.Aggregate((x, y) => x + y);
                if (sum > amount)
                {
                    Console.WriteLine($"{t.Name}: {sum}");
                }
            }
        }

        public void ShowBigiestPaid()
        {
            List<double> general = new List<double>();
            foreach (Customer t in Customers)
            {
                List<double> ord = new List<double>();
                foreach (Order y in t.Orders)
                {
                    ord.Add(y.GetCost());
                }

                general.Add(ord.Aggregate((x, y) => x + y));
            }
            general.Sort();
            Console.WriteLine(general.Last());
        }

        public void ShowTariffs()
        {
            Console.WriteLine("ECONOM - coaf = 1.0,\nSTANDART - coaf = 1.5,\nPREMIUM - coaf = 2.0");
        }
    }
}