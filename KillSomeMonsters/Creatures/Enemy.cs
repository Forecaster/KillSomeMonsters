using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Creatures
{
  public class Enemy : Creature
  {
    public Enemy(string name) : this(name, 1, 1, 1, 1) { }

    public Enemy(string name, int fortitude, int strength, int speed, int dexterity)
    {
      this.name = name;
      this.maxHealth = Math.Max((fortitude * 5), 5);
      this.health = this.maxHealth;
      this.fortitude = fortitude;
      this.strength = strength;
      this.speed = speed;
      this.dexterity = dexterity;
    }
  }
}
