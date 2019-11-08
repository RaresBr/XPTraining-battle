using System;

namespace Battle
{
    public class Soldier
    {
        public Soldier(string name)
        {
            ValidateNameisNotBlank(name);
            Name = name;
            Weapon = new BareFist();
        }


        public Soldier(string name, BaseWeapon weapon)
        {
            ValidateNameisNotBlank(name);
            Name = name;
            Weapon = weapon;
        }

        public Soldier Fight(Soldier enemy)
        {
            if (Weapon.Damage >= enemy.Weapon.Damage)
            {
                return this;
            }
            return enemy;

        }

        
        private void ValidateNameisNotBlank(string name)
        {
            if (IsBlank(name))
            {
                throw new ArgumentException("name can not be blank");
            }
        }

        private bool IsBlank(string name) => string.IsNullOrEmpty(name?.Trim());
        
        public string Name { get; }

        public BaseWeapon Weapon { get; set; }
    }
}