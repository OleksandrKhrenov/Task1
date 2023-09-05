using System;
using System.Collections.Generic;
namespace Task1
{
    public class GameSession
    {
        private Player player;
        private int wavesSurvived;

        public static List<string> MonsterNames = new List<string>()
        {
            "Skeleton",
            "Bandit",
            "Assassin"
        };

        public static Dictionary<int, string> MonsterHealingItems = new Dictionary<int, string>()
        {
            { 10, "Rat Heart" },
            { 20, "Dog Heart" },
            { 30, "Human Heart" }
        };

        public static Dictionary<int, string> MonsterWeaponItems = new Dictionary<int, string>()
        {
            { 10, "Broken Sword" },
            { 20, "Smith Hammer" },
            { 30, "Bone Spear" }
        };

        public static Dictionary<int, string> PlayerHealingItems = new Dictionary<int, string>()
        {
            { 10, "Happy Song" },
            { 20, "Syringe" },
            { 30, "Medkit" }
        };

        public static Dictionary<int, string> PlayerWeaponItems = new Dictionary<int, string>()
        {
            { 10, "Small Rock" },
            { 20, "Fire Bomb" },
            { 30, "Shotgun" }
        };

        public GameSession(string playerName, int maxPlayerHealth, int playerInventorySize)
        {
            this.player = new Player(playerName, maxPlayerHealth, playerInventorySize, PlayerHealingItems, PlayerWeaponItems);
            this.wavesSurvived = 0;
        }

        public void PlayGame()
        {
            while (this.player.CurrentHP > 0 && this.player.GetInventorySize() > 0)
            {
                Console.WriteLine("Press any key to start new wave...");
                Console.ReadKey();
                PlayWave();
            }
            Console.WriteLine(this.player.Name + " survived " + this.wavesSurvived + " waves total.");
            Console.WriteLine("Items left in " + this.player.Name + "'s inventory are:");
            this.player.ShowInventory();
        }

        public void PlayWave()
        {
            Random random = new Random();
            int enemyNameIndex = random.Next(0, 2);
            int enemyMaxHealth = random.Next(50, 150);
            int enemyInventorySize = random.Next(5, 15);

            Console.WriteLine("\nEnemy generated: ");
            Monster enemy = new Monster(MonsterNames[enemyNameIndex], enemyMaxHealth, enemyInventorySize, MonsterHealingItems, MonsterWeaponItems);

            while (isAnyReasonToFight(enemy))
            {
                Console.WriteLine();
                Fight(enemy);
            }

            if (this.player.CurrentHP > enemy.CurrentHP)
            {
                this.wavesSurvived += 1;
                Console.WriteLine(this.player.Name + " survived the " + this.wavesSurvived + " wave!");
                this.player.LootEnemy(enemy);
            }
            else
            {
                Console.WriteLine(this.player.Name + " has lost :(");
                this.player.CurrentHP = 0;
                return;
            }
        }

        public void Fight(Monster enemy) 
        {
            player.UseItem(enemy, player.GetItemFromInventory());
            enemy.UseItem(player, enemy.GetItemFromInventory());
        }

        private bool isAnyReasonToFight(Monster enemy)
        {
            bool playerCanFight = this.player.CurrentHP > 0 && this.player.GetInventorySize() > 0;
            bool reasonToFight1 = enemy.CurrentHP > 0 && enemy.GetInventorySize() > 0;
            bool reasonToFight2 = this.player.CurrentHP < enemy.CurrentHP && enemy.GetInventorySize() == 0;

            return playerCanFight && (reasonToFight1 || reasonToFight2);
        }
    }
}
