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
    public WorldMap worldMap;
    
    public Game(Player player)
    {
      this.player = player;
      this.worldMap = new WorldMap();
    }
  }
}
