namespace Task1
{
    public class Monster : Opponent
    {
        public Monster() : base() 
        {
            this.Name = "Skeleton";
            this.ShowInventory();
        }

        public Monster(string name, int maxHP, int inventorySize, 
                       Dictionary<int, string> MonsterHealingItems,
                       Dictionary<int, string> MonsterWeaponItems) 
        : base(name, maxHP, inventorySize, MonsterHealingItems, MonsterWeaponItems)
        {
            this.ShowInventory();
        }
    }
}
