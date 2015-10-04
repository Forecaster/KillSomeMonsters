using KillSomeMonsters.StatEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters
{
  public static class Utility
  {
    public static Effect getRandomEffect()
    {
      Random rand = new Random();

      int number = rand.Next(0, 1);

      switch (number)
      {
        case 0:
          return Effect.HEAL;
        case 1:
          return Effect.DAMAGE;
        default:
          return Effect.HEAL;
      }
    }

    /*
     * Used to roll dice for tests using attributes. The attribute being tested should be used as the number of dice
     */
    public static int rollDice(int numberOfDice)
    {
      Random rand = new Random();
      int sum = 0;
      for (int i = 0; i < numberOfDice - 1; i++)
      {
        sum += rand.Next(1, 6);
      }
      return sum;
    }
  }
}
