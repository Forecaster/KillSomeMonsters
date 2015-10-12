using KillSomeMonsters.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.StatEffects
{
    /**
   * This effect applies damage to a target
   */
  public class Damage : Effect
  {
    public Damage(int magnitude) : this(magnitude, 0) { }

    public Damage(int magnitude, int duration)
    {
      this.magnitude = magnitude;
      this.duration = duration;
    }
    
    public override int activate(Creature target)
    {
      if (this.duration > 0)
        this.duration--;

      if (target.health != 0)
      {
        int initialHealth = target.health;
        int health = initialHealth - this.magnitude;
        target.health = Math.Max(health, 0);
        int diff = initialHealth - health;
        return diff;
      }
      else
        return 0;
    }
  }
}
