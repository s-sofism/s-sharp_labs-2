namespace Entities
{
    public class EventNotify
    {
        public string name { get; }
        public string mess { get; }
        public EventNotify(string _mess, string _name)
        {
            mess = _mess;
            name = _name;
        }
    }
}
