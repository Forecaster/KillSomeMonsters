using KillSomeMonsters.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Environments
{
  abstract class Environment
  {
    public string name;

    public Environment north;
    public Environment south;
    public Environment east;
    public Environment west;

    public static Environment generateRandomEnvironment()
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
        return new Forest(EnvNames.namesForest[number]);
      }
      else if (number > 25 && number <= 50)
      {
        number = rand.Next(0, EnvNames.namesForest.Count);
        return new Mountains();
      }
    }
  }
}
