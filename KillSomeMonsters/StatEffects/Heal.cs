using KillSomeMonsters.Entities;
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
    public Heal()
    {
      //constructor
    }

    new public int activate(Entity target, int amount)
    {
      if (target.health < target.maxHealth)
      {
        int diff = Math.Min((target.maxHealth - target.health), amount);
        int health = target.health + amount;

        target.health = Math.Min(health, target.maxHealth);
        return diff;
      }
      else
        throw new FullHealthException("Target has full health already!");
    }
  }
}
