using KillSomeMonsters.Creatures;
using KillSomeMonsters.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters
{
  public class Game
  {
    public Player player;
    public Town startingTown;

    public Game()
    {

    }

    public Game(Player player)
    {
      this.startingTown = new Town("Startville", true, 100, true);
      this.player = player;
    }
  }
}
