using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Battle.Tests
{
    public class ArmyTest
    {

        [Fact]
        public void Enroll_givenNotNullSoldier_thenIsAddedToSoldierList()
        {
            var soldier = new Soldier("name");
            var army = new Army();
            army.Enroll(soldier);

            army.Soldiers.Should().Contain(soldier);
        }

        [Fact]
        public void Enroll_givenNullSoldier_thenIsNotAddedToSoldierList()
        {
            Soldier soldier = null;
            var army = new Army();
            army.Enroll(soldier);

            army.Soldiers.Should().NotContainNulls();
        }

        [Fact]
        public void Enroll_givenNTwoSoldiers_thenSoldierListIsOrderedFIFO()
        {
            Soldier soldier = new Soldier("name1");
            Soldier soldier2 = new Soldier("name2");
            var army = new Army();

            army.Enroll(soldier);
            army.Enroll(soldier2);

            army.Soldiers[0].Should().Equals(soldier);
            army.Soldiers[0].Should().NotBe(soldier2);
        }
    }
}
