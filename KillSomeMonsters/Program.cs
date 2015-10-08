using KillSomeMonsters.Locations;
using KillSomeMonsters.Items;
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
    public static int enemiesPerLocationMin = 3;
    public static int enemiesPerLocationMax = 6;
    public static int maxPotionCarry = 3;

    public static string cursor = " > ";

    public static bool debugModeEnabled = false;

    public static int worldSizeX = 15;
    public static int worldSizeY = 15;

    static void Main(string[] args)
    {
      Menu.mainMenu();

      if (debugModeEnabled)
      {
        Console.WriteLine("Reached end of program");
        Console.ReadKey();
      }
    }
  }
}
