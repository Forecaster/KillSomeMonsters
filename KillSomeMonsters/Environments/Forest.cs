using KillSomeMonsters.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Environments
{
  public class Forest : Environment
  {
    List<Enemy> enemies = new List<Enemy>();
    
    public Forest(string name)
    {
      this.name = name;
    }
  }
}
