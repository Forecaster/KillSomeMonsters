using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Locations
{
  public abstract class Direction
  {
    public static North NORTH;
    public static East EAST;
    public static West WEST;
    public static South SOUTH;
    static Direction()
    {
      NORTH = new North();
      EAST = new East();
      WEST = new West();
      SOUTH = new South();
    }
  }

  public class North : Direction
  {
    public North() { }

    public Direction reverse()
    {
      return Direction.SOUTH;
    }
  }

  public class East : Direction
  {
    public East() { }

    public Direction reverse()
    {
      return Direction.WEST;
    }
  }

  public class West : Direction
  {
    public West() { }

    public Direction reverse()
    {
      return Direction.EAST;
    }
  }

  public class South : Direction
  {
    public South() { }

    public Direction reverse()
    {
      return Direction.NORTH;
    }
  }
}
