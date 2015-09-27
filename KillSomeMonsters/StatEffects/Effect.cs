using KillSomeMonsters.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.StatEffects
{
  public abstract class Effect
  {
    public static Heal HEAL;
    public static Damage DAMAGE;

    static Effect()
    {
      HEAL = new Heal();
      DAMAGE = new Damage();
    }

    public int activate(Entity target, int amount)
    {
      //dummy method
      return -5;
    }
  }
}
