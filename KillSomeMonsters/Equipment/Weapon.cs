using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Equipment
{
  class Weapon : Equipment
  {
    int damage;

    public Weapon(string name) : this(name, 2, 20) { }

    public Weapon(string name, int damage) : this(name, damage, 20) { }

    public Weapon(string name, int damage, int maxHealth)
    {
      this.name = name;
      this.damage = damage;
      this.maxHealth = maxHealth;
      this.health = maxHealth;
      this.shattered = false;
    }
  }
}