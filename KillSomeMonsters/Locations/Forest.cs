using KillSomeMonsters.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Locations
{
  public class Forest : Location
  {
    public Forest(string name, int minEnemies, int maxEnemies)
    {
      Random rand = new Random();
      this.name = name;
      this.genericName = "forest";
      this.genericPlural = "forests";
      this.genericDescription = new List<string>();
      this.genericDescription.Add("A forest by the name of {0} surrounds you and you hear birds chirping in the trees above.");
      this.genericDescription.Add("A beatiful forest spreads out before you, beams of sunlight piercing through the canopy of leaves above. You heard it's called {0} in the previous town.");
      this.genericDescription.Add("Supposedly a forest, {0} appears to be more of a plain with a few trees here and there.");

      int enemies = rand.Next(minEnemies, maxEnemies);

      for (int i = 0; i < enemies; i++)
      {
        int randomName = rand.Next(0, EnemyNames.namesEnemies.Count);
        int minValue = Math.Max((Program.currentGame.player.level - 1), 1);
        int maxValue = Program.currentGame.player.level + 1;
        int randomFortitude = rand.Next(minValue, maxValue);
        int randomStrength = rand.Next(minValue, maxValue);
        int randomSpeed = rand.Next(minValue, maxValue);
        int randomDexterity = rand.Next(minValue, maxValue);

        this.enemies.Add(new Enemy(EnemyNames.namesEnemies[randomName], randomFortitude, randomStrength, randomSpeed, randomDexterity));
      }
    }
  }
}
