using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Locations
{
  public class WorldMap
  {
    public Location[,] locations;
    public WorldMap()
    {
      this.locations = new Location[15, 15];
      this.locations[8, 8] = new Town("Startville", true, true, true);
    }
  }
}
