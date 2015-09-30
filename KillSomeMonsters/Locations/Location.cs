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

    public List<Enemy> enemies = new List<Enemy>();

    public Location north;
    public Location south;
    public Location east;
    public Location west;

    public static Location generateRandomLocation(int enemies)
    {
      Random rand = new Random();
      int number = rand.Next(0, 100);

      if (number >= 0 && number <= 15)
      {
        number = rand.Next(0, EnvNames.namesTown.Count);
        return new Town(EnvNames.namesTown[number]);
      }
      else if (number > 15 && number <= 25)
      {
        number = rand.Next(0, EnvNames.namesForest.Count);
        return new Forest(EnvNames.namesForest[number], enemies);
      }
      else
      {
        number = rand.Next(0, EnvNames.namesForest.Count);
        return new Mountains(EnvNames.namesMountains[number], enemies);
      }
    }

    public void generateSurroundings(int enemies)
    {
      this.north = generateRandomLocation(enemies);
      this.south = generateRandomLocation(enemies);
      this.east = generateRandomLocation(enemies);
      this.west = generateRandomLocation(enemies);
    }
  }
}
