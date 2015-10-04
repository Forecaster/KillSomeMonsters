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
    public bool hasSewer;
    public Sewer sewer;

    public Town(string name) : this(name, false, 0, false, false) { }
    
    public Town(string name, bool hasMerchant, int merchantGold) : this(name, hasMerchant, merchantGold, false, false) { }

    public Town(string name, bool hasMerchant, int merchantGold, bool hasInn) : this(name, hasMerchant, merchantGold, hasInn, false) { }

    public Town(string name, bool hasMerchant, int merchantGold, bool hasInn, bool visited)
    {
      this.name = name;
      this.genericName = "town";
      this.genericPlural = "towns";
      this.genericDescription = new List<string>();
      this.genericDescription.Add("You find yourself in the town sqare of {0}.\nA few people are moving about the town square.");
      this.genericDescription.Add("A quiet little town by the name of {0} finds itself graced by your precense.");

      this.hasMerchant = hasMerchant;
      this.merchantGold = merchantGold;
      this.hasInn = hasInn;

      this.visited = visited;

      Random rand = new Random();
      int number = rand.Next(0, 100);

      if (number >= 0 && number <= 25)
      {
        this.sewer = new Sewer(Program.enemiesPerLocationMin, Program.enemiesPerLocationMax);
        this.hasSewer = true;
      }
      else
        this.hasSewer = false;
    }
  }
}
