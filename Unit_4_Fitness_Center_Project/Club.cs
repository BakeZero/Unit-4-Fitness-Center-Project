using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_4_Fitness_Center_Project
{
    internal class Club
    {
        public string ClubName { get; set; }
        public string ClubAddress { get; set; }
        
        public Club()
        { 
            ClubName = string.Empty;
            ClubAddress = string.Empty;
        }
        public Club(string ClubName, string ClubAddress)
        {
            this.ClubName = ClubName;
            this.ClubAddress = ClubAddress;
        }

        public void DisplayClub()
        {
            Console.WriteLine("Club Name: " + ClubName.PadRight(20) + "\tClub Address: " + ClubAddress);
        }
    }
}
