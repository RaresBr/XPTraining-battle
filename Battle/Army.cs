using System;
using System.Collections.Generic;
using System.Text;

namespace Battle
{
    public class Army
    {
        public Queue<Soldier> Soldiers;
        Headquarters _headquarters;

        public Soldier FrontMan { get; set; }
        public Army(Headquarters HQ)
        {
            Soldiers = new Queue<Soldier>();
            _headquarters = HQ;
        }

        public void Enroll(Soldier soldier)
        {
            if (soldier != null)
            {
                int soldierId = _headquarters.ReportEnlistment(soldier.Name);
                soldier.soldierId = soldierId;

                Soldiers.Enqueue(soldier);

                if (Soldiers.Count == 1)
                {
                    this.FrontMan = soldier;
                }
            }

        }

        public void War(Army otherArmy)
        {
            while (this.HasSoldiers() && otherArmy.HasSoldiers())
            {
                Soldier winner = FrontMan.Fight(otherArmy.FrontMan);

                if (winner == FrontMan)
                {
                    otherArmy.FrontManDied();
                }

                if (winner == otherArmy.FrontMan)
                {
                    this.FrontManDied();
                }
            }

            ReportVictory(this, otherArmy);
        }

        public void ReportVictory(Army army1, Army army2)
        {
            if (army1.HasSoldiers())
            {
                _headquarters.ReportVictory(army1.Soldiers.Count);
            }

            if (army2.HasSoldiers())
            {
                _headquarters.ReportVictory(army2.Soldiers.Count);
            }
        }

        public void FrontManDied()
        {
            Soldier deadSoldier = this.Soldiers.Dequeue();
            _headquarters.ReportCasualty(deadSoldier.soldierId);
            
            if (this.HasSoldiers())
            {
                this.FrontMan = this.Soldiers.Peek();

            }

            if (!this.HasSoldiers())
            {
                this.FrontMan = null;
            }

        }

        public Boolean HasSoldiers()
        {
            return this.Soldiers.Count > 0;
        }

    }
}
