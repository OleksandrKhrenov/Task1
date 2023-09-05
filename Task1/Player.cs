namespace Task1
{
    public class Player : Opponent
    {
        public Player() : base()
        {
            this.Name = "Player";
            this.ShowInventory();
        }

        public Player(string name, int maxHP, int inventorySize, 
                      Dictionary<int, string> PlayerHealingItems, 
                      Dictionary<int, string> PlayerWeaponItems) 
        : base(name, maxHP, inventorySize, PlayerHealingItems, PlayerWeaponItems)
        {
            this.ShowInventory();
        }

        public void LootEnemy(Opponent enemy)
        {
            IConsumable item;
            while ((item = enemy.GetItemFromInventory()) != null)
            {
                this._inventory.Add(item);
            }
            Console.WriteLine(this.Name + " looted " + enemy.Name);
            this.ShowInventory();
        }
    }
}
