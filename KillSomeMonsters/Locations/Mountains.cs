using KillSomeMonsters.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Locations
{
  public class Mountains : Location
  {
    public Mountains(string name, int minEnemies, int maxEnemies)
    {
      Random rand = new Random();
      this.name = name;
      this.genericName = "mountain";
      this.genericPlural = "mountains";
      this.genericDescription = new List<string>();
      this.genericDescription.Add("{0} blocks your path.\nYou can see a winding path vanish into the distance");

      int enemies = rand.Next(minEnemies, maxEnemies);

      for (int i = 0; i < enemies; i++)
      {
        int randomName = rand.Next(0, CharacterNames.namesEnemies.Count);
        int minValue = Math.Max((Program.currentGame.player.level - 1), 1);
        int maxValue = Program.currentGame.player.level + 1;
        int randomFortitude = rand.Next(minValue, maxValue);
        int randomStrength = rand.Next(minValue, maxValue);
        int randomSpeed = rand.Next(minValue, maxValue);
        int randomDexterity = rand.Next(minValue, maxValue);

        this.enemies.Add(new Enemy(CharacterNames.namesEnemies[randomName], randomFortitude, randomStrength, randomSpeed, randomDexterity));
      }
    }
  }
}
