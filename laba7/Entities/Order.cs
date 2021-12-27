using System;
using System.Collections.Generic;
using laba6.Entities;
using laba6.Helper;

namespace Entities
{
    public class Order
    {
        public uint Distance { get; }
        public uint Weight { get; }
        public Tariffs Tariff { get; }

        public Order() { }

        public Order(uint distance, uint weight, Tariffs tariff)
        {
            Distance = distance;
            Weight = weight;
            Tariff = tariff;
        }

        public double GetCost()
        {
            double coaf = Factor.GetFactor(Tariff);
            return Distance * Weight * coaf;
        }
    }
}
