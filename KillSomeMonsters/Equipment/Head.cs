using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Equipment
{
  public class Head : Armor
  {
    public Head(string name) : this(name, 1, 1) { }

    public Head(string name, int value, int armorBonus) : this(name, value, armorBonus, 20) { }

    public Head(string name, int value, int armorBonus, int maxHealth)
    {
      this.name = name;
      this.value = value;
      this.armorBonus = armorBonus;
      this.maxHealth = maxHealth;
      this.health = maxHealth;
      this.shattered = false;
    }
  }
}
