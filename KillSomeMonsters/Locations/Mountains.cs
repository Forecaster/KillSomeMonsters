using KillSomeMonsters.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Locations
{
  public class Mountains : Location
  {
    public Mountains(string name, int numberOfEnemies)
    {
      Random rand = new Random();
      this.name = name;
      this.genericName = "mountain";
      this.genericPlural = "mountains";

      for (int i = 0; i < numberOfEnemies; i++)
      {
        int randomName = rand.Next(0, EnemyNames.namesEnemies.Count);
        int randomHealth = rand.Next(10, 30);
        this.enemies.Add(new Enemy(EnemyNames.namesEnemies[randomName], randomHealth));
      }
    }
  }
}
