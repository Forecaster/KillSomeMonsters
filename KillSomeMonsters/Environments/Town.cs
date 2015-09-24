using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Environments
{
  class Town : Environment
  {
    public bool hasMerchant;
    public bool hasInn;
    public bool hasSewers;
    public Sewers sewers;

    public Town(string name) : this(name, false, false) { }
    
    public Town(string name, bool hasMerchant) : this(name, hasMerchant, false) { }

    public Town(string name, bool hasMerchant, bool hasInn)
    {
      this.name = name;
      this.hasMerchant = hasMerchant;
      this.hasInn = hasInn;

      Random rand = new Random();
      int number = rand.Next(0, 100);

      if (number >= 0 && number <= 25)
      {
        this.sewers = new Sewers();
        this.hasSewers = true;
      }
      else
        this.hasSewers = false;
    }
  }
}
