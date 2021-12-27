using System;
using System.Collections.Generic;
using System.Text;

namespace laba5.Entities
{
    class Tariffs
    {
        public TariffsEnum Tariff { get; set; }

        public double GetFactor() => Tariff switch
        {
            TariffsEnum.ECONOM => 1.0,
            TariffsEnum.STANDART => 1.5,
            TariffsEnum.PREMIUM => 2.0,
            _ => 1.0
        };
    }
}
