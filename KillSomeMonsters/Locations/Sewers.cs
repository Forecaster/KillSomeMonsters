using KillSomeMonsters.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Locations
{
  public class Sewers : Location
  {
    public Sewers(string name, int enemies)
    {
      this.name = name;
      this.genericName = "sewer";
      this.genericPlural = "sewers";

      for (int i = 0; i < enemies; i++)
      {
        this.enemies.Add(new Enemy("Some enemy"));
      }
    }
  }
}
