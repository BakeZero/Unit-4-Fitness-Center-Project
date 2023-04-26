using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_4_Fitness_Center_Project
{
    internal class MultiMember : Member
    {
        public int MembershipPoints;
        public MultiMember(string Name) 
        {
            MembershipPoints = 0;
            this.Name = Name;
            Bill = 25;
        }
        public MultiMember(string Name, int MembershipPoints)
        {
            this.MembershipPoints = MembershipPoints;
            this.Name = Name;
            Bill = 25;
        }

        public override void CheckIn(Club club)
        {
            Console.WriteLine($"Multi-Club Member checked in at {club.ClubName} at {DateTime.Now.ToString("hh:mm:ss tt")} on {DateTime.Now.ToShortDateString()}");
        }

        public override void GenerateBill()
        {
            Prompt:
            Console.Write($"You have {MembershipPoints} membership points, would you like to apply them? (y/n): ");
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.WriteLine($"Your bill after applying membership points is {(Bill - MembershipPoints/100):c}");
            }
            else if (Console.ReadLine().ToLower() == "n")
            {
                Console.WriteLine($"Your bill is {Bill:c}");
            }
            else
                goto Prompt;
        }

        public override void PrintMember()
        {
            Console.WriteLine($"{this.Name} is a multi-club member with {MembershipPoints} membership points");
        }
    }
}
