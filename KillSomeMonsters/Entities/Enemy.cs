using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Entities
{
  public class Enemy : Entity
  {
    public Enemy(string name) : this(name, 20) { }

    public Enemy(string name, int maxHealth) : this(name, maxHealth, 1, 1, 1) { }

    public Enemy(string name, int maxHealth, int strength, int speed, int dexterity)
    {
      this.name = name;
      this.maxHealth = maxHealth;
      this.health = maxHealth;
      this.strength = strength;
      this.speed = speed;
      this.dexterity = dexterity;
    }
  }
}
