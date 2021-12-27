using System;
using System.Collections.Generic;
using System.Text;
using laba5;
using laba5.Entities;

namespace Entities
{
    public class Order
    {
        private uint Distance { get; set; }
        private uint Weight { get; set; }
        private Tariffs tariff { get; set; } = new Tariffs();

        public Order(uint distance, uint weight, TariffsEnum tariff)
        {
            Distance = distance;
            Weight = weight;
            this.tariff.Tariff = tariff;
        }

        public double GetCost()
        {
            double coaf = tariff.GetFactor();
            /*
            if (tariff.Tariff == TariffsEnum.ECONOM)
            {
                coaf = 1.0;
            } 
            else if (tariff.Tariff == TariffsEnum.STANDART)
            {
                coaf = 1.5;
            }
            else if (tariff.Tariff == TariffsEnum.PREMIUM)
            {
                coaf = 2.0;
            }
            */
            return Distance * Weight * coaf;
        }
    }
}
