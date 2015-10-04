using KillSomeMonsters.Equipment;
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
      this.maxHealth = Math.Max((fortitude * 5), 5);
      this.health = this.maxHealth;
      this.fortitude = fortitude;
      this.strength = strength;
      this.speed = speed;
      this.dexterity = dexterity;

      this.shielding = false;

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
            Location destination = Program.currentGame.worldMap.locations[this.x, this.y + 1];
            if (destination == null)
              Program.currentGame.worldMap.locations[this.x, this.y] = Location.generateRandomLocation(Program.enemiesPerLocationMin, Program.enemiesPerLocationMax);
            this.y++;
            destination.arrive();
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
            Location destination = Program.currentGame.worldMap.locations[this.x + 1, this.y];
            if (destination == null)
              Program.currentGame.worldMap.locations[this.x, this.y] = Location.generateRandomLocation(Program.enemiesPerLocationMin, Program.enemiesPerLocationMax);
            this.x++;
            destination.arrive();
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
            Location destination = Program.currentGame.worldMap.locations[this.x - 1, this.y];
            if (destination == null)
              Program.currentGame.worldMap.locations[this.x, this.y] = Location.generateRandomLocation(Program.enemiesPerLocationMin, Program.enemiesPerLocationMax);
            this.x--;
            destination.arrive();
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
            Location destination = Program.currentGame.worldMap.locations[this.x, this.y - 1];
            if (destination == null)
              Program.currentGame.worldMap.locations[this.x, this.y] = Location.generateRandomLocation(Program.enemiesPerLocationMin, Program.enemiesPerLocationMax);
            this.y--;
            destination.arrive();
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
