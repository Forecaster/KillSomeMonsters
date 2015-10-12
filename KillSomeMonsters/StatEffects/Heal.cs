using KillSomeMonsters.Creatures;
using KillSomeMonsters.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.StatEffects
{
  public class Heal : Effect
  {
    public Heal(int magnitude) : this(magnitude, 0) { }

    public Heal(int magnitude, int duration)
    {
      this.magnitude = magnitude;
      this.duration = duration;
    }

    public override int activate(Creature target)
    {
      if (this.duration > 0)
        this.duration--;

      if (target.health < target.maxHealth)
      {
        int initialHealth = target.health;
        target.health = Math.Min((initialHealth + magnitude), target.maxHealth);
        int diff = target.health - initialHealth;

        return diff;
      }
      else
        throw new EffectException("Target has full health already!");
    }
  }
}
