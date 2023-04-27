using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_4_Fitness_Center_Project
{
    internal abstract class Member
    {
        public string Name;
        public double Bill;
        public abstract void CheckIn(Club club);
        public abstract void GenerateBill();
        public abstract void PrintMember();

        // Used purely for data extraction in IO
        public virtual Club GetClub() { return new Club(); }
        // Used purely for data extraction in IO
        public virtual double GetPoints() { return 0; }
    }
}
