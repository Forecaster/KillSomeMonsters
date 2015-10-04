using KillSomeMonsters.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Locations
{
  public class Sewer : Location
  {
    public Sewer(int minEnemies, int maxEnemies)
    {
      Random rand = new Random();

      this.name = "";
      this.genericName = "sewer";
      this.genericPlural = "sewers";
      this.genericDescription = new List<string>();
      this.genericDescription.Add("As you enter the damp drainage tunnels under the town you ask yourself what you could possibly find down here...");
      this.genericDescription.Add("As water starts to hug your feet with a cold twang you wonder whatever came over you to make you go down here.");
      this.genericDescription.Add("The air is so moist you can almost touch it, and with a moldy smell to it. Not the nicest place to be.");

      int enemies = rand.Next(minEnemies, maxEnemies);

      for (int i = 0; i < enemies; i++)
      {
        this.enemies.Add(new Enemy("Some enemy"));
      }
    }
  }
}
