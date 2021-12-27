using System;
using System.Collections.Generic;
using System.Text;

namespace HRdepartment.domain
{
    [Serializable]
    public class Firm
    {
        public List<HRDepartment> hrdepartment;
        public string Name { get; set; }

        public Firm() { }

        public Firm(string name, List<HRDepartment> a)
        {
            Name = name;
            hrdepartment = a;
        }

        public Firm(string name)
        {
            Name = name;
            hrdepartment = new List<HRDepartment>();
        }
    }
}
