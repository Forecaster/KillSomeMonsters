﻿using KillSomeMonsters.Creatures;
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

    public virtual int activate(Creature target, int amount)
    {
      //dummy method that should never be called
      return -5;
    }
  }
}
