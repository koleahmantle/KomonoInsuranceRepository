using KomodoInsurance_POCCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Repo
{
   public class DevTeamRepo
    {
        //create list of DevTeam.
        private List<DevTeamPOCO> _listofDevTeam = new List<DevTeamPOCO>() ;

        //Create
        public bool AddDevTeamToList(DevTeamPOCO teamMember)
        {
            int initialCount = _listofDevTeam.Count;
            _listofDevTeam.Add(teamMember);

            if (initialCount > _listofDevTeam.Count)
            {
                return true;
            }

            return false;
        }

        //Read
        public List<DevTeamPOCO> GetTeamMeberFromList()
        {
            return _listofDevTeam;
        }


        //Update
        public bool UpdatedExistingTeamMember (int id, DevTeamPOCO newTeamMember)
        {
            //find the content
            DevTeamPOCO teamMember = GetDevTeamById(id);
            
            //update the content
            if(teamMember == null)
            {
                return false;
            }
            else
            {
                teamMember.TeamMemberName = newTeamMember.TeamMemberName;
                teamMember.TeamName = newTeamMember.TeamName;
                teamMember.TeamId = newTeamMember.TeamId;
                return true;
            }
        }

        //Delete
        public bool DeleteTeamMemberFromList(int id)
        {
           //find content
            DevTeamPOCO teamMember = GetDevTeamById(id);

            //delete content
            if (teamMember == null)
            {
                return false;
            }

            int initialCount = _listofDevTeam.Count;
            _listofDevTeam.Remove(teamMember);

            if (initialCount > _listofDevTeam.Count)
            {
                return true;
            }

            return false;
        }

        //helper Method
        public DevTeamPOCO GetDevTeamById(int teamId)
        {
            foreach(DevTeamPOCO teamMember in _listofDevTeam)
            {
                if (teamMember.TeamId == teamId)
                {
                    return teamMember;
                }
            }

            return null;
        }
    }
}
