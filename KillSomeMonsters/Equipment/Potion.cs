using KillSomeMonsters.Entities;
using KillSomeMonsters.Exceptions;
using KillSomeMonsters.StatEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Equipment
{
  class Potion
  {
    string name;
    string color;
    string texture;
    string bottle;
    Effect effect;
    int magnitude;

    public Potion(string name, string color, string texture, string bottle, Effect effect, int magnitude)
    {
      this.name = name;
      this.color = color;
      this.texture = texture;
      this.bottle = bottle;
      this.effect = effect;
      this.magnitude = magnitude;
    }

    public int drinkPotion(Entity drinker)
    {
      int result;
      try
      {
        result = this.effect.activate(drinker, this.magnitude);
        return result;
      }
      catch (FullHealthException e)
      {

      }

    }

    public bool drinkPotion(Entity target)
    {

    }
  }
}
