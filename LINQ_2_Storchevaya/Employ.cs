using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_2_Storchevaya
{
    public class Employ
    {
        public string Name { get; set; }
        public string Department { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Department}";
        }
    }
}
