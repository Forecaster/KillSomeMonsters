using KillSomeMonsters.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.StatEffects
{
  public abstract class Effect
  {
    public int duration;
    public int magnitude;

    static Effect()
    {
      //constructor
    }

    public virtual int activate(Creature target)
    {
      //dummy method that should never be called
      return -5;
    }
  }
}
