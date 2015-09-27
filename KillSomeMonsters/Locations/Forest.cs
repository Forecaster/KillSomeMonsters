using KillSomeMonsters.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Locations
{
  public class Forest : Location 
  {
    public Forest(string name, int numberOfEnemies)
    {
      Random rand = new Random();
      this.name = name;

      for (int i = 0; i < numberOfEnemies; i++)
      {
        int randomName = rand.Next(0, EnemyNames.namesEnemies.Count);
        int randomHealth = rand.Next(10, 30);
        this.enemies.Add(new Enemy(EnemyNames.namesEnemies[randomName], randomHealth));
      }
    }
  }
}
