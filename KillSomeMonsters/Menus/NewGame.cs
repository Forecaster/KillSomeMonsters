using System;
using System.Collections.Generic;

namespace KillSomeMonsters.Menus
{
  public static class NewGame
  {
    public static List<string> choices = new List<string>();

    static NewGame()
    {
      choices.Add("");

      Console.SetCursorPosition(0, 0);
    }
  }
}
