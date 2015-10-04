using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Locations
{
  public static class EnvNames
  {
    public static List<string> namesForest = new List<string>();
    public static List<string> namesMountains= new List<string>();
    public static List<string> namesTown = new List<string>();


    static EnvNames()
    {
      namesForest.Add("Dark Woods");
      namesForest.Add("Mystical Forest");
      namesForest.Add("Ancient Glade");
      namesForest.Add("Forest of Winds");
      namesForest.Add("Silent Woods");
      namesForest.Add("Secluded Forest");
      namesForest.Add("Lost Woods");
      namesForest.Add("Forest of Tall Trees");

      namesMountains.Add("Windy Pass");
      namesMountains.Add("The Wispering Pass");
      namesMountains.Add("Mount Sorry");
      namesMountains.Add("Silent Pass");
      namesMountains.Add("Mount Doom");

      namesTown.Add("Windy Creek");
      namesTown.Add("Cake Town");
      namesTown.Add("Goody Valley");
      namesTown.Add("Townsville");
    }
  }
}
