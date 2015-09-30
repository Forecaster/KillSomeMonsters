using KillSomeMonsters.Creatures;
using KillSomeMonsters.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Menus
{
  public static class Menu
  {
    static int newGameStage = 0;
    static string characterName;

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
            if (!Program.gameInProgress)
            {
              Console.Write(prefix);
              Console.ForegroundColor = System.ConsoleColor.DarkGray;
              Console.WriteLine(options[i]);
              Console.ResetColor();
            }
            else
              Console.WriteLine(prefix + options[i]);
          }
          else
            Console.WriteLine(prefix + options[i]);
        }

        ConsoleKeyInfo userKey = Console.ReadKey(true);

        if (userKey.Key.ToString() == "Enter")
        {
          if (currentSelection == 0 && Program.gameInProgress == false)
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
        newGame();
      else if (currentSelection == 2)
        Console.WriteLine("Quit"); //this shouldn't really do anything, just let the program terminate
    }

    public static void newGame()
    {
      int fortitude = 0;
      int strength = 0;
      int speed = 0;
      int dexterity = 0;
      int currentSelection = 0;
      int pointsToSpend = 6;

      List<string> options = new List<string>();

      bool doneCreatingGame = false;
      while (!doneCreatingGame)
      {
        Console.Clear();
        int maxWidth = Console.BufferWidth - 1;
        string divider = "";
        for (var i = 0; i < maxWidth; i++)
        {
          divider += "#";
        }
        Console.Clear();
        Console.WriteLine(divider);

        if (newGameStage == 0)
        {
          options.Clear();
          options.Add("Fortitude");
          options.Add("Strength");
          options.Add("Speed");
          options.Add("Dexterity");

          Console.WriteLine("# Start New Game     # Assign stats using arrow keys! Press Enter when done.");
          Console.WriteLine(divider + "\n");

          for (int i = 0; i < options.Count; i++)
          {
            string prefix = "   ";
            int value = 0;
            switch (i)
            {
              case 0:
                value = fortitude; break;
              case 1:
                value = strength; break;
              case 2:
                value = speed; break;
              case 3:
                value = dexterity; break;
            }

            if (currentSelection == i)
              prefix = " > ";

            Console.WriteLine(prefix + options[i] + ": " + value);
          }

          Console.WriteLine("\n\n   Points to spend: " + pointsToSpend);

          ConsoleKeyInfo userKey = Console.ReadKey();

          if (userKey.Key.ToString() == "Enter")
          {
            newGameStage++;
          }
          else if (userKey.Key.ToString() == "UpArrow")
          {
            currentSelection--;
            if (currentSelection < 0)
              currentSelection = 3;
          }
          else if (userKey.Key.ToString() == "DownArrow")
          {
            currentSelection++;
            if (currentSelection > 3)
              currentSelection = 0;
          }
          else if (userKey.Key.ToString() == "LeftArrow")
          {
            if (currentSelection == 0)
            {
              if (fortitude > 0)
              {
                fortitude--;
                pointsToSpend++;
              }
            }
            else if (currentSelection == 1)
            {
              if (strength > 0)
              {
                strength--;
                pointsToSpend++;
              }
            }
            else if (currentSelection == 2)
            {
              if (speed > 0)
              {
                speed--;
                pointsToSpend++;
              }
            }
            else if (currentSelection == 3)
            {
              if (dexterity > 0)
              {
                dexterity--;
                pointsToSpend++;
              }
            }
          }
          else if (userKey.Key.ToString() == "RightArrow")
          {
            if (pointsToSpend > 0)
            {
              if (currentSelection == 0)
                fortitude++;
              else if (currentSelection == 1)
                strength++;
              else if (currentSelection == 2)
                speed++;
              else if (currentSelection == 3)
                dexterity++;

              pointsToSpend--;
            }
          }
        }
        else if (newGameStage == 1)
        {
          Console.WriteLine("# Start New Game     # Enter a name for your character. Press Enter when done");
          Console.WriteLine(divider + "\n");
          Console.WriteLine("");
          Console.Write("Name: ");
          characterName = Console.ReadLine();

          doneCreatingGame = true;
        }
      }

      Program.currentGame = new Game();
      Program.currentGame.startingTown = new Town("Startville", true, 100, true);
      Program.currentGame.player = new Player(characterName, ref Program.currentGame.startingTown, fortitude, strength, speed, dexterity);
      Program.gameInProgress = true;
      gameMenu();
    }

    static void gameMenu()
    {

    }
  }
}
