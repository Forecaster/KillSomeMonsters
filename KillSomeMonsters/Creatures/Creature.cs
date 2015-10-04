using KillSomeMonsters.Equipment;
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
    public List<Potion> potion = new List<Potion>();

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
     */
    public int getReducedDamageAgainstArmor(int damage)
    {
      Random rand = new Random();
      int hitLocation = rand.Next(0, 2);

      if (hitLocation == 0 && this.helmet != null)
        return Math.Max(1, (damage - this.helmet.armorBonus));
      else if (hitLocation == 1 && this.armor != null)
        return Math.Max(1, (damage - this.armor.armorBonus));
      else if (hitLocation == 2 && this.shield != null && this.shielding)
        return Math.Max(1, (damage - this.shield.armorBonus));
      else
        return damage;
    }

    public void applyDamage(int amount)
    {
      this.health = Math.Max(0, this.health - amount);
    }
  }
}
