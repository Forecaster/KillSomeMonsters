using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Equipment
{
  public class Body : Armor
  {
    public Body(string name) : this(name, 1, 1) { }

    public Body(string name, int value, int armorBonus) : this(name, value, armorBonus, 20) { }

    public Body(string name, int value, int armorBonus, int maxHealth)
    {
      this.name = name;
      this.value = value;
      this.valueLoss = 0.0;
      this.armorBonus = armorBonus;
      this.maxHealth = maxHealth;
      this.health = maxHealth;
      this.shattered = false;
    }
  }
}
