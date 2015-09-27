using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Locations
{
  public class Town : Location
  {
    public bool hasMerchant;
    public int merchantGold;
    public bool hasInn;
    public bool hasSewers;
    public Sewers sewers;

    public Town(string name) : this(name, false, 0, false) { }
    
    public Town(string name, bool hasMerchant, int merchantGold) : this(name, hasMerchant, merchantGold, false) { }

    public Town(string name, bool hasMerchant, int merchantGold, bool hasInn)
    {
      this.name = name;
      this.genericName = "Town";
      this.hasMerchant = hasMerchant;
      this.merchantGold = merchantGold;
      this.hasInn = hasInn;

      Random rand = new Random();
      int number = rand.Next(0, 100);

      if (number >= 0 && number <= 25)
      {
        //this.sewers = new Sewers();
        this.hasSewers = true;
      }
      else
        this.hasSewers = false;
    }
  }
}
