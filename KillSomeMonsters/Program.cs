using KillSomeMonsters.Locations;
using KillSomeMonsters.Equipment;
using KillSomeMonsters.StatEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KillSomeMonsters.Entities;

namespace KillSomeMonsters
{
  class Program
  {
    static void Main(string[] args)
    {
      Player player = new Player("PlayerName", 20, 10);
      Potion potion = new Potion("Potion of Testing", Effect.HEAL, 1);
      Console.WriteLine(potion.getEffect());

      Console.WriteLine(player.health + "/" + player.maxHealth);
      int result = potion.drinkPotion(player);
      Console.WriteLine(player.health + "/" + player.maxHealth);
      Console.WriteLine(result.ToString());
      Console.ReadKey();
    }
  }
}
