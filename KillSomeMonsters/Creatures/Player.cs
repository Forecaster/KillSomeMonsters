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

      this.x = 8;
      this.y = 8;
      this.experience = 0;
    }

    public bool movePlayer(Direction direction)
    {
      if (direction == Direction.NORTH)
      {
        if (this.y < Program.worldSizeY)
        {
          Location destination = Program.currentGame.worldMap.locations[this.x, this.y];
          if (destination == null)
            Program.currentGame.worldMap.locations[this.x, this.y] = Location.generateRandomLocation(Program.enemiesPerLocation);
          this.y++;
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
          Location destination = Program.currentGame.worldMap.locations[this.x, this.y];
          if (destination == null)
            Program.currentGame.worldMap.locations[this.x, this.y] = Location.generateRandomLocation(Program.enemiesPerLocation);
          this.x--;
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
          Location destination = Program.currentGame.worldMap.locations[this.x, this.y];
          if (destination == null)
            Program.currentGame.worldMap.locations[this.x, this.y] = Location.generateRandomLocation(Program.enemiesPerLocation);
          this.x++;
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
          Location destination = Program.currentGame.worldMap.locations[this.x, this.y];
          if (destination == null)
            Program.currentGame.worldMap.locations[this.x, this.y] = Location.generateRandomLocation(Program.enemiesPerLocation);
          this.y--;
          this.lastMove = direction;
          return true;
        }
        else
          return false;
      }
      return false;
    }
  }
}
