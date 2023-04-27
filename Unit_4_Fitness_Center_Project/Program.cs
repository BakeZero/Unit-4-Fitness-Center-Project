using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Unit_4_Fitness_Center_Project
{
    internal class Program
    {
        static void Main()
        {
            string directoryPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));
            string clubsFilePath = directoryPath + "\\Clubs.csv";
            string membersFilePath = directoryPath + "\\Members.csv";

            // Read clubs and members .csv and store info into respective lists
            ReadClubsCSV(clubsFilePath);
            ReadMembersCSV(membersFilePath);

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
            // Store clubs & members lists into their respective .csv files
            WriteClubsCSV(clubsFilePath);
            WriteMembersCSV(membersFilePath);
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



        // Restore Clubs from a .csv
        static void ReadClubsCSV(string clubsFilePath)
        {
            string[] lines = File.ReadAllLines(clubsFilePath);
            foreach (string line in lines)
            {
                string[] column = line.Split(",");
                Franchise.Clubs.Add(new Club(column[0], column[1]));
            }
        }

        // Store all Clubs into a .csv
        static void WriteClubsCSV(string clubsFilePath)
        {

            StringBuilder output = new StringBuilder();
            foreach (Club club in Franchise.Clubs)
            {
                output.AppendLine(string.Join(",", club.ClubName, club.ClubAddress));
            }
 
            try
            {
                File.WriteAllText(clubsFilePath, output.ToString());
                Console.WriteLine($"Successfully written to {clubsFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Data could not be written to the CSV file.");
                return;
            }
        }

        // Restore ClubMembers list from a .csv
        static void ReadMembersCSV(string membersFilePath)
        {
            string[] lines = File.ReadAllLines(membersFilePath);
            foreach (string line in lines)
            {
                string[] column = line.Split(","); // [0] 
                if (column[0] == "s") // Construct single-club member
                {
                    int clubIndex = -1;
                    Franchise.SelectClub(column[2], ref clubIndex);
                    Franchise.ClubMembers.Add(new SingleMember(column[1], Franchise.GetClub(clubIndex)));
                }
                else // Construct multi-club member
                {
                    Franchise.ClubMembers.Add(new MultiMember(column[1], int.Parse(column[2])));
                }
            }
        }

        // Store all ClubMembers into a .csv
        static void WriteMembersCSV(string membersFilePath)
        {
            StringBuilder output = new StringBuilder();
            foreach (Member mem in Franchise.ClubMembers)
            {
                if (mem.GetType().Name.ToString() == "SingleMember")
                    output.AppendLine(string.Join(",", "s", mem.Name, mem.GetClub().ClubName)) ; // Single members in .csv: (s , name , clubname)
                else
                    output.AppendLine(string.Join(",", "m", mem.Name, mem.GetPoints())); // Multi members in .csv: (m , name , membershipPoints)
            }

            try
            {
                File.WriteAllText(membersFilePath, output.ToString());
                Console.WriteLine($"Successfully written to {membersFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Data could not be written to the CSV file.");
                return;
            }
        }
    }
}