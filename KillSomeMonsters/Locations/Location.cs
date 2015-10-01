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
    public bool visited;

    public List<Enemy> enemies = new List<Enemy>();

    public Location north;
    public Location south;
    public Location east;
    public Location west;

    public static Location generateRandomLocation(int enemies)
    {
      Random rand = new Random();
      int number = rand.Next(0, 100);

      if (0 <= number && number <= 25)
      {
        number = rand.Next(0, EnvNames.namesTown.Count - 1);
        //Console.WriteLine("Generated Town");
        //Console.ReadKey();
        return new Town(EnvNames.namesTown[number]);
      }
      else if (25 < number && number <= 60)
      {
        number = rand.Next(0, EnvNames.namesForest.Count - 1);
        //Console.WriteLine("Generated Forest");
        //Console.ReadKey();
        return new Forest(EnvNames.namesForest[number], enemies);
      }
      else
      {
        number = rand.Next(0, EnvNames.namesMountains.Count - 1);
        //Console.WriteLine("Generated Mountains");
        //Console.ReadKey();
        return new Mountains(EnvNames.namesMountains[number], enemies);
      }
    }

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
  }
}
