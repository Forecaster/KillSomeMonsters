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
    public static Effect getRandomEffect(int magnitude, int duration)
    {
      Random rand = new Random();

      int number = rand.Next(0, 1);

      switch (number)
      {
        case 0:
          return new Heal(magnitude, duration);
        case 1:
          return new Damage(magnitude, duration);
        default:
          return new Heal(magnitude, duration);
      }
    }

    /*
     * Used to roll dice for tests using attributes. An attribute should be performed as rollDice(1 + attribute) = result
     */
    public static int rollDice(int numberOfDice)
    {
      Random rand = new Random();
      List<int> results = new List<int>();
      int sum = 0;
      for (int i = 0; i <= numberOfDice; i++)
        results.Add(rand.Next(1, 6));

      sum = results.Sum();

      if (Program.debugModeEnabled)
      {
        debugMsg("Rolling " + numberOfDice + ":");
        for (int c = 0; c < results.Count - 1; c++)
        {
          debugMsg("Roll #" + c + ": " + results[c]);
        }
        debugMsg("Total: " + sum);
        debugMsg("========");
      }
      return sum;
    }

    /*
     * Takes the input boolean and returns the inverse
     */
    public static bool invertBoolean(bool boolean)
    {
      if (boolean)
        return false;
      else
        return true;
    }

    /*
     * Prints a message to console with the [Debug] prefix
     */
    public static void debugMsg(string msg)
    {
      if (Program.debugModeEnabled)
        Console.WriteLine("[Debug] " + msg);
    }
  }
}
