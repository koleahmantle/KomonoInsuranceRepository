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
        private List<DevTeamPOCO> _listofDevTeam = new List<DevTeamPOCO>();
        private DevTeamPOCO _devTeam = new DevTeamPOCO(); 

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

        public bool AddDevTeamMember(DeveloperPOCO teamMember)
        {
            int initialCount = _devTeam.TeamMemberList.Count;

            _devTeam.TeamMemberList.Add(teamMember);

            if (initialCount < _devTeam.TeamMemberList.Count)
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
                teamMember.TeamMemberList = newTeamMember.TeamMemberList;
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

        public DeveloperPOCO GetTeamMember(int id)
        {
            foreach (DeveloperPOCO teamMember in _devTeam.TeamMemberList)
            {
                if(teamMember.Id == id)
                {
                    return teamMember;
                }              
            }

            return null;
        }
    }
}
