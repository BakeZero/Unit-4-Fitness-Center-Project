using System.Diagnostics;

namespace Unit_4_Fitness_Center_Project
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the Fitness Center Manager!");
            MainMenu:
            DisplayProgramOptions();
            int menuPrompt = Validator.GetNumber(1, 4, "Select a number");
            switch (menuPrompt)
            {
                case 1: // Display Clubs
                {

                        goto MainMenu;
                }
                case 2: // Select Club
                {
                        goto MainMenu;
                }
                case 3: // Add Club
                {

                        

                        goto MainMenu;
                }
                case 4: // Terminate Program
                        goto EndProgram;
            }



            /* testing snippets
            do
            {
                Club club = new Club("Planet Dingus", "1234 Center Dr");
                Franchise.AddClub(club);
                Franchise.DisplayAllClubs();
                Franchise.AddMember(new MultiMember("Harry"));
                Franchise.DisplayAllMembers();
            } while (Continue("Do anything else?"));*/

            EndProgram:
            Console.WriteLine("Have a great day!");
        }

        
        static bool Continue(string msg)
        {
            Console.Write($"{msg} (y/n): ");
            string prompt = Console.ReadLine();
            if (prompt == "y")
                return true;
            else if (prompt == "n")
                return false;
            else
                return Continue(msg);
        }

        // Displays as the main menu at the beginning of the program
        static void DisplayProgramOptions()
        {
            Console.WriteLine("1. Display Clubs");
            Console.WriteLine("2. Select Club");
            Console.WriteLine("3. Add Club");
            Console.WriteLine("4. Terminate Program");
        }

        // Displays when 2. is selected from DisplayProgramOptions()
        static void DisplayClubOptions() 
        {
            Console.WriteLine("1. Display all franchise members");
            Console.WriteLine("2. Select Member");
            Console.WriteLine("3. Add new member");
            Console.WriteLine("4. Check-in member");
            Console.WriteLine("5. Return to main menu");
            Console.WriteLine("6. Terminate Program");
        }

        // Displays when 2. is selecteed from DisplayClubOptions()
        static void DisplayMemberOptions()
        {
            Console.WriteLine("1. View member details");
            Console.WriteLine("2. Generate bill");
            Console.WriteLine("3. Return to club options");
            Console.WriteLine("4. Terminate Program");
        }
    }
}