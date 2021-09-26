using KomodoInsurance_POCCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Repo
{
    public class DeveloperRepo
    {
        //create private list of Developers
        private List<DeveloperPOCO> _listOfDevelopers = new List<DeveloperPOCO>();

        //Create
        public bool AddContentToList(DeveloperPOCO developer)
        {
            int initialCount = _listOfDevelopers.Count;
            _listOfDevelopers.Add(developer);

            if (initialCount < _listOfDevelopers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Read
        public List<DeveloperPOCO> GetDeveloperFromList()
        {
            return _listOfDevelopers;
        }

        //Update
        public bool UpdateExistingDeveloper(int id, DeveloperPOCO newDeveloper)
        {
            //Find Content
            DeveloperPOCO developer = GetDeveloperById(id);

            //Update Content
            if (developer == null)
            {
                return false; 
            }
            else
            {
                developer.DeveloperName = newDeveloper.DeveloperName;
                developer.Id = newDeveloper.Id;
                developer.HasPluralSightAccess = newDeveloper.HasPluralSightAccess;
                return true;
            }
        }

        //Delete
        public bool RemoveContentFromList(int id)
        {
            DeveloperPOCO developer = GetDeveloperById(id);

            if( developer == null)
            {
                return false;
            }

            int initialCount = _listOfDevelopers.Count;
            _listOfDevelopers.Remove(developer);

            if(initialCount > _listOfDevelopers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //helper method
        public DeveloperPOCO GetDeveloperById(int id)
        {
            foreach (DeveloperPOCO developer in _listOfDevelopers)
            {
                if (developer.Id == id)
                {
                    return developer;
                }
            }

            return null;
        }


    }
}
