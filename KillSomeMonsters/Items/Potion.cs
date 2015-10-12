using KillSomeMonsters.Creatures;
using KillSomeMonsters.Exceptions;
using KillSomeMonsters.StatEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Items
{
  public class Potion : Equipment
  {
    public string color;
    public string texture;
    public string bottle;
    public Effect effect;
    public int magnitude;

    public Potion(string name, Effect effect, int magnitude)
    {
      this.name = name;
      this.effect = effect;
      this.magnitude = magnitude;
      this.color = "color";
      this.texture = "texture";
      this.bottle = "bottle";
      this.value = magnitude * 5;
      this.indestructible = true;
    }

    public Potion(string name, string color, string texture, string bottle, int magnitude)
    {
      this.name = name;
      this.color = color;
      this.texture = texture;
      this.bottle = bottle;
      this.magnitude = magnitude;
      this.value = magnitude * 5;
      this.indestructible = true;
    }

    public Potion(string name, string color, string texture, string bottle, Effect effect, int magnitude)
    {
      this.name = name;
      this.color = color;
      this.texture = texture;
      this.bottle = bottle;
      this.effect = effect;
      this.magnitude = magnitude;
      this.value = magnitude * 5;
      this.indestructible = true;
    }

    public string getEffect()
    {
      return effect.ToString();
    }

    public int drinkPotion(Creature drinker)
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

    public int throwPotion(Creature target)
    {
      int result = 0;
      try
      {
        result = this.effect.activate(target, this.magnitude);
        return result;
      }
      catch (FullHealthException e)
      {
        return result;
      }
    }
  }
}
