using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Menus
{
  public static class Menu
  {
    static Menu()
    {
      //static constructor for reasons
    }

    public static void drawPlayerStatus()
    {
      int maxWidth = Console.BufferWidth - 1;

      Console.Clear();
      string divider = "";
      for (var i = 0; i < maxWidth; i++)
      {
        divider += "#";
      }
      Console.WriteLine(divider);
      Console.WriteLine("# " + Program.currentGame.player.name + ": " + Program.currentGame.player.health + " / " + Program.currentGame.player.maxHealth + " # Gold: " + Program.currentGame.player.gold + " #");
      Console.WriteLine(divider);
    }

    public static void mainMenu()
    {
      bool goForth = false;
      int currentSelection = 1;
      if (Program.currentGame != null)
        currentSelection = 0;

      while (!goForth)
      {
        int maxWidth = Console.BufferWidth - 1;

        List<string> options = new List<string>();
        options.Add("Continue");
        options.Add("New Game");
        options.Add("Quit");

        Console.Clear();
        string divider = "";
        for (var i = 0; i < maxWidth; i++)
        {
          divider += "#";
        }
        Console.WriteLine(divider);
        Console.WriteLine("# " + Program.gameName + " by " + Program.authorName);
        Console.WriteLine(divider);
        Console.Write("\n\n");
        for (int i = 0; i < options.Count; i++)
        {
          string prefix = "   ";
          if (i == currentSelection)
            prefix = " > ";

          if (i == 0)
          {
            if (Program.currentGame != null)
            {
              Console.Write(prefix);
              Console.ForegroundColor = System.ConsoleColor.DarkGray;
              Console.WriteLine(options[i]);
              Console.ResetColor();
            }
          }
          else
            Console.WriteLine(prefix + options[i]);
        }

        var userKey = Console.ReadKey(true);

        if (userKey.Key.ToString() == "Enter")
        {
          if (currentSelection == 0 && Program.currentGame == null)
            goForth = false;
          else
            goForth = true;
        }
        else if (userKey.Key.ToString() == "UpArrow")
        {
          currentSelection--;
          if (currentSelection < 0)
            currentSelection = 2;
        }
        else if (userKey.Key.ToString() == "DownArrow")
        {
          currentSelection++;
          if (currentSelection > 2)
            currentSelection = 0;
        }
      }

      if (currentSelection == 0)
        Console.WriteLine("Continue"); //replace with action when selecting "continue"
      else if (currentSelection == 1)
        Console.WriteLine("New Game"); //replace with action when selecting "new game"
      else if (currentSelection == 2)
        Console.WriteLine("Quit"); //this shouldn't really do anything, just let the program terminate
    }
  }
}
