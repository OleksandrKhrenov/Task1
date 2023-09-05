namespace Task1
{
    public class Healing : IConsumable
    {
        public string Name { get; set; }
        public int HealPower { get; set; }

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
        public (string, string, int) GetInfo()
        {
            return ("Healing", Name, HealPower);
        }
    }
}
