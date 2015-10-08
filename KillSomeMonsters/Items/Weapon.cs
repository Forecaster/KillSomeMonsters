using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Items
{
  public class Weapon : Equipment
  {
    public int damage;

    public Weapon(string name) : this(name, 1) { }

    public Weapon(string name, int damage) : this(name, damage, 10, 10, 5) { }

    public Weapon(string name, int damage, int maxHealth, int health, int value) : this(name, damage, maxHealth, health, value, false) { }

    public Weapon(string name, int damage, int maxHealth, int health, int value, bool indestructible)
    {
      this.name = name;
      this.value = value;
      this.valueModifier = 2;
      this.damage = damage;
      this.maxHealth = maxHealth;
      this.health = health;
      this.indestructible = indestructible;
    }
  }
}