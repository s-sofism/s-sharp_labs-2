using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using laba5;

namespace Entities
{
    public class Journal
    {
        private readonly MyCustomCollection<Customer> Customers = new MyCustomCollection<Customer>();

        public void Register(Customer customer)
        {
            Customers.Add(customer);
        }

        public void ShowCustomers()
        {
            Customers.Reset();
            for (int i = 0; i < Customers.Count; i++)
            {
                Console.WriteLine(Customers.Current().Name);
                Customers.Next();
            }
        }

        public void ShowOrders()
        {
            double totalCost = 0;
            Customers.Reset();
            for (int i = 0; i < Customers.Count; i++)
            {
                Customers.Current().Orders.Reset();
                for (int n = 0; n < Customers.Current().Orders.Count; n++)
                {
                    totalCost += Customers.Current().Orders.Current().GetCost();
                    Customers.Current().Orders.Next();
                }
                Customers.Next();
            }
            Console.WriteLine(totalCost);
        }

        public void ShowCurrentOrder(int id)
        {
            double totalCost = 0;
            Customers.Reset();
            for (int i = 0; i < Customers.Count; i++)
            {
                if (Customers.Current().id == id) break;
                Customers.Next();
            }
            Customers.Current().Orders.Reset();
            for (int n = 0; n < Customers.Current().Orders.Count; n++)
            {
                totalCost += Customers.Current().Orders.Current().GetCost();
                Customers.Current().Orders.Next();
            }
            Console.WriteLine(totalCost);
        }
    }
}