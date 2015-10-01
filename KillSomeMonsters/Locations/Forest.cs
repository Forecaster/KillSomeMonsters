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
    public Forest(string name, int numberOfEnemies)
    {
      Random rand = new Random();
      this.name = name;
      this.genericName = "forest";
      this.genericPlural = "forests";

      for (int i = 0; i < numberOfEnemies; i++)
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
