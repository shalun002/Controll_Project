using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Modules
{
    public class Employees
    {
        private string _Name;

        public string Name { get => _Name; set => _Name = value.Replace("<center><b><font size=7>", "").Replace("</font></b></center>", "").Replace("\n", ""); }
        public string OrganizationName { get; set; }
        public string DepartmensName { get; set; }
    }
}
