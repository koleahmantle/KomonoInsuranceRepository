using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_POCCO
{
    public class DeveloperPOCO
    {
        //create properties for developer (member name, member ID, access to Pluralsight)
        public string DeveloperName { get; set; }
        public int Id { get; set; }
        public bool HasPluralSightAccess { get; set; }

        //create empty constructor
        public DeveloperPOCO () { }

        //create filled constructor
        public DeveloperPOCO (string developerName, int id, bool hasPluralSightAccess)
        {
            DeveloperName = developerName;
            Id = id;
            HasPluralSightAccess = hasPluralSightAccess;
        }
    }
}
