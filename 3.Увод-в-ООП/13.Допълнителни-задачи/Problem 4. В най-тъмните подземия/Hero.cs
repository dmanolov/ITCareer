using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeonest_Dark
{
    class Hero
    {
        private int health = 100;
        private int cash = 0;
        private int currentRoom = 0;

        public int Health { get => health; }
        public int Cash { get => cash; }
        public int CurrentRoom { get => currentRoom; }

        public bool GoToMission(string rooms, bool resetHero)
        {
            // дали да нулира данните на героя
            if (resetHero)
            {
                health = 100;
                cash = 0;
            }
            currentRoom = 0;
            // разбиваме на стаи и ги обхождаме
            var input = rooms.Split('|');
            for (int i = 0; i < input.Length; i++)
            {
                if (!EnterRoom(input[i]))
                    return false;
            }
            // ако героят не умре по време на мисията
            YouWin();
            return true;
        } 

        public bool EnterRoom(string room)
        {
            currentRoom++;
            var success = true;
            var input = room.Split();
            var kind = input[0];
            var howMany = int.Parse(input[1]);
            switch (kind) {
                case "potion": DrinkPotion(howMany); break;
                case "chest": FindChest(howMany); break;
                default: success = FightWithMonster(kind, howMany); break;
            }
            return success;
        }

        public void DrinkPotion(int potion)
        {
            
            if (health + potion > 100)
            {
                potion = 100 - health;
                health = 100;
            }
            else health += potion;
            Console.WriteLine($"You healed for {potion} hp.");
            Console.WriteLine($"Current health: {health} hp.");
        }

        public void FindChest(int cash)
        {
            this.cash += cash;
            Console.WriteLine($"You found {cash} coins.");
        }

        public bool FightWithMonster(string monster, int power)
        {
            health -= power;
            if (health > 0)
            {
                Console.WriteLine($"You slayed {monster}.");
                return true;
            }
            else
            {
                Console.WriteLine($"You died! Killed by {monster}.");
                Console.WriteLine($"Best room: {currentRoom}");
                return false;
            }
        }

        public void YouWin()
        {
            Console.WriteLine("You've made it!");
            Console.WriteLine($"Coins: {cash}");
            Console.WriteLine($"Health: {health}");
        }
    }
}
