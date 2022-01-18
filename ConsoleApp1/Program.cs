using System;
using System.IO;

namespace EpicBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            string rootPath = @"C:\Users\opilane\samples\";
            string[] heroes = GetDataFromFile(rootPath + "heroes.txt");
            string[] villains = GetDataFromFile(rootPath + "villains.txt");
            string[] weapon = GetDataFromFile(rootPath + "weapon.txt");
            string[] armor = GetDataFromFile(rootPath + "armor.txt");


            string randomHero = GetRandomCharacter(heroes);
            string randomVillains = GetRandomCharacter(villains);
            Console.WriteLine($"Your random hero is {randomHero}");
            Console.WriteLine($"Your random villain is {randomVillains}");

            string randomWeapon = GetRandomCharacter(weapon);
            string randomWeapons = GetRandomCharacter(weapon);
            Console.WriteLine($"Your weapon Hero {randomWeapon}");
            Console.WriteLine($"Your weapon Villain {randomWeapons}");
            string heroArmor = GetRandomCharacter(armor);
            string villainArmor = GetRandomCharacter(armor);
            int heroHP = GeneratorHP(heroArmor);
            int villainHP = GeneratorHP(villainArmor);
            Console.WriteLine($"{heroArmor} gives {randomHero} {heroHP} HP.");
            Console.WriteLine($"{villainArmor} gives {randomVillains} {villainHP} HP.");

            while (heroHP >= 0 && villainHP >= 0)
            {
                heroHP = heroHP - Hit(randomVillains, randomWeapons);
                villainHP = villainHP - Hit(randomHero, randomWeapon);
            }

            if (heroHP > villainHP)
            {
                Console.WriteLine($"{randomHero} saves the day!");
            }
            else if (heroHP < villainHP)
            {
                Console.WriteLine("Dark Side wins!");
            }
            else
            {
                Console.WriteLine($"Both {randomHero} and {randomVillains} dropped dead.");
            }
        }

        public static string GetRandomCharacter(string[] someArray)
        {

            return someArray[GetRandomIndexForArray(someArray)];
        }

        public static int GetRandomIndexForArray(string[] someArray)
        {
            Random rnd = new Random();
            return rnd.Next(0, someArray.Length);
        }
        public static string[] GetDataFromFile(string filePath)
        {
            string[] dataFromFile = File.ReadAllLines(filePath);
            return dataFromFile;
        }
        public static int GeneratorHP(string armor)
        {
            return armor.Length;
        }
        public static int Hit(string characte, string weapon)
        {
            //weapon.Length-2
            Random rnd = new Random();
            int strike = rnd.Next(0, weapon.Length - 2);
            Console.WriteLine($"{characte} hit {strike}.");
            if (strike == 0)
            {
                Console.WriteLine($"Bad luck. {characte} missed the target.");
            }
            else if (strike == weapon.Length - 2)
            {
                Console.WriteLine($"Awesome! {characte} made a critical hit!");
            }

            return strike;
        }
    }
}