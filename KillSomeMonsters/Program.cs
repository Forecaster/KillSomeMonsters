using KillSomeMonsters.Locations;
using KillSomeMonsters.Equipment;
using KillSomeMonsters.StatEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KillSomeMonsters.Creatures;
using KillSomeMonsters.Menus;

namespace KillSomeMonsters
{
  class Program
  {
    public static Game currentGame = null;
    public static bool gameInProgress = false;
    public static string gameName = "Kill Some Monsters or something";
    public static string authorName = "Forecaster";
    public static int enemiesPerLocation = 3;

    public static int worldSizeX = 15;
    public static int worldSizeY = 15;

    static void Main(string[] args)
    {
      //Town town = new Town("testVille");
      //Player testPlayer = new Player("PlayerName", ref town);
      //Potion potion = new Potion("Potion of Testing", Effect.HEAL, 1);
      //Console.WriteLine(potion.getEffect());

      //Console.WriteLine(testPlayer.health + "/" + testPlayer.maxHealth);
      //int result = potion.drinkPotion(testPlayer);
      //Console.WriteLine(testPlayer.health + "/" + testPlayer.maxHealth);
      //Console.WriteLine(result.ToString());
      //Console.ReadKey();

      Menu.mainMenu();

      Console.WriteLine("Reached end of program");
      Console.ReadKey();
    }
  }
}
