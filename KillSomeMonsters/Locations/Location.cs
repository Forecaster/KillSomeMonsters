using KillSomeMonsters.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Locations
{
  public abstract class Location
  {
    public string name;
    public string genericName;
    public string genericPlural;
    public List<string> genericDescription;
    public bool visited;

    public List<Enemy> enemies = new List<Enemy>();

    public Location north;
    public Location south;
    public Location east;
    public Location west;

    public static Location generateRandomLocation(int minEnemies, int maxEnemies)
    {
      Random rand = new Random();
      int number = rand.Next(0, 100);

      if (0 <= number && number <= 15)
      {
        number = rand.Next(0, EnvNames.namesTown.Count - 1);
        return new Town(EnvNames.namesTown[number]);
      }
      else if (15 < number && number <= 60)
      {
        number = rand.Next(0, EnvNames.namesForest.Count - 1);
        return new Forest(EnvNames.namesForest[number], minEnemies, maxEnemies);
      }
      else
      {
        number = rand.Next(0, EnvNames.namesMountains.Count - 1);
        return new Mountains(EnvNames.namesMountains[number], minEnemies, maxEnemies);
      }
    }

    public void arrive()
    {
      this.visited = true;
    }

    /*
     * For describing whether a location has monsters and/or have been visited in an immersive manner
     */
    public string inspectLocation()
    {
      string visited = "an unfamiliar";
      if (this.visited)
        visited = "a familiar";

      string enemies = "hostile";
      if (this.enemies.Count == 0)
        enemies = "peaceful";
        
      return "You see the outline of " + visited + " " + this.genericName + " in the distance.\nYou get a " + enemies + " vibe from it.";
    }

    public string getRandomDescription()
    {
      Random rand = new Random();
      int number = rand.Next(0, this.genericDescription.Count - 1);
      return this.genericDescription[number];
    }
  }
}
