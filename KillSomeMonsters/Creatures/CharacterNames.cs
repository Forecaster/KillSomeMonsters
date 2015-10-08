using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Creatures
{
  public static class CharacterNames
  {
    public static List<string> namesEnemies = new List<string>();
    public static List<string> namesMerhcants = new List<string>();

    static CharacterNames()
    {
      namesEnemies.Add("Brick Troll");
      namesEnemies.Add("Small Ent");
      namesEnemies.Add("Brigand");
      namesEnemies.Add("Wolf");
      namesEnemies.Add("Ghost");
      namesEnemies.Add("Ghast");
      namesEnemies.Add("Swarm of Bees");
      namesEnemies.Add("Alien Shrubbery");
      namesEnemies.Add("Pixie");
      namesEnemies.Add("Mutated Firehydrant");
      namesEnemies.Add("Cloud of Anger");
      namesEnemies.Add("Puddle of Mutagen");
      namesEnemies.Add("Jar of Marmite");

      namesMerhcants.Add("Honest Herbert");
      namesMerhcants.Add("Finnicky Finn");
      namesMerhcants.Add("Cheaty Chandra");
      namesMerhcants.Add("Nice Nicky");
    }
  }
}
