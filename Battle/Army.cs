using System;
using System.Collections.Generic;
using System.Text;

namespace Battle
{
    public class Army
    {
        public List<Soldier> Soldiers;

        public Army()
        {
            Soldiers = new List<Soldier>();
        }

        public void Enroll(Soldier soldier)
        {
            if (soldier != null)
            {
                Soldiers.Add(soldier);
            }

        }
    }
}
