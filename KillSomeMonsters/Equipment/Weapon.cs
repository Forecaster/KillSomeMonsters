using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Equipment
{
  public class Weapon : Equipment
  {
    public int damage;

    public Weapon(string name) : this(name, 1, 1) { }

    public Weapon(string name, int value, int damage) : this(name, value, damage, 20) { }

    public Weapon(string name, int value, int damage, int maxHealth)
    {
      this.name = name;
      this.value = value;
      this.valueLoss = 0.0;
      this.damage = damage;
      this.maxHealth = maxHealth;
      this.health = maxHealth;
      this.shattered = false;
    }
  }
}