using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Equipment
{
  class Equipment
  {
    public string name;
    public int maxHealth;
    public int health;
    public bool shattered;

    /**
     * Damage armor by amount
     * If health reaches zero the equipment will shatter
     **/
    public bool takeDamage(int amount)
    {
      if (!this.shattered || this.health == 0)
      {
        int health = this.health - amount;

        this.health = Math.Max(health, 0);

        if (this.health == 0)
          this.shattered = true;

        return true;
      }
      else
        return false;
    }

    public int repair(int amount)
    {
      if (this.health < this.maxHealth)
      {
        int diff = Math.Min((this.maxHealth - this.health), amount);

        int health = this.health + amount;

        this.health = Math.Min(health, this.maxHealth);

        if (this.health > 0)
          this.shattered = false;

        return diff;
      }
      else
        return 0;
    }
  }
}
