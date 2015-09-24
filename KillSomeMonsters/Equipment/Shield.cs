using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Equipment
{
  class Shield : Armor
  {
    int armorBonus;

    public Shield(string name) : this(name, 2, 20) { }

    public Shield(string name, int armorBonus) : this(name, armorBonus, 20) { }

    public Shield(string name, int armorBonus, int maxHealth)
    {
      this.name = name;
      this.armorBonus = armorBonus;
      this.maxHealth = maxHealth;
      this.health = maxHealth;
      this.shattered = false;
    }
  }
}
