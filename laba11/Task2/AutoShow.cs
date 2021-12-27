using System;
using System.Collections.Generic;
using System.Text;

namespace Task2Space
{
    public class AutoShow
    {
        public int id { get; set; }

        public string Name { get; set; }
        public int EngineVolume { get; set; } //engine volume more then 2 liters
        public static byte StatisticInfo { get; set; }

        public AutoShow(int id, string name, int engineVolume)
        {
            this.id = id;
            Name = name;
            EngineVolume = engineVolume;

        }
        public static bool Condition(AutoShow auto)
        {
            if (auto.EngineVolume > 2)
            {
                ++StatisticInfo;
                return true;
            }
            return false;
        }
    }
}