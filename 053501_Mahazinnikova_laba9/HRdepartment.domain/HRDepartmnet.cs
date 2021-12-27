using System;

namespace HRdepartment.domain
{
    [Serializable]
    public class HRDepartment
    {
        public int id { get; set; }

        public HRDepartment() { }

        public HRDepartment(int id)
        {
            this.id = id;
        }
    }
}
