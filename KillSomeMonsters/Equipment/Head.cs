using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Equipment
{
  class Head : Armor
  {
    public Head(string name) : this(name, 2, 20) { }

    public Head(string name, int armorBonus) : this(name, armorBonus, 20) { }

    public Head(string name, int armorBonus, int maxHealth)
    {
      this.name = name;
      this.armorBonus = armorBonus;
      this.maxHealth = maxHealth;
      this.health = maxHealth;
      this.shattered = false;
    }
  }
}
