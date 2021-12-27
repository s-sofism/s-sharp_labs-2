using System;
using System.Collections.Generic;
using System.Text;
using laba6;

namespace Entities
{
    public class Journal
    {
        public Journal() { }

        readonly List<EventNotify> ListEvents = new List<EventNotify>();

        public void RegistrationEvent(EventNotify e)
        {
            ListEvents.Add(e);
        }

        public void PrintInfo()
        {
            for (int i = 0; i < ListEvents.Count; i++)
            {
                Console.WriteLine("\nEvent description:");
                Console.WriteLine(ListEvents[i].mess);
                Console.WriteLine(ListEvents[i].name);
            }
        }
    }
}