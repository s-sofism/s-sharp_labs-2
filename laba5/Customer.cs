using laba5;

namespace Entities
{
    public class Customer
    {
        public uint id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public MyCustomCollection<Order> Orders { get; set; } = new MyCustomCollection<Order>();

        public Customer(uint id, string name, string surname)
        {
            Name = name;
            Surname = surname;
            this.id = id;
        }
    }
}