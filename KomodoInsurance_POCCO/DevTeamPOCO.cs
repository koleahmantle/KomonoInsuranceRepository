using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_POCCO
{
    public class DevTeamPOCO
    {
        //create properties for developer team (Developers/Team Members, Team Name, Team ID)
        public List<DeveloperPOCO> TeamMemberList { get; set; }
        public string TeamName { get; set; }
        public int TeamId { get; set; }

        //create empty constructor
        public DevTeamPOCO () { }

        //create filled constructor
        public DevTeamPOCO (string teamName, int teamId)
        {
            TeamName = teamName;
            TeamId = teamId;
        }
    }
}
