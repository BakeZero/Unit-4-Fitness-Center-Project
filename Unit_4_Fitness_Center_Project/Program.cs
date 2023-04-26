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
            Console.WriteLine();
            int menuPrompt = Validator.GetNumber(1, 4, "Select an option");
            switch (menuPrompt)
            {
                case 1: // Display Clubs
                {
                        Franchise.DisplayAllClubs();
                        Console.WriteLine();
                        goto MainMenu;
                }
                case 2: // Select Club
                {
                        Console.Write("Please select a club (by name): ");
                        int index = -1;
                        if (Franchise.SelectClub(Console.ReadLine(), ref index))
                        {
                            Club currentClub = Franchise.GetClub(index);
                            Console.WriteLine("\nYou have selected " + currentClub.ClubName);

                            ClubMenu:
                            DisplayClubOptions();
                            Console.WriteLine();
                            int clubPrompt = Validator.GetNumber(1, 5, "Select an option:");
                            switch (clubPrompt)
                            {
                                case 1: // Display all franchise members
                                {
                                        Franchise.DisplayAllMembers();
                                        goto ClubMenu;
                                }
                                case 2: // Select member
                                {
                                        int memberIndex = Validator.GetNumber(1, Franchise.ClubMembers.Count, "Please select a member(by number)") - 1;
                                        Member selectedMember = Franchise.ClubMembers[memberIndex];
                                        Console.WriteLine("\nYou have selected " + selectedMember.Name);

                                        MemberMenu:
                                        DisplayMemberOptions();
                                        Console.WriteLine();
                                        int memberPrompt = Validator.GetNumber(1, 5, "Select an option:");
                                        switch (memberPrompt)
                                        {
                                            case 1: // View member details
                                            {
                                                    selectedMember.PrintMember();
                                                    goto MemberMenu;
                                            }
                                            case 2: // Check-in member
                                            {
                                                    selectedMember.CheckIn(currentClub);
                                                    goto MemberMenu;
                                            }
                                            case 3: // Generate bill
                                            {
                                                    selectedMember.GenerateBill();
                                                    goto MemberMenu;
                                            }
                                            case 4: // Return to club options
                                            {
                                                    goto ClubMenu;
                                            }
                                            case 5: // Terminate program
                                            {
                                                    goto EndProgram;
                                            }
                                        }
                                        goto ClubMenu;
                                }
                                case 3: // Add new member
                                {
                                        Franchise.AddMember(currentClub);
                                        goto ClubMenu;
                                }
                                case 4: // Return to main menu
                                {
                                        goto MainMenu;
                                }
                                case 5: // Terminate program
                                {
                                        goto EndProgram;
                                }
                            }
                        }
                        goto MainMenu;
                }
                case 3: // Add Club
                {
                        Franchise.AddClub();
                        goto MainMenu;
                }
                case 4: // Terminate Program
                {
                        goto EndProgram;
                }
            }
            EndProgram:
            Console.WriteLine("Have a great day!");
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
            Console.WriteLine("4. Return to main menu");
            Console.WriteLine("5. Terminate Program");
        }

        // Displays when 2. is selecteed from DisplayClubOptions()
        static void DisplayMemberOptions()
        {
            Console.WriteLine("1. View member details");
            Console.WriteLine("2. Check-in member");
            Console.WriteLine("3. Generate bill");
            Console.WriteLine("4. Return to club options");
            Console.WriteLine("5. Terminate Program");
        }
    }
}