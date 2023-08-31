using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task1
{
    public interface IUsable
    {
        public string Name { get; set; }
        public (string, string, int) Use();
    }

    public class Weapon : IUsable
    {
        private string _name;
        private int _damageOutput;
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public int DamageOutput
        {
            get => _damageOutput;
            set => _damageOutput = value;
        }

        public Weapon()
        {
            this.Name = "DefaultWeapon";
            this.DamageOutput = 1;
        }

        public Weapon(string name, int damage)
        {
            this.Name = name;
            this.DamageOutput = damage;
        }

        public (string, string, int) Use()
        {
            return ("Weapon", Name, DamageOutput);
        }
    }

    public class Healing : IUsable
    {
        private string _name;
        private int _healPower;
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public int HealPower
        {
            get => _healPower;
            set => _healPower = value;
        }
        public Healing()
        {
            this.Name = "DefaultHealing";
            this.HealPower = 1;
        }

        public Healing(string name, int amount)
        {
            this.Name = name;
            this.HealPower = amount;
        }
        public (string, string, int) Use()
        {
            return ("Healing", Name, HealPower);
        }
    }
}
