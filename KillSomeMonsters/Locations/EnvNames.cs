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
      namesForest.Add("A Mystical Forest");
      namesForest.Add("An Ancient Glade");
      namesForest.Add("A Forest of Winds");
      namesForest.Add("Silent Woods");
      namesForest.Add("A Secluded Forest");
      namesForest.Add("A Deep Forest");
      namesForest.Add("A Forest of Tall Trees");

      namesMountains.Add("A Windy Pass");
      namesMountains.Add("A Deep Crevice");
      namesMountains.Add("A Tall Mountain");
      namesMountains.Add("A Narrow Pass");
      namesMountains.Add("A Volcano");

      namesTown.Add("Windy Creek");
      namesTown.Add("Cake Town");
      namesTown.Add("Goody Valley");
      namesTown.Add("Townsville");
    }
  }
}
