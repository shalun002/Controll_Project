using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organization.Modules
{
    public enum OrganizationName { Sulpak, Mechta, TehnoDom, Alser, Eldorado}

    public class Organization
    {
        public OrganizationName OrgName {get; set;}
        public string TelefonNumber { get; set; }
        public string AddressOrganization { get; set; }
    }
}
