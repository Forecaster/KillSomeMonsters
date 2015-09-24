using KillSomeMonsters.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Environments
{
  class Sewers : Environment
  {
    public List<Enemy> enemies = new List<Enemy>();

    public Sewers(string name, int enemies)
    {
      this.name = name;
    }
  }
}
