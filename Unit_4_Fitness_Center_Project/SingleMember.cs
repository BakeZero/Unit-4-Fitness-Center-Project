using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_4_Fitness_Center_Project
{
    internal class SingleMember : Member
    {
        public Club Club;
        public SingleMember(string Name) 
        {
            Club = new Club();
            this.Name = Name;
            Bill = 10;
        }
        public SingleMember(Club Club)
        {
            this.Club = Club;
            Bill = 10;
        }
        public SingleMember(string Name, Club Club)
        {
            this.Name = Name;
            this.Club = Club;
            Bill = 10;
        }

        public void DesignateClub(Club Club)
        {
            this.Club = Club;
        }

        public override void CheckIn(Club club)
        {
            
            if (this.Club == club)
                Console.WriteLine($"Single-Club Member checked in at {club.ClubName} at {DateTime.Now.ToString("hh:mm:ss tt")} on {DateTime.Now.ToShortDateString()}");
            else
                Console.WriteLine("This person doesn't belong to this club.");
        }

        public override void GenerateBill()
        {
            Console.WriteLine($"Your bill is {Bill:c}");
        }

        public override void PrintMember()
        {
            Console.WriteLine($"{this.Name} is a single-club member of {Club.ClubName}");
        }
    }
}
