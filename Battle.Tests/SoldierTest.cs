using System;
using FluentAssertions;
using Xunit;

namespace Battle.Tests
{
    public class SoldierTest
    {

        [Fact]
        public void Construction_ASoldierMustHaveAName()
        {
            var soldier = new Soldier("name");

            soldier.Name.Should().Be("name");
        }

        [Theory]
        [InlineData("")]
        [InlineData("        ")]
        [InlineData(null)]
        public void Construction_ASoldierMustHaveAName_CannotBeBlank(string name)
        {
            Action act = () => new Soldier(name);

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Fight_GivenTwoSoldiers_WhenFighting_WinningSoldierMustBeReturned()
        {
            var attacker = new Soldier("S1", new BareFist());
            var defender = new Soldier("S2", new Axe());

            var result = attacker.Fight(defender);

            result.Should().Be(defender);
        }

        [Fact]
        public void Fight_GivenTwoSoldierS_WhenFightingWithSameWeapon_AttackingSoldierMustBeReturned()
        {
            var attacker = new Soldier("S1", new Axe());
            var defender = new Soldier("S2", new Axe());

            var result = attacker.Fight(defender);

            result.Should().Be(attacker);
        }
    }
}