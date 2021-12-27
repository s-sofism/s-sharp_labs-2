using System;
using System.Collections.Generic;
using System.Text;

namespace laba8
{
    interface IFileService
    {
        IEnumerable<Employee> ReadFile(string fileName);
        void SaveData(IEnumerable<Employee> data, string fileName);
    }
}
