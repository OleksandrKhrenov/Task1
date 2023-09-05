namespace Task1
{
    public class Opponent
    {
        public string Name { get; set; }
        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }

        protected List<IConsumable> _inventory;

        public Opponent()
        {
            Dictionary<int, string> DefaultHealingItems = new Dictionary<int, string>()
            {
                { 10, "Small HP Potion" },
                { 20, "Medium HP Potion" },
                { 30, "Big HP Potion" }
            };
            Dictionary<int, string> DefaultWeaponItems = new Dictionary<int, string>()
            {
                { 10, "Broken Gun" },
                { 20, "Basic Gun" },
                { 30, "Strong Gun" }
            };

            this.Name = "Default Opponent";
            this.MaxHP = 100;
            this.CurrentHP = 100;
            this._inventory = GenerateRandomInventory(1, DefaultHealingItems, DefaultWeaponItems);
        }

        public Opponent(string name, int maxHP, int inventorySize, 
                        Dictionary<int, string> HealingItems,
                        Dictionary<int, string> WeaponItems)
        {
            this.Name = name;
            this.MaxHP = maxHP;
            this.CurrentHP = MaxHP;
            this._inventory = GenerateRandomInventory(inventorySize, HealingItems, WeaponItems);
        }

        protected virtual List<IConsumable> GenerateRandomInventory(int size, 
                                                                    Dictionary<int, string> HealingItemsScope, 
                                                                    Dictionary<int, string> WeaponItemsScope)
        {
            List<IConsumable> inventory = new List<IConsumable>();

            for (int i = 0; i < size; i++)
            {
                IConsumable item;
                Random random = new Random();
                int itemPower = random.Next(1, 3) * 10;
                if (random.Next(1, 100) > 40)
                {
                    item = new Weapon(WeaponItemsScope[itemPower], itemPower);
                }
                else
                {
                    item = new Healing(HealingItemsScope[itemPower], itemPower);
                }
                inventory.Add(item);
            }

            return inventory;
        }

        public IConsumable GetItemFromInventory()
        {
            if (this._inventory.Count > 0)
            {
                IConsumable item = this._inventory[0];
                this._inventory.RemoveAt(0);
                return item;
            }
            //Console.WriteLine(this.Name + "'s inventory is empty!");
            return null;
        }

        public virtual void ShowInventory()
        {
            if (this._inventory.Count > 0)
            {
                for (int i = 0; i < this._inventory.Count(); i++)
                {
                    (string itemType, string itemName, int itemPower) = this._inventory[i].GetInfo();
                    Console.WriteLine((i + 1).ToString() + ": [ " + itemName + " - " + itemType + " - " + itemPower + " ]");
                }
            }
            else
            {
                Console.WriteLine("Inventory is empty!");
            }
            Console.WriteLine("Name: " + this.Name + "\tHP: " + this.CurrentHP + "/" + this.MaxHP + ".");
        }

        public int GetInventorySize()
        {
            return this._inventory.Count;
        }

        public virtual int ReceiveDamage(int damage)
        {
            int trueDamage = (this.CurrentHP - damage) < 0 ? this.CurrentHP : damage;
            CurrentHP -= trueDamage;
            return trueDamage;
        }

        public virtual int ReceiveHeal(int heal)
        {
            int trueHeal = (this.CurrentHP + heal) > this.MaxHP ? (this.MaxHP - this.CurrentHP) : heal;
            CurrentHP += trueHeal;
            return trueHeal;
        }

        public virtual void UseItem(Opponent opponent, IConsumable item)
        {
            if (item == null)
            {
                Console.WriteLine(this.Name + "'s inventory is empty, so it only stands there dumbly waiting for " + opponent.Name + "'s actions...");
                return;
            }

            (string itemType, string itemName, int itemPower) = item.GetInfo();

            if (itemType == "Weapon")
            {
                int factualDamage = opponent.ReceiveDamage(itemPower);
                Console.WriteLine(this.Name + " uses " + itemName + " and deals " + factualDamage + " damage to " + opponent.Name + ". " + opponent.Name + "'s current HP = " + opponent.CurrentHP);
            }
            else if (itemType == "Healing")
            {
                int factualHeal = this.ReceiveHeal(itemPower);
                Console.WriteLine(this.Name + " uses " + itemName + " and heals themselves for " + factualHeal + ". Current HP = " + this.CurrentHP);
            }
            else
            {
                Console.WriteLine("Unknown item");
            }
        }

    }
}