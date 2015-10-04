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
      //static constructor for reasons, probably not necessary
    }

    /*
     * This is useless right now, it can't replace the existing menus because it replaces the status bar and area description, needs more work to be usable
     */
    public static int navigationMenu(List<string> options)
    {
      bool exitMenu = false;
      int currentSelection = 0;
      while (!exitMenu)
      {
        for (int i = 0; i < options.Count; i++)
        {
          string prefix = "   ";
          if (i == currentSelection)
            prefix = " > ";

          Console.WriteLine(prefix + options[i]);
        }

        ConsoleKeyInfo userKey = Console.ReadKey();

        if (userKey.Key.ToString() == "Enter")
          exitMenu = true;
        else if (userKey.Key.ToString() == "UpArrow")
        {
          if (currentSelection == 0)
            currentSelection = options.Count - 1;
          else
            currentSelection--;
        }
        else if (userKey.Key.ToString() == "DownArrow")
        {
          if (currentSelection == options.Count - 1)
            currentSelection = 0;
          else
            currentSelection++;
        }
      }
      return currentSelection;
    }

    /*
     * This draws the player name, health and gold at the top of the screen
     */
    public static void drawPlayerStatus(Player player)
    {
      int maxWidth = Console.BufferWidth - 1;

      Console.Clear();
      string divider = "";
      for (var i = 0; i < maxWidth; i++)
      {
        divider += "#";
      }
      Console.WriteLine(divider);
      Console.WriteLine("# " + player.name + ": " + player.health + " / " + player.maxHealth + " # Gold: " + player.gold);
      //Console.WriteLine("# x" + player.x + " y" + player.y);
      Console.WriteLine(divider);
    }

    /*
     * This is the menu used to continue an existing game, start a new one or quit the game, as well as potentially quit the game.
     */
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

    /*
     * This method provides the menu used to create a new character and a new game.
     */
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

          if (characterName.Length == 0)
            characterName = playerNames.getRandomPlayerName();

          doneCreatingGame = true;
        }
      }

      Program.currentGame = new Game(new Player(characterName, fortitude, strength, speed, dexterity));
      Program.gameInProgress = true;
      gameMenu(ref Program.currentGame);
    }

    /*
     * This method represents the menu used to move around the world
     */
    static void gameMenu(ref Game game)
    {
      int currentSelection = 0;
      bool exitThisMenu = false;
      bool addNavOptions = true;

      while (!exitThisMenu)
      {
        int playerX = game.player.x;
        int playerY = game.player.y;
        Location location = game.worldMap.locations[playerX, playerY];
        string locationGenericName = location.genericName;
        string locationName = location.name;
        Console.Clear();
        List<string> options = new List<string>();
        drawPlayerStatus(game.player);
        
        if (locationGenericName == "town")
        {
          Console.WriteLine(location.getRandomDescription(), locationName);
          if (((Town)game.worldMap.locations[playerX, playerY]).hasMerchant == true)
          {
            Console.WriteLine("You see a weapon merchant");
            options.Add("Visit Merchant");
          }
          if (((Town)game.worldMap.locations[playerX, playerY]).hasInn == true)
          {
            Console.WriteLine("You see an inn");
            options.Add("Visit Inn");
          }
          if (((Town)game.worldMap.locations[playerX, playerY]).hasSewer == true)
          {
            Console.WriteLine("You see an entrance to the town sewer tunnels");
            options.Add("Enter Sewers");
          }
          addNavOptions = true;
        }
        else if (locationGenericName == "forest")
        {
          Console.WriteLine(location.getRandomDescription(), locationName);
          options.Add("Go Hunting");
          addNavOptions = true;
        }
        else if (locationGenericName == "mountain")
        {
          Console.WriteLine(location.getRandomDescription(), locationName);
          options.Add("Go Hunting");
          addNavOptions = true;
        }
        else if (locationGenericName == "sewer")
        {
          Console.WriteLine(location.genericDescription);
          options.Add("Go Hunting");
          options.Add("Exit Sewers");
          addNavOptions = false;
        }

        Console.Write("\n\n");

        if (addNavOptions)
        {
          options.Add("Look North");
          options.Add("Look West");
          options.Add("Look East");
          options.Add("Look South");
          options.Add("Go North");
          options.Add("Go West");
          options.Add("Go East");
          options.Add("Go South");
        }

        for (int i = 0; i < options.Count; i++)
        {
          string prefix = "   ";
          if (i == currentSelection)
            prefix = " > ";

          Console.WriteLine(prefix + options[i]);
        }

        ConsoleKeyInfo playerKey = Console.ReadKey();
        Console.WriteLine();

        if (playerKey.Key.ToString() == "Enter")
        {
          if (options[currentSelection] == "Visit Merchant")
          { }
          else if (options[currentSelection] == "Visit Inn")
          { }
          else if (options[currentSelection] == "Enter Sewers")
          { }
          else if (options[currentSelection] == "Go Hunting")
          {
            Random rand = new Random();
            int number = rand.Next(0, Program.currentGame.worldMap.locations[Program.currentGame.player.x, Program.currentGame.player.y].enemies.Count - 1);
            Enemy enemy = Program.currentGame.worldMap.locations[Program.currentGame.player.x, Program.currentGame.player.y].enemies[number];

            combatMenu(Program.currentGame.player, enemy);
          }
          else if (options[currentSelection] == "Look North")
          {
            if (game.worldMap.locations[game.player.x, game.player.y + 1] != null)
              Console.WriteLine(game.worldMap.locations[game.player.x, game.player.y +1].inspectLocation());
            else
            {
              game.worldMap.locations[game.player.x, game.player.y + 1] = Location.generateRandomLocation(Program.enemiesPerLocationMin, Program.enemiesPerLocationMax);
              Console.WriteLine(game.worldMap.locations[game.player.x, game.player.y + 1].inspectLocation());
              Console.WriteLine("...");
            }
            Console.ReadKey();
          }
          else if (options[currentSelection] == "Look West")
          {
            if (game.worldMap.locations[game.player.x - 1, game.player.y] != null)
              Console.WriteLine(game.worldMap.locations[game.player.x - 1, game.player.y].inspectLocation());
            else
            {
              game.worldMap.locations[game.player.x - 1, game.player.y] = Location.generateRandomLocation(Program.enemiesPerLocationMin, Program.enemiesPerLocationMax);
              Console.WriteLine(game.worldMap.locations[game.player.x - 1, game.player.y].inspectLocation());
              Console.WriteLine("...");
            }
            Console.ReadKey();
          }
          else if (options[currentSelection] == "Look East")
          {
            if (game.worldMap.locations[game.player.x + 2, game.player.y] != null)
              Console.WriteLine(game.worldMap.locations[game.player.x + 2, game.player.y].inspectLocation());
            else
            {
              game.worldMap.locations[game.player.x + 2, game.player.y] = Location.generateRandomLocation(Program.enemiesPerLocationMin, Program.enemiesPerLocationMax);
              Console.WriteLine(game.worldMap.locations[game.player.x + 2, game.player.y].inspectLocation());
              Console.WriteLine("...");
            }
            Console.ReadKey();
          }
          else if (options[currentSelection] == "Look South")
          {
            if (game.worldMap.locations[game.player.x, game.player.y - 1] != null)
              Console.WriteLine(game.worldMap.locations[game.player.x, game.player.y - 1].inspectLocation());
            else
            {
              game.worldMap.locations[game.player.x, game.player.y - 1] = Location.generateRandomLocation(Program.enemiesPerLocationMin, Program.enemiesPerLocationMax);
              Console.WriteLine(game.worldMap.locations[game.player.x, game.player.y - 1].inspectLocation());
              Console.WriteLine("...");
            }
            Console.ReadKey();
          }
          else if (options[currentSelection] == "Go North")
          {
            if (game.player.movePlayer(Direction.NORTH))
            {
              Console.WriteLine("You wander north until your surroundings turn into those of a " + game.worldMap.locations[game.player.x, game.player.y].genericName);
              Console.WriteLine("...");
              Console.ReadKey();
            }
          }
          else if (options[currentSelection] == "Go West")
          {
            if (game.player.movePlayer(Direction.WEST))
            {
              Console.WriteLine("You wander west until your surroundings turn into those of a " + game.worldMap.locations[game.player.x, game.player.y].genericName);
              Console.WriteLine("...");
              Console.ReadKey();
            }
          }
          else if (options[currentSelection] == "Go East")
          {
            if (game.player.movePlayer(Direction.EAST))
            {
              Console.WriteLine("You wander east until your surroundings turn into those of a " + game.worldMap.locations[game.player.x, game.player.y].genericName);
              Console.WriteLine("...");
              Console.ReadKey();
            }
          }
          else if (options[currentSelection] == "Go South")
          {
            if (game.player.movePlayer(Direction.SOUTH))
            {
              Console.WriteLine("You wander south until your surroundings turn into those of a " + game.worldMap.locations[game.player.x, game.player.y].genericName);
              Console.WriteLine("...");
              Console.ReadKey();
            }
          }
        }
        else if (playerKey.Key.ToString() == "UpArrow")
        {
          currentSelection--;
          if (currentSelection < 0)
            currentSelection = options.Count;
        }
        else if (playerKey.Key.ToString() == "DownArrow")
        {
          currentSelection++;
          if (currentSelection >= options.Count)
            currentSelection = 0;
        }
      }
    }

    public static bool combatMenu(Player player, Creature opponent)
    {
      int currentSelection = 0;
      bool exitThisMenu = false;

      while (!exitThisMenu)
      {
        List<string> options = new List<string>();

        options.Add("Attack");
        options.Add("Defend");
        if (player.potion.Count > 0)
        {
          options.Add("Throw Potion");
          options.Add("Drink Potion");
        }
        options.Add("Run away");

        Console.WriteLine("You find youself facing a vicious " + opponent.name);
        Console.WriteLine("The creature looks " + opponent.getGeneralHealth());
        Console.WriteLine();

        for (int i = 0; i < options.Count; i++)
        {
          string prefix = "   ";
          if (i == currentSelection)
            prefix = " > ";

          Console.WriteLine(prefix + options[i]);
        }

        ConsoleKeyInfo playerKey = Console.ReadKey();

        if (playerKey.Key.ToString() == "Enter")
        {
          if (options[currentSelection] == "Attack")
          {
            int dexterity = Utility.rollDice(player.dexterity);
            int strength = Utility.rollDice(player.strength);
            int opponentSpeed = Utility.rollDice(opponent.speed);

            if (dexterity >= opponentSpeed)
            {
              int damage = opponent.getReducedDamageAgainstArmor(strength + player.getWeaponDamage());
              Console.WriteLine("You swing your " + player.weapon.name + " at the creature and do " + damage + " damage!");
              opponent.applyDamage(damage);
            }
            else
              Console.WriteLine("You swing your " + player.weapon.name + " at the creature but miss and tumble past it!");

            Console.WriteLine("...");
            Console.ReadKey();
          }
        }
        else if (playerKey.Key.ToString() == "UpArrow")
        {
          currentSelection--;
          if (currentSelection < 0)
            currentSelection = options.Count;
        }
        else if (playerKey.Key.ToString() == "DownArrow")
        {
          currentSelection++;
          if (currentSelection >= options.Count)
            currentSelection = 0;
        }
      }
    }
  }
}