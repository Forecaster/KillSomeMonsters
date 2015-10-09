using KillSomeMonsters.Items;
using KillSomeMonsters.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Creatures
{
  public class Player : Creature
  {
    public int x;
    public int y;
    public int experience;

    public Direction lastMove;

    public Player(string name) : this(name, 1, 1, 1, 1) { }

    public Player(string name, int fortitude, int strength, int speed, int dexterity)
    {
      this.name = name;
      this.maxHealth = (1 + fortitude) * 5;
      this.health = this.maxHealth;
      this.fortitude = fortitude;
      this.strength = strength;
      this.speed = speed;
      this.dexterity = dexterity;

      this.shielding = false;

      this.weapon = Items.Equipment.getDefaultWeapon();
      this.armor = Items.Equipment.getDefaultBody();
      this.helmet = Items.Equipment.getDefaultHead();

      this.x = 8;
      this.y = 8;
      this.experience = 0;
    }

    public bool movePlayer(Direction direction)
    {
      if (Program.currentGame.worldMap.locations[this.x, this.y].enemies.Count == 0 || this.lastMove == direction.reverse())
      {
        if (direction == Direction.NORTH)
        {
          if (this.y < Program.worldSizeY)
          {
            this.y++;
            if (Program.currentGame.worldMap.locations[this.x, this.y] == null)
              Program.currentGame.worldMap.locations[this.x, this.y] = Location.generateRandomLocation(Program.enemiesPerLocationMin, Program.enemiesPerLocationMax);
            Program.currentGame.worldMap.locations[this.x, this.y].arrive();
            this.lastMove = direction;
            return true;
          }
          else
            return false;
        }
        else if (direction == Direction.EAST)
        {
          if (this.x > 0)
          {
            this.x++;
            if (Program.currentGame.worldMap.locations[this.x, this.y] == null)
              Program.currentGame.worldMap.locations[this.x, this.y] = Location.generateRandomLocation(Program.enemiesPerLocationMin, Program.enemiesPerLocationMax);
            Program.currentGame.worldMap.locations[this.x, this.y].arrive();
            this.lastMove = direction;
            return true;
          }
          else
            return false;
        }
        else if (direction == Direction.WEST)
        {
          if (this.x < Program.worldSizeX)
          {
            this.x--;
            if (Program.currentGame.worldMap.locations[this.x, this.y] == null)
              Program.currentGame.worldMap.locations[this.x, this.y] = Location.generateRandomLocation(Program.enemiesPerLocationMin, Program.enemiesPerLocationMax);
            Program.currentGame.worldMap.locations[this.x, this.y].arrive();
            this.lastMove = direction;
            return true;
          }
          else
            return false;
        }
        else if (direction == Direction.SOUTH)
        {
          if (this.y > 0)
          {
            this.y--;
            if (Program.currentGame.worldMap.locations[this.x, this.y] == null)
              Program.currentGame.worldMap.locations[this.x, this.y] = Location.generateRandomLocation(Program.enemiesPerLocationMin, Program.enemiesPerLocationMax);
            Program.currentGame.worldMap.locations[this.x, this.y].arrive();
            this.lastMove = direction;
            return true;
          }
        }
        return false;
      }
      else
      {
        //I don't really want this here, but the current way this works doesn't allow for sending a signal back to indicate why the move wasn't allowed.
        Console.WriteLine("Moving through the area would be unsafe, you should clear out the monsters first.");
        Console.WriteLine("...");
        Console.ReadKey();
        return false;
      }
    }
  }

  public static class playerNames
  {
    public static List<string> names = new List<string>();
    static playerNames()
    {
      names.Add("Grognax the Barbarian");
      names.Add("Carl");
      names.Add("Steve the Bloodthirsty");
      names.Add("Glory the Amazon");
    }

    public static string getRandomPlayerName()
    {
      Random rand = new Random();
      int number = rand.Next(0, names.Count - 1);

      return names[number];
    }
  }
}
