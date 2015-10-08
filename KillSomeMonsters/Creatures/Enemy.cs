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
      Random rand = new Random();

      this.name = name;
      this.maxHealth = Math.Max((fortitude * 5), 5);
      this.health = this.maxHealth;
      this.fortitude = fortitude;
      this.strength = strength;
      this.speed = speed;
      this.dexterity = dexterity;

      int goldMin = Program.currentGame.player.level * 3;
      int goldMax = Program.currentGame.player.level * 5;
      this.gold = rand.Next(goldMin, goldMax);

      this.weapon = Items.Equipment.generateRandomWeapon(Program.currentGame.player.level);
      this.armor = Items.Equipment.generateRandomBody(Program.currentGame.player.level);
      this.helmet = Items.Equipment.generateRandomHead(Program.currentGame.player.level);
      this.shield = Items.Equipment.generateRandomShield(Program.currentGame.player.level);

      this.shielding = false;
    }

    public string enemyTurn(Player opponent)
    {
      string returnThis = "error";
      List<string> actions = new List<string>();
      actions.Add("Attack");
      if (this.shield != null)
        actions.Add("Defend");
      if (this.health < this.maxHealth)
        actions.Add("Run Away");

      Random rand = new Random();

      int chosenAction = rand.Next(0, actions.Count - 1);

      if (actions[chosenAction] == "Attack")
      {
        Console.WriteLine("The creature lunges at you with a " + this.weapon.name);
        int dexterity = Utility.rollDice(this.dexterity);
        int opponentSpeed = Utility.rollDice(opponent.speed);

        Tuple<int, int, string> result = this.getReducedDamageAgainstArmor(Utility.rollDice(1 + this.strength) + this.getWeaponDamage(), opponent.dexterity);
        if (result.Item3 != "Miss")
        {
          Console.WriteLine("The weapon strikes your " + result.Item3 + " and does " + result.Item1 + " points of damage to you!");
          if (result.Item2 > 0)
            Console.WriteLine("Your armor absorbed " + result.Item2 + " damage.");
          opponent.applyDamage(result.Item1);
          returnThis = "damageHit";
        }
        else
        {
          Console.WriteLine("You manage to dodge the creature and turn to face it!");
          returnThis = "damageDodge";
        }
      }
      else if (actions[chosenAction] == "Defend")
      {
        Console.WriteLine("The creature brings it's shield up into a defensive stance");
        this.shielding = true;
        returnThis = "defend";
      }
      else if (actions[chosenAction] == "Run Away")
      {
        int speed = Utility.rollDice(this.speed);
        int opponentSpeed = Utility.rollDice(opponent.speed);

        if (speed > opponentSpeed)
        {
          Console.WriteLine("The creature starts to run away, you follow but loose it after a little bit!");
          returnThis = "escapeSuccess";
        }
        else
        {
          Console.WriteLine("The creature tries to run away, but you catch up and block it's path!");
          returnThis = "escapeFail";
        }
      }
      Console.WriteLine("...");
      Console.ReadKey();
      return returnThis;
    }
  }
}
