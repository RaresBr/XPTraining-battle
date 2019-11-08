using System;
using System.Collections.Generic;
using System.Text;

namespace Battle
{
    public class Headquarters : IHeadquarters
    {
        private int _soldierId;

        public int ReportEnlistment(string soldierName)
        {
            return _soldierId++;
        }

        public void ReportCasualty(int soldierId)
        {
            Console.Write(soldierId);
        }

        public void ReportVictory(int remainingNumberOfSoldiers)
        {
            Console.Write(remainingNumberOfSoldiers);
        }
    }
}
