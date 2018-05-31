using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Modules
{
    public class Employees
    {
        private string _Person;

        public string Person { get => _Person; set => _Person = value.Replace("<center><b><font size=7>", "").Replace("</font></b></center>", "").Replace("\n", ""); }


    }
}
