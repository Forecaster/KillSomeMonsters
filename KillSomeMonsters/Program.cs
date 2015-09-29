using KillSomeMonsters.Locations;
using KillSomeMonsters.Equipment;
using KillSomeMonsters.StatEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KillSomeMonsters.Entities;
using KillSomeMonsters.Menus;

namespace KillSomeMonsters
{
  class Program
  {
    public static Game currentGame = null;
    public static string gameName = "Kill Some Monsters or something";
    public static string authorName = "Forecaster";
    static void Main(string[] args)
    {
      currentGame = new Game("Forecaster");
      //Player player = new Player("PlayerName", 20, 10);
      //Potion potion = new Potion("Potion of Testing", Effect.HEAL, 1);
      //Console.WriteLine(potion.getEffect());

      //Console.WriteLine(player.health + "/" + player.maxHealth);
      //int result = potion.drinkPotion(player);
      //Console.WriteLine(player.health + "/" + player.maxHealth);
      //Console.WriteLine(result.ToString());
      //Console.ReadKey();

      Menu.mainMenu();
    }
  }
}
