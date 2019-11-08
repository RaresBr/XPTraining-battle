using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Battle.Tests
{
    public class ArmyTest
    {
        private readonly Headquarters _headquarters = new Headquarters(); 
        [Fact]
        public void Enroll_givenNotNullSoldier_thenIsAddedToSoldierList()
        {
            var soldier = new Soldier("name");
            var army = new Army(_headquarters);
            army.Enroll(soldier);

            army.Soldiers.Should().Contain(soldier);
        }

        [Fact]
        public void Enroll_givenNullSoldier_thenIsNotAddedToSoldierList()
        {
            Soldier soldier = null;
            var army = new Army(_headquarters);
            army.Enroll(soldier);

            army.Soldiers.Should().NotContainNulls();
        }

        [Fact]
        public void Enroll_givenNTwoSoldiers_thenSoldierListIsOrderedFIFO()
        {
            Soldier soldier = new Soldier("name1");
            Soldier soldier2 = new Soldier("name2");
            var army = new Army(_headquarters);

            army.Enroll(soldier);
            army.Enroll(soldier2);

            army.Soldiers.Dequeue().Should().Equals(soldier);
        }

        [Fact]
        public void FrontManDied_givenFrontMan_whenFrontManDies_shouldBeReplaced()
        {
            Soldier soldier = new Soldier("name1");
            Soldier soldier2 = new Soldier("name2");
            var army = new Army(_headquarters);

            army.Enroll(soldier);
            army.Enroll(soldier2);

            army.FrontManDied();

            army.FrontMan.Should().Be(soldier2);
            army.Soldiers.Should().NotContain(soldier);
        }

        [Fact]
        public void FrontManDied_givenWar_whenFrontManDies_shouldBeReplaced()
        {
            Soldier soldier1 = new Soldier("name1", new Axe());
            Soldier soldier2 = new Soldier("name2", new BareFist());
            Soldier soldier3 = new Soldier("name3", new BareFist());
            Soldier soldier4 = new Soldier("name4", new Axe());

            var army1 = new Army(_headquarters);
            army1.Enroll(soldier1);
            army1.Enroll(soldier2);

            var army2 = new Army(_headquarters);
            army2.Enroll(soldier3);
            army2.Enroll(soldier4);

            army1.War(army2);

            army1.FrontMan.Should().Be(soldier1);
        }

        [Fact]
        public void War_givenWar_whenAllSoldiersDie_shouldFrontManBeNull()
        {
            Soldier soldier = new Soldier("name1", new Axe());
            Soldier soldier2 = new Soldier("name2", new Axe());
            Soldier soldier3 = new Soldier("name1", new BareFist());
            Soldier soldier4 = new Soldier("name2", new BareFist());

            var army = new Army(_headquarters);
            army.Enroll(soldier);
            army.Enroll(soldier2);

            var army2 = new Army(_headquarters);
            army2.Enroll(soldier3);
            army2.Enroll(soldier4);

            army.War(army2);

            army.FrontMan.Should().Be(soldier);
            army2.FrontMan.Should().Be(null);
            army2.Soldiers.Should().HaveCount(0);
        }
    }
}
