using KillSomeMonsters.Items;
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
    public Merchant merchant;
    public bool hasInn;
    public bool hasSewer;
    public Sewer sewer;

    public Town(string name) : this(name, false, false, false) { }
    
    public Town(string name, bool hasMerchant) : this(name, hasMerchant, false, false) { }

    public Town(string name, bool hasMerchant, bool hasInn) : this(name, hasMerchant, hasInn, false) { }

    public Town(string name, bool hasMerchant, bool hasInn, bool visited)
    {
      this.name = name;
      this.genericName = "town";
      this.genericPlural = "towns";
      this.genericDescription = new List<string>();
      this.genericDescription.Add("You find yourself in the town sqare of {0}.\nA few people are moving about the town square.");
      this.genericDescription.Add("A quiet little town by the name of {0} finds itself graced by your precense.");

      this.hasMerchant = hasMerchant;
      this.hasInn = hasInn;

      if (hasMerchant)
        if (Program.currentGame == null)
          this.merchant = new Merchant(1);
        else
          this.merchant = new Merchant(Program.currentGame.player.level);

      this.visited = visited;

      Random rand = new Random();
      int number = rand.Next(0, 100);

      if (number >= 0 && number <= 25)
        this.hasSewer = true;
      else
        this.hasSewer = false;
    }
  }
}
