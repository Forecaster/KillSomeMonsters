using KillSomeMonsters.StatEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Items
{
  public abstract class Equipment
  {
    public string name;
    public int value; //item value in "gold"
    public int valueModifier; //value modifier per point of health lost (cost = health repaired * valueModifier)
    public int maxHealth;
    public int health;
    public bool indestructible;

    /*
     * Damage equipment by amount
     */
    public bool takeDamage(int amount)
    {
      if (!this.indestructible)
      {
        if (this.health > 0)
        {
          int health = this.health - amount;

          this.health = Math.Max(health, 0);
          return true;
        }
        else
          return false;
      }
      else
        return false;
    }

    /*
     * Repair equipment by amount to a maximum of amount
     * Returns repair cost
     */
    public int repair(int amount)
    {
      if (this.health < this.maxHealth)
      {
        int cost = Math.Min((this.maxHealth - this.health), amount);

        int health = this.health + amount;

        this.health = Math.Min(health, this.maxHealth);
        return cost * this.valueModifier;
      }
      else
        return 0;
    }

    /*
     * The following 3 methods generate starting equipment (for the player)
     */
    public static Weapon getDefaultWeapon()
    {
      return new Weapon("Fists", 0, 0, 0, 0, true);
    }

    public static Body getDefaultBody()
    {
      return new Body("Plaid Shirt", 0, 0, 0, 0, true);
    }

    public static Head getDefaultHead()
    {
      return new Head("Hair", 0, 0, 0, 0, true);
    }

    public static Weapon generateRandomWeapon(int level)
    {
      Random rand = new Random();

      int nameId = rand.Next(0, EquNames.namesWeapon.Count - 1);
      int damage = Math.Max(rand.Next(level - 1, level + 1), 1);
      int maxHealth = rand.Next(level * 3, level * 4);
      int health = Math.Max(rand.Next(maxHealth - 3, maxHealth), 5);
      int value = rand.Next(maxHealth + damage + 2, maxHealth + damage + 4);

      return new Weapon(EquNames.namesWeapon[nameId], damage, maxHealth, health, value);
    }

    public static Shield generateRandomShield(int level)
    {
      Random rand = new Random();

      int nameId = rand.Next(0, EquNames.namesShield.Count - 1);
      int armor = Math.Max(rand.Next(level - 2, level), 1);
      int maxHealth = rand.Next(level * 3, level * 4);
      int health = Math.Max(rand.Next(maxHealth - 3, maxHealth), 5);
      int value = rand.Next(maxHealth + armor + 2, maxHealth + armor + 4);

      return new Shield(EquNames.namesShield[nameId], armor, maxHealth, health, value);
    }

    public static Head generateRandomHead(int level)
    {
      Random rand = new Random();

      int nameId = rand.Next(0, EquNames.namesHead.Count - 1);
      int armor = Math.Max(rand.Next(level - 2, level), 1);
      int maxHealth = rand.Next(level * 3, level * 4);
      int health = Math.Max(rand.Next(maxHealth - 3, maxHealth), 5);
      int value = rand.Next(maxHealth + armor + 2, maxHealth + armor + 4);

      return new Head(EquNames.namesHead[nameId], armor, maxHealth, health, value);
    }

    public static Body generateRandomBody(int level)
    {
      Random rand = new Random();

      int nameId = rand.Next(0, EquNames.namesBody.Count - 1);
      int armor = Math.Max(rand.Next(level - 2, level), 1);
      int maxHealth = rand.Next(level * 3, level * 4);
      int health = Math.Max(rand.Next(maxHealth - 3, maxHealth), 5);
      int value = rand.Next(maxHealth + armor + 2, maxHealth + armor + 4);

      return new Body(EquNames.namesBody[nameId], armor, maxHealth, health, value);
    }

    public static Potion generateRandomPotion(int level)
    {
      Random rand = new Random();
      string name = "Unknown Potion";

      int magnitude = Math.Max(rand.Next(level - 1, level + 1), 1);

      Effect effect = Utility.getRandomEffect(magnitude, 0);

      if (effect is Heal)
        name = EquNames.namesPotionHeal[rand.Next(0, EquNames.namesPotionHeal.Count - 1)];
      else if (effect is Damage)
        name = EquNames.namesPotionDamage[rand.Next(0, EquNames.namesPotionHeal.Count - 1)];

      return new Potion(name, effect);
    }
  }
}