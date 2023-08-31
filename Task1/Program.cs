namespace Task1
{
    class Opponent
    {
        private string name;
        private int maxHP;
        private int currentHP;
        private List<IUsable> inventory;

        public string Name
        {
            get => name; 
            set => name = value;
        }

        public int CurrentHP
        {
            get => currentHP;
            set => currentHP = value;
        }

        public int MaxHP
        {
            get => maxHP; 
            set => maxHP = value; 
        }

        public IUsable GetItemFromInventory()
        {
            if (inventory.Count > 0)
            {
                IUsable item = inventory[0];
                inventory.RemoveAt(0);
                return item;
            }
            return null;
        }

        public virtual void ReceiveDamage(int trueDamage)
        {
            CurrentHP -= trueDamage;
        }

        public virtual void ReceiveHeal(int trueHeal)
        {
            CurrentHP += trueHeal;
        }

        public virtual void UseItem(Opponent opponent, IUsable item)
        {
            (string itemType, string itemName, int itemPower) = item.Use();
            if (itemType == "Weapon") 
            {
                opponent.ReceiveDamage(itemPower);
                Console.WriteLine();
            }
            else if (itemType == "Healing")
            {

            }
            else
            {
                Console.WriteLine("Unknown item");
            }
        }

    }
}