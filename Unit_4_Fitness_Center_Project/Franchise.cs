using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_4_Fitness_Center_Project
{
    internal static class Franchise
    {
        public static List<Club> Clubs = new List<Club>()
        {
            // Disclaimer: All addresses were randomly generated 
            //       Club Name           Club Address
            new Club("Planet Chirpus", "16630 N Scottsdale Rd"),
            new Club("Planet Derpus", "931 Pacific Ave"),
            new Club("Fit Nation", "323 E Washington St"),
            new Club("Power World", "2823 Alta Mere Dr")
        };
        public static List<Member> ClubMembers = new List<Member>()
        {
            new SingleMember("Harry", Clubs[0]),
            new SingleMember("Daniel", Clubs[1]),
            new MultiMember("Tommy", 30),
            new MultiMember("Macy"),
            new SingleMember("Zayn", Clubs[0]),
            new SingleMember("Nathan", Clubs[2]),
            new SingleMember("Michael", Clubs[3]),
            new MultiMember("Amy", 50)
        };

        public static void DisplayAllMembers()
        {
            Console.Write("(");
            for (int i=0;  i<ClubMembers.Count; i++)
            {
                if (i != ClubMembers.Count - 1)
                {
                    Console.Write(i + 1 + ". " + ClubMembers[i].Name + ", ");
                }
                else
                {
                    Console.WriteLine(i + 1 + ". " + ClubMembers[i].Name + ")\n");
                }
            }
        }

        // Get user input on member's name and membership option, and then add to member list
        public static void AddMember(Club currentClub)
        {

            int option = Validator.GetNumber(1, 2, "Select a plan. 1-Single Club, 2-Multi Club");
            NamePrompt:
            Console.Write("Enter a name: ");
            string name = Console.ReadLine().Trim();
            if (option == 1 && name != "") // Make single club member
            {
                ClubMembers.Add(new SingleMember(name, currentClub));
            }
            else if (option == 2 && name != "") // Make multi club member
            {
                Console.WriteLine($"Congratulations {name}! You gained 10 membership points for signing on multi-club!");
                ClubMembers.Add(new MultiMember(name, 10));
            }
            else
            {
                Console.WriteLine("Empty string inputted.");
                goto NamePrompt;
            }
        }

        public static void DisplayAllClubs()
        {
            foreach (Club club in Clubs)
            {
                club.DisplayClub();
            }
        }

        // Get user input on club's name and address, and then add it to club list
        public static void AddClub()
        {
            Console.Write("Enter club name: ");
            string clubName = Console.ReadLine().Trim();
            Console.Write("Enter club address: ");
            string clubAddress = Console.ReadLine().Trim();
            Clubs.Add(new Club(clubName, clubAddress));
        }

        // Returns true if a selected club exists, and outputs the index via the method variable
        public static bool SelectClub(string clubName, ref int index)
        {
            for (int i = 0; i < Clubs.Count; i++)
            {
                if (Clubs[i].ClubName.ToLower() == clubName.ToLower())
                {
                    index = i;
                    return true;
                }
            }
            Console.WriteLine("That club does not exist.");
            return false;
        }

        // Return club object at a given index from the Clubs list
        public static Club GetClub(int index)
        {
            try
            {
                return Clubs[index];
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }
    }
}
