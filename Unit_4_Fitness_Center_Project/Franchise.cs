using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_4_Fitness_Center_Project
{
    internal static class Franchise
    {
        public static List<Club> Clubs = new List<Club>();
        public static List<Member> ClubMembers = new List<Member>();


        public static void DisplayAllMembers()
        {
            foreach (Member member in ClubMembers)
            {
                Console.WriteLine(member.Name);
                member.CheckIn(Clubs[0]);
            }
        }

        public static void AddMember(Member member)
        {
            ClubMembers.Add(member);
        }

        public static void DisplayAllClubs()
        {
            foreach (Club club in Clubs)
            {
                club.DisplayClub();
            }
        }

        public static void AddClub(Club club)
        {
            Clubs.Add(club);
        }


    }
}
