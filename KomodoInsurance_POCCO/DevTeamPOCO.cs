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
        public string TeamMemberName { get; set; }
        public string TeamName { get; set; }
        public int TeamId { get; set; }

        //create empty constructor
        public DevTeamPOCO () { }

        //create filled constructor
        public DevTeamPOCO (string teamMemberName, string teamName, int teamId)
        {
            TeamMemberName = teamMemberName;
            TeamName = teamName;
            TeamId = teamId;
        }
    }
}
