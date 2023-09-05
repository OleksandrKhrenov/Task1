namespace Task1
{
    public class Weapon : IConsumable
    {
        public string Name { get; set; }
        public int DamageOutput { get; set; }

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

        public (string, string, int) GetInfo()
        {
            return ("Weapon", Name, DamageOutput);
        }
    }
}

