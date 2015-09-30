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
    public Damage()
    {
      //constructor
    }

    new public int activate(Creature target, int amount)
    {
      if (target.health != 0)
      {
        int health = target.health - amount;
        target.health = Math.Max(health, 0);
        return -1;
      }
      else
        return -1;
    }
  }
}
