using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Creatures
{
  public class Enemy : Creature
  {
    public Enemy(string name) : this(name, 1, 1, 1, 1) { }

    public Enemy(string name, int fortitude, int strength, int speed, int dexterity)
    {
      this.name = name;
      this.maxHealth = Math.Max((fortitude * 5), 5);
      this.health = this.maxHealth;
      this.fortitude = fortitude;
      this.strength = strength;
      this.speed = speed;
      this.dexterity = dexterity;

      this.shielding = false;
    }

    public string enemyTurn(Player opponent)
    {
      string result = "error";
      List<string> actions = new List<string>();
      actions.Add("Attack");
      if (this.shield != null)
        actions.Add("Defend");
      actions.Add("Run Away");

      Random rand = new Random();

      int chosenAction = rand.Next(0, actions.Count - 1);

      if (actions[chosenAction] == "Attack")
      {
        Console.WriteLine("The creature lunges at you with a " + this.weapon.name);
        int dexterity = Utility.rollDice(this.dexterity);
        int opponentSpeed = Utility.rollDice(opponent.speed);

        if (dexterity >= opponentSpeed)
        {
          int damage = this.getReducedDamageAgainstArmor(Utility.rollDice(this.strength) + this.getWeaponDamage());
          Console.WriteLine("The weapon strikes you and does " + damage + " points of damage to you!");
          opponent.applyDamage(damage);
          result = "damageHit";
        }
        else
        {
          Console.WriteLine("You manage to dodge the creature and turn to face it!");
          result = "damageDodge";
        }
      }
      else if (actions[chosenAction] == "Defend")
      {
        Console.WriteLine("The creature brings it's shield up into a defensive stance");
        this.shielding = true;
        result = "defend";
      }
      else if (actions[chosenAction] == "Run Away")
      {
        int speed = Utility.rollDice(this.speed);
        int opponentSpeed = Utility.rollDice(opponent.speed);

        if (speed > opponentSpeed)
        {
          Console.WriteLine("The creature starts to run away, you follow but loose it after a little bit!");
          result = "escapeSuccess";
        }
        else
        {
          Console.WriteLine("The creature tries to run away, but you catch up and block it's path!");
          result = "escapeFail";
        }
      }
      Console.WriteLine("...");
      Console.ReadKey();
      return result;
    }
  }
}
