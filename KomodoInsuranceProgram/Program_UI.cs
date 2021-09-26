using KomodoInsurance_POCCO;
using KomodoInsurance_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceProgram
{
    class Program_UI
    {
        private DeveloperRepo _developerRepo = new DeveloperRepo();
        public void Run()
        {
           // SeedContentList();
            MainMenu();
        }

        public void DeveloperChoiceMethod()
        {
            Console.Clear();
            bool run = true;
            while (run)
            {
                Console.Clear();
                Console.WriteLine("Please select an option from the menu below\n" +
                    "1: Add a new developer\n" +
                    "2. View all Developers\n" +
                    "3. View developers without access to Plural Sight\n" +
                    "4. Update Existing Developer\n" +
                    "5. Delete Existing Developer\n" +
                    "6. Go back to main menu\n" +
                    "7. Exit the program");

                string devMenuChoice = Console.ReadLine();

                switch (devMenuChoice)
                {
                    case "1":
                        //Add a new developer                     
                        CreateNewDeveloper();
                        break;
                    case "2":
                        //Display all developers
                        DisplayAllDevelopers();
                        break;
                    case "3":
                        //Display developers without plural sight access
                        DisplayDevelopersWithoutPluralsight();
                        break;
                    case "4":
                        //Update existing
                        UpdateExistingDeveloper();
                        break;
                    case "5":
                        //Delete existing 
                        DeleteExistingDeveloper();
                        break;
                    case "6":
                        //Go Back to main menu
                        MainMenu();
                        break;
                    case "7":
                        //Exit the program
                        Console.WriteLine("Goodbye!");                        
                        break;
                    default:
                        Console.WriteLine("Invalid option, please select option 1-7.");
                        break;

                }
                Console.WriteLine("Press Any key to continue...");
                Console.ReadKey();
            }
           
        }

        public void DevTeamChoiceMethod()
        {
            Console.WriteLine("Please select an option from the menu below\n" +
                "1: Add a new team memeber\n" +
                "2. View all team members\n" +
                "3. Update Existing Team Member\n" +
                "4. Delete Existing Team Member\n" +
                "5. Exit");

            string devMenuChoice = Console.ReadLine();

            switch (devMenuChoice)
            {
                case "1":
                    //Add a new developer
                    CreateNewTeamMember();
                    break;
                case "2":
                    //Display all developers
                    DisplayAllTeamMembers();
                    break;      
                case "3":
                    //Update existing
                    UpdateExistingTeamMember();
                    break;
                case "4":
                    //Delete existing 
                    DeleteTeamMember();
                    break;
                case "5":
                    //Exit the program
                    Console.WriteLine("Goodbye");
                    break;
                default:
                    Console.WriteLine("Invalid option, please select option 1-6.");
                    break;
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        public void MainMenu()
        {
                //Display Menu
                Console.WriteLine("Please select the group you would like to see: \n" +
                    "1: Developer Group\n" +
                    "2. Developer Team Group");

                //Get user's input
                string mainMenuChoice = Console.ReadLine();

                //Eval input accordingly
                switch (mainMenuChoice)
                {
                    case "1":
                        DeveloperChoiceMethod();
                        break;
                    case "2":
                        DevTeamChoiceMethod();
                        break;
                }           
        }

        private void CreateNewDeveloper()
        {
            Console.Clear();
            DeveloperPOCO newDeveloper = new DeveloperPOCO();

            //Name
            Console.WriteLine("Enter name for developer");
            newDeveloper.DeveloperName = Console.ReadLine();

            //Id
            Console.WriteLine("Enter ID for developer");
            newDeveloper.Id = int.Parse(Console.ReadLine());

            //HasPluralAccess
            Console.WriteLine("Does this developer have access to Plural Sight? True/False");
           newDeveloper.HasPluralSightAccess = bool.Parse(Console.ReadLine());

            _developerRepo.AddContentToList(newDeveloper);
        }

        private void DisplayAllDevelopers()
        {
            Console.Clear();

            List<DeveloperPOCO> listOFDevelopers = _developerRepo.GetDeveloperFromList();
            Console.WriteLine(listOFDevelopers);

            //foreach (DeveloperPOCO developer in listOFDevelopers)
            //{
            //    Console.WriteLine($"Name: {developer.DeveloperName}\n" +
            //        $"ID: {developer.Id}\n" +
            //        $"Access to Plural Sight: {developer.HasPluralSightAccess}");
            //    Console.ReadLine();
            //}  
        }

        private void DisplayDevelopersWithoutPluralsight()
        {
            Console.Clear();
            
            //
        }

        private void UpdateExistingDeveloper()
        { 
         
        }

        private void DeleteExistingDeveloper()
        {
            DisplayAllDevelopers();

            // Get ID that needs deleted
            Console.WriteLine("Enter the ID of the user you'd like to remove: ");
            int id = int.Parse(Console.ReadLine());

            //Call the delete method
            bool wasDeleted = _developerRepo.RemoveContentFromList(id);

            //IF the content was deleted say so, otherwise say it can't be deleted
            if (wasDeleted)
            {
                Console.WriteLine("The developer was deleted.");
            }
            else
            {
                Console.WriteLine("Developer could not be deleted.");
            }
        }

        private void CreateNewTeamMember()
        {
            Console.Clear();
            DevTeamPOCO newTeamMember = new DevTeamPOCO();


            //Team Name
            Console.WriteLine("");

            //Team ID

        }

        private void DisplayAllTeamMembers()
        {

        }

        private void UpdateExistingTeamMember()
        {

        }

        private void DeleteTeamMember()
        {

        }

        //See Method
        private void SeedContentList()
        {
            DeveloperPOCO dev1 = new DeveloperPOCO("Sam smith", 1, true);
            DeveloperPOCO dev2 = new DeveloperPOCO("Jason Bourne", 2, false);
            DeveloperPOCO dev3 = new DeveloperPOCO("Sara Fuller", 3, false);
            DeveloperPOCO dev4 = new DeveloperPOCO("Mark Johnson", 4, true);
            DeveloperPOCO dev5 = new DeveloperPOCO("Ida Wilson", 5, false);

            _developerRepo.AddContentToList(dev1);
            _developerRepo.AddContentToList(dev2);
            _developerRepo.AddContentToList(dev3);
            _developerRepo.AddContentToList(dev4);
            _developerRepo.AddContentToList(dev5);
        }
    }
}
