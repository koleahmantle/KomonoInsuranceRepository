using KomodoInsurance_POCCO;
using KomodoInsurance_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceProgram
{
    class Program_UI2
    {
        private DeveloperRepo _developerRepo = new DeveloperRepo();
        private DevTeamRepo _devTeamRepo = new DevTeamRepo();
        List<DeveloperPOCO> teamMemberName = new List<DeveloperPOCO>();

        // Method that starts the application
        public void Run()
        {
            SeedContentList();
            MainMenu();
        }
        public void DeveloperChoice()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();

                // Display options to user
                Console.WriteLine("Select a menu option\n" +
                "1. Add a new developer\n" +
                "2. View all developers\n" +
                "3. Update existing developers\n" +
                "4. Delete esisting developers\n" +
                "5. View developers without Access to Pluralsight\n" +
                "6. Back to Main Menu\n" +
                "7. Exit the program");
                // Get user input
                string developerChoice = Console.ReadLine();
                // Evaluate user input
                switch (developerChoice)
                {
                    case "1":
                        // Add new developer
                        CreateNewDeveloper();
                        break;
                    case "2":
                        // See all developers
                        DisplayAllDevelopers();
                        break;
                    case "3":
                        // Update developers
                        UpdateExistingDeveloper();
                        break;
                    case "4":
                        //Delete developers
                        DeleteExistingDeveloper();
                        break;
                    case "5":
                        //View developers without Access to PluralSight
                        NeedPluralsightAccess();
                        break;
                    case "6":
                        //Back to main menu
                        MainMenu();
                        break;
                    case "7":
                        //Exit
                        Console.WriteLine("Goodbye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine("Please press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void DevTeamChoice()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display options to user
                Console.WriteLine("Select a menu option\n" +
                    "1. Add new Team Member\n" +
                    "2. See all Team Member\n" +
                    "3. Update Team Member\n" +
                    "4. Delete Team Member\n" +
                    "5. Back to Main Memu" +
                    "6. Exit");
                // Get user input
                string devTeamChoice = Console.ReadLine();
                // Evaluate user input
                switch (devTeamChoice)
                {
                    case "1":
                        // Add new Team Member
                        CreateNewTeamMember();
                        break;
                    case "2":
                        // See all Team  Member
                        DisplayAllTeamMembers();
                        break;
                    case "3":
                        // Update Team  Member
                        UpdateExistingMembers();
                        break;
                    case "4":
                        //Delete Team  Member
                        DeleteExistingMember();
                        break;
                    case "5":
                        //Back to main menu
                        MainMenu();
                        keepRunning = false;
                        break;
                    case "6":
                        //Exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number, 1-6");
                        break;
                }
                Console.WriteLine("Please press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose which group you would like to work in\n" +
                "1. Developer\n" +
                "2. Developer Team\n" +
                "3.Exit");
            string menuChoice = Console.ReadLine();
            switch (menuChoice)
            {
                case "1":
                    DeveloperChoice();
                    break;
                case "2":
                    DevTeamChoice();
                    break;
                case "3":
                    Console.WriteLine("Goodbye");
                    break;
            }
            Console.WriteLine("Please press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        private void Create()
        {
            DeveloperPOCO newDeveloper = new DeveloperPOCO();
            DevTeamPOCO newTeamMember = new DevTeamPOCO();

            bool running = true;
           do
            {
                Console.WriteLine("Do you want to\n" +
                    "1. create a new developer\n" +
                    "2. add a team member?" +
                    "3. Exit");
                string input = Console.ReadLine();

                
                switch (input)
                {
                    case "1":
                        CreateNewDeveloper();
                        break;
                    case "2":
                        CreateNewTeamMember();
                        break;
                    case "3":
                        running = false;
                        break;

                }
            } while (running);
            _devTeamRepo.AddDevTeamMember(newDeveloper);
            _devTeamRepo.AddDevTeamToList(newTeamMember);
        }
        private void CreateNewDeveloper()
        {
            Console.Clear();

            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();

                DeveloperPOCO newDeveloper = new DeveloperPOCO();
                // Name
                Console.WriteLine("Enter name for the developer");
                newDeveloper.DeveloperName = Console.ReadLine();
                // Id
                Console.WriteLine("Enter Id");
                newDeveloper.Id = int.Parse(Console.ReadLine());
                //Have PluralSight access
                Console.WriteLine("Does developer have access to Pluralsight? true/false");
                newDeveloper.HasPluralSightAccess = bool.Parse(Console.ReadLine());
                _developerRepo.AddContentToList(newDeveloper);

                Console.WriteLine("Would you like to add another developer? y/n");
                char userInput = char.Parse(Console.ReadLine());

                if(userInput == 'n') 
                {
                    keepRunning = false;
                }
                
            }
        }
        private void CreateNewTeamMember()
        {
            Console.Clear();

            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();         
                DevTeamPOCO newTeamMember = new DevTeamPOCO();
                // Name
                Console.WriteLine("Enter name for the team member");
               //newTeamMember.TeamMemberList = Console.ReadLine();
               

                //Id
                Console.WriteLine("Enter Team Name");
                newTeamMember.TeamName = Console.ReadLine();

                //Team ID
                Console.WriteLine("Enter Team ID");
                newTeamMember.TeamId = int.Parse(Console.ReadLine());
                _devTeamRepo.AddDevTeamToList(newTeamMember);

                Console.WriteLine("Would you like to add another developer? y/n");
                char userInput = char.Parse(Console.ReadLine());

                if (userInput == 'n')
                {
                    keepRunning = false;
                }
            } 
        }
        private void DisplayAllDevelopers()
        {
            Console.Clear();
            List<DeveloperPOCO> listOfDevelopers = _developerRepo.GetDeveloperFromList();
            
            foreach (DeveloperPOCO developer in listOfDevelopers)
            {
                Console.WriteLine($"Name: {developer.DeveloperName}\n" +
                    $"ID: {developer.Id}\n" +
                    $"Pluralsight Access: {developer.HasPluralSightAccess}\n");
            }

        }
        private void DisplayAllTeamMembers()
        {
            Console.Clear();
            List<DevTeamPOCO> listOfTeamMembers = _devTeamRepo.GetTeamMeberFromList();

            foreach (DevTeamPOCO teamMember in listOfTeamMembers)
            {
                Console.WriteLine($"Member Name: {teamMember.TeamMemberList}\n" +
                    $"Team Name: {teamMember.TeamName}\n" +
                    $"Team ID: {teamMember.TeamId}\n");
            }
        }
        private void UpdateExistingDeveloper()
        {
            // Display all developers
            DisplayAllDevelopers();

            //Ask for ID to update
            Console.WriteLine("Ever the ID of the developer you'd like to update: ");

            //Get that id
            int id = int.Parse(Console.ReadLine());

            //build a new object - asking for same info in create method
            DeveloperPOCO newDeveloper = new DeveloperPOCO();
            // Name
            Console.WriteLine("Enter name for the developer");
            newDeveloper.DeveloperName = Console.ReadLine();
            // Id
            Console.WriteLine("Enter Id");
            newDeveloper.Id = int.Parse(Console.ReadLine());
            //Have PluralSight access
            Console.WriteLine("Does developer have access to Pluralsight? true/false");
            newDeveloper.HasPluralSightAccess = bool.Parse(Console.ReadLine());

            //verify update completed
            bool wasUpdated =_developerRepo.UpdateExistingDeveloper(id, newDeveloper);

            if (wasUpdated == true)
            {
                Console.WriteLine("The developer was updated.");
            }
            else
            {
                Console.WriteLine("Unable to update developer.");
            }
        }
        private void UpdateExistingMembers()
        {
            // Display all member
            DisplayAllTeamMembers();

            //Ask for ID to update
            Console.WriteLine("Ever the ID of the team member you'd like to update: ");

            //Get that id
            int id = int.Parse(Console.ReadLine());

            //build a new object - asking for same info in create method
            DevTeamPOCO newTeamMember = new DevTeamPOCO();
            // Name
            Console.WriteLine("Enter name for the team member");
            //newTeamMember.TeamMemberList.Add("literal");

            //Team Name
            Console.WriteLine("Enter Team Name");
            newTeamMember.TeamName = Console.ReadLine();

            //Team ID
            Console.WriteLine("Enter Team ID");
            newTeamMember.TeamId = int.Parse(Console.ReadLine());
            _devTeamRepo.AddDevTeamToList(newTeamMember);

            //verify update completed
            bool wasUpdated = _devTeamRepo.UpdatedExistingTeamMember(id, newTeamMember);

            if (wasUpdated == true)
            {
                Console.WriteLine("The developer was updated.");
            }
            else
            {
                Console.WriteLine("Unable to update developer.");
            }
        }
        private void DeleteExistingDeveloper()
        {
            DisplayAllDevelopers();
                        
            //Get ID that needs to be deleted
            Console.WriteLine("Enter the ID of the developer you'd like to remove: ");
            int id = int.Parse(Console.ReadLine());

            //call the delete method
            bool wasDeleted = _developerRepo.RemoveContentFromList(id);

            //If the content was delete say it has been otherwise state it hasn't 
            if(wasDeleted == true)
            {
                Console.WriteLine("Developer successfully removed.");
            }
            else
            {
                Console.WriteLine("Unable to remove developer.");
            }
        }
        private void DeleteExistingMember()
        {
            DisplayAllTeamMembers();

            //Get ID that needs to be deleted
            Console.WriteLine("Enter the ID of the team member you'd like to remove: ");
            int id = int.Parse(Console.ReadLine());

            //call the delete method
            bool wasDeleted = _devTeamRepo.DeleteTeamMemberFromList(id);

            //If the content was delete say it has been otherwise state it hasn't 
            if (wasDeleted == true)
            {
                Console.WriteLine("Member successfully removed.");
            }
            else
            {
                Console.WriteLine("Unable to remove Member.");
            }
        }
        private void NeedPluralsightAccess()
        {
            Console.Clear();

            Console.WriteLine("Below is the list of developers that don't have acess to Pluralsight");

            List<DeveloperPOCO> listOfDevelopers = _developerRepo.GetDeveloperFromList();

            foreach (DeveloperPOCO developer in listOfDevelopers)
            {
                if (developer.HasPluralSightAccess == false)
                {
                    Console.WriteLine(developer.DeveloperName);
                }
            }
        }
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

        //private void SeedContentList2()
        //{
        //    DevTeamPOCO mem1 = new DevTeamPOCO("Jason Jackson", "winner", 12);
        //    DevTeamPOCO mem2 = new DevTeamPOCO("sharon smith", "winner", 12);
        //    DevTeamPOCO mem3 = new DevTeamPOCO("Janet somer", "winner", 12);

        //    _devTeamRepo.DeleteTeamMemberFromList(mem1);
        //    _devTeamRepo.DeleteTeamMemberFromList(mem2);
        //    _devTeamRepo.DeleteTeamMemberFromList(mem3);
        //}
    }
}

