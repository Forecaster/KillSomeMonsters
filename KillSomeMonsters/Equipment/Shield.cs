﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Equipment
{
  public class Shield : Armor
  {
    public Shield(string name) : this(name, 1) { }

    public Shield(string name, int armorBonus) : this(name, armorBonus, 10, 10, 5) { }

    public Shield(string name, int armorBonus, int maxHealth, int health, int value)
    {
      this.name = name;
      this.value = value;
      this.valueModifier = 3;
      this.armorBonus = armorBonus;
      this.maxHealth = maxHealth;
      this.health = health;
    }
  }
}
