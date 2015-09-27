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
  public class Potion
  {
    string name;
    string color;
    string texture;
    string bottle;
    Effect effect;
    int magnitude;

    public Potion(string name, Effect effect, int magnitude)
    {
      this.name = name;
      this.effect = effect;
      this.magnitude = magnitude;
      this.color = "color";
      this.texture = "texture";
      this.bottle = "bottle";
    }

    public Potion(string name, string color, string texture, string bottle, int magnitude)
    {
      this.name = name;
      this.color = color;
      this.texture = texture;
      this.bottle = bottle;
      this.magnitude = magnitude;
    }

    public Potion(string name, string color, string texture, string bottle, Effect effect, int magnitude)
    {
      this.name = name;
      this.color = color;
      this.texture = texture;
      this.bottle = bottle;
      this.effect = effect;
      this.magnitude = magnitude;
    }

    public string getEffect()
    {
      return effect.ToString();
    }

    public int drinkPotion(Entity drinker)
    {
      int result = 0;
      try
      {
        result = this.effect.activate(drinker, this.magnitude);
        return result;
      }
      catch (FullHealthException e)
      {
        return result;
      }

    }

    public bool throwPotion(Entity target)
    {
      return false;
    }
  }
}
