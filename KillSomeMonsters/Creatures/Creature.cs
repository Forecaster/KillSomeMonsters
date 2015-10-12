using KillSomeMonsters.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Creatures
{
  public class Creature
  {
    //Name
    public string name;

    //level
    public int level = 1;

    //Stats
    public int health;
    public int maxHealth;
    public int fortitude;
    public int strength;
    public int speed;
    public int dexterity;

    public bool shielding;

    //Equipment
    public Head helmet;
    public Body armor;
    public Shield shield;
    public Weapon weapon;
    public List<Potion> potions = new List<Potion>();

    //misc
    public int gold;

    public string getGeneralHealth()
    {
      double healthPercentage = (this.health / this.maxHealth) * 100;
      if (healthPercentage == 100)
        return "healthy";
      else if (healthPercentage < 75)
        return "slightly hurt";
      else if (healthPercentage < 50)
        return "wounded";
      else if (healthPercentage < 25)
        return "badly wounded";
      else if (healthPercentage < 0)
        return "dying";
      else
        return "dead";
    }

    /*
     * Returns the weapon damage if a weapon is present, or 0 if the creature does not have a weapon.
     */
    public int getWeaponDamage()
    {
      if (this.weapon != null)
        return this.weapon.damage;
      else
        return 0;
    }

    /*
     * Calculates hit location and applies relevant damage reduction depending on armor and blocking
     * Returns damage after reduction as well as hit location
     */
    public Tuple<int, int, string> getReducedDamageAgainstArmor(int initialDamage, int opponentDexterity)
    {
      List<string> hitLocations = new List<string>();
      Utility.debugMsg("Determining opponent dexterity");
      opponentDexterity = Utility.rollDice(1 + opponentDexterity);
      Utility.debugMsg("Determining my speed");
      int speed = Utility.rollDice(1 + this.speed);
      hitLocations.Add("Head");
      hitLocations.Add("Body");
      if (this.shielding)
        hitLocations.Add("Shield");

      Console.WriteLine("initialDamage: " + initialDamage);

      Random rand = new Random();
      int hitChancePenalty;
      if (opponentDexterity > speed) //If opponent dexterity is greater than my speed opponent gets no penalty to hit
        hitChancePenalty = 0;
      else
        hitChancePenalty = speed - opponentDexterity; //If opponent dexterity is less than my speed the difference is used as the penalty to hit

      int hitChanceMax = (hitLocations.Count - 1) + hitChancePenalty + 2;
      int hit = rand.Next(0, hitChanceMax);

      if (hit >= hitLocations.Count)
        return Tuple.Create(0, 0, "Miss");
      else if (hitLocations[hit] == "Head")
      {
        int reduction = this.helmet.armorBonus;
        int damage = Math.Max(1, initialDamage - reduction);
        this.helmet.takeDamage(damage);
        return Tuple.Create(initialDamage, reduction, hitLocations[hit]);
      }
      else if (hitLocations[hit] == "Body")
      {
        int reduction = this.armor.armorBonus;
        int damage = Math.Max(1, initialDamage - reduction);
        this.armor.takeDamage(damage);
        return Tuple.Create(initialDamage, reduction, hitLocations[hit]);
      }
      else if (hitLocations[hit] == "Shield")
      {
        int reduction = this.shield.armorBonus;
        int damage = Math.Max(1, initialDamage - reduction);
        this.shield.takeDamage(damage);
        return Tuple.Create(initialDamage, reduction, hitLocations[hit]);
      }
      else
        return Tuple.Create(0, 0, "Miss");
    }

    public void applyDamage(int amount)
    {
      this.health = Math.Max(0, this.health - amount);
    }
  }
}
