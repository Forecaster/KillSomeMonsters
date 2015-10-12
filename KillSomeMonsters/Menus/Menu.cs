using KillSomeMonsters.Creatures;
using KillSomeMonsters.Items;
using KillSomeMonsters.Locations;
using KillSomeMonsters.StatEffects;
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
          if (currentSelection == i)
            Console.WriteLine(Program.cursor + options[i]);
          else
            Console.WriteLine("   " + options[i]);
        }

        string userKey = Console.ReadKey().Key.ToString();

        if (userKey == "Enter")
          exitMenu = true;
        else if (userKey == "UpArrow")
        {
          if (currentSelection == 0)
            currentSelection = options.Count - 1;
          else
            currentSelection--;
        }
        else if (userKey == "DownArrow")
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
      bool exitThisMenu = false;
      int currentSelection = 1;
      if (Program.currentGame != null)
        currentSelection = 0;

      while (!exitThisMenu)
      {
        int maxWidth = Console.BufferWidth - 1;

        List<string> options = new List<string>();
        options.Add("Continue");
        options.Add("New Game");
        options.Add("Debug mode: {0}");
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
            prefix = Program.cursor;

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
          else if (i == 2)
          {
            Console.WriteLine(prefix + options[i], Program.debugModeEnabled.ToString());
          }
          else
            Console.WriteLine(prefix + options[i]);
        }

        if (Program.debugModeEnabled)
          Console.WriteLine("\nDebug mode will display addional (sometimes spammy) data and some cheat options. It will also keep you from dying in combat.");

        string userKey = Console.ReadKey(true).Key.ToString();

        if (userKey == "Enter")
        {
          if (options[currentSelection] == "Continue" && Program.gameInProgress == false)
            Console.WriteLine("Continue"); //replace with action when selecting "continue"
          else if (options[currentSelection] == "New Game")
            newGame();
          else if (options[currentSelection] == "Quit")
            exitThisMenu = true;
        }
        else if (userKey == "UpArrow")
        {
          currentSelection--;
          if (currentSelection < 0)
            currentSelection = 2;
        }
        else if (userKey == "DownArrow")
        {
          currentSelection++;
          if (currentSelection > 3)
            currentSelection = 0;
        }
        else if (userKey == "LeftArrow" || userKey == "RightArrow")
        {
          if (currentSelection == 2)
            Program.debugModeEnabled = Utility.invertBoolean(Program.debugModeEnabled);
        }
      }
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
      int pointsToSpend = 2;

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
              prefix = Program.cursor;

            Console.WriteLine(prefix + options[i] + ": " + value);
          }

          Console.WriteLine("\n\n   Points to spend: " + pointsToSpend);
          Console.WriteLine("\n   Levelling is not implemented. These are the only points you get for now.");

          string userKey = Console.ReadKey().Key.ToString();

          if (userKey == "Enter")
          {
            newGameStage++;
          }
          else if (userKey == "UpArrow")
          {
            currentSelection--;
            if (currentSelection < 0)
              currentSelection = 3;
          }
          else if (userKey == "DownArrow")
          {
            currentSelection++;
            if (currentSelection > 3)
              currentSelection = 0;
          }
          else if (userKey == "LeftArrow")
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
          else if (userKey == "RightArrow")
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
          newGameStage = 0;
        }
      }
      Player player = new Player(characterName, fortitude, strength, speed, dexterity);
      player.potions.Add(Equipment.generateRandomPotion(player.level));
      Program.currentGame = new Game(player);
      Program.gameInProgress = true;
      gameMenu(ref Program.currentGame);
    }

    /*
     * This method represents the menu used to move around the world
     */
    public static void gameMenu(ref Game game)
    {
      int currentSelection = 0;
      bool exitThisMenu = false;
      bool addNavOptions = true;
      string currentLocationDescription = ""; //this keeps the game from displaying a random description every time the menu is redrawn, a new one is picked only when you move to a new location

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

        if (Program.debugModeEnabled)
        {
          Utility.debugMsg("Enemies left: " + location.enemies.Count);
          Console.WriteLine();
          options.Add("Heal (Debug)");
        }
        
        if (locationGenericName == "town")
        {
          Console.WriteLine(currentLocationDescription, locationName); //Writes current location description and inserts the location name into it
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
          Console.WriteLine(currentLocationDescription, locationName); //Writes current location description and inserts the location name into it
          options.Add("Go Hunting");
          addNavOptions = true;
        }
        else if (locationGenericName == "mountain")
        {
          Console.WriteLine(currentLocationDescription, locationName); //Writes current location description and inserts the location name into it
          options.Add("Go Hunting");
          addNavOptions = true;
        }
        else if (locationGenericName == "sewer")
        {
          Console.WriteLine(currentLocationDescription, locationName); //Writes current location description and inserts the location name into it
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
            prefix = Program.cursor;

          Console.WriteLine(prefix + options[i]);
        }

        string playerKey = Console.ReadKey().Key.ToString();
        Console.WriteLine();

        if (playerKey == "Enter")
        {
          if (options[currentSelection] == "Heal (Debug)")
          {
            game.player.health = game.player.maxHealth;
          }
          else if (options[currentSelection] == "Visit Merchant")
          {
            merchantMenu(((Town)location).merchant);
          }
          else if (options[currentSelection] == "Visit Inn")
          { }
          else if (options[currentSelection] == "Enter Sewers")
          { }
          else if (options[currentSelection] == "Go Hunting")
          {
            Location currentLocation = Program.currentGame.worldMap.locations[Program.currentGame.player.x, Program.currentGame.player.y];
            if (currentLocation.enemies.Count > 0)
            {
              Random rand = new Random();
              int number = rand.Next(0, currentLocation.enemies.Count - 1);
              Enemy enemy = currentLocation.enemies[number];

              Console.WriteLine("You don't have to wander far until you hear something evil rustle some shrubbery nearby");
              Console.WriteLine("...");
              Console.ReadKey();

              string combatResult = combatMenu(Program.currentGame.player, enemy);
              if (combatResult == "opponentDefeat")
              {
                currentLocation.enemies.RemoveAt(number);
                Console.WriteLine("You strike a dramatic victory pose as your opponent collapses behind you! You won the battle!");
                Console.WriteLine("...");
                Console.ReadKey();
              }
              else if (combatResult == "playerDefeat")
              {
                Console.WriteLine("You look down at the " + enemy.weapon.name + " embedded in your chest as you bleed profusly on the ground. This is the end for you.");
                Console.WriteLine("...");
                Console.ReadKey();
                Program.currentGame = null;
                Program.gameInProgress = false;
                return;
              }
              else if (combatResult == "opponentEscape")
              {
                Console.WriteLine("You try to catch up to the creature sprinting away from you, but fail to keep up.");
                Console.WriteLine("...");
                Console.ReadKey();
              }
            }
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
              currentLocationDescription = game.worldMap.locations[game.player.x, game.player.y].getRandomDescription();
              Console.WriteLine("You wander north until your surroundings turn into those of a " + game.worldMap.locations[game.player.x, game.player.y].genericName);
              Console.WriteLine("...");
              Console.ReadKey();
            }
          }
          else if (options[currentSelection] == "Go West")
          {
            if (game.player.movePlayer(Direction.WEST))
            {
              currentLocationDescription = game.worldMap.locations[game.player.x, game.player.y].getRandomDescription();
              Console.WriteLine("You wander west until your surroundings turn into those of a " + game.worldMap.locations[game.player.x, game.player.y].genericName);
              Console.WriteLine("...");
              Console.ReadKey();
            }
          }
          else if (options[currentSelection] == "Go East")
          {
            if (game.player.movePlayer(Direction.EAST))
            {
              currentLocationDescription = game.worldMap.locations[game.player.x, game.player.y].getRandomDescription();
              Console.WriteLine("You wander east until your surroundings turn into those of a " + game.worldMap.locations[game.player.x, game.player.y].genericName);
              Console.WriteLine("...");
              Console.ReadKey();
            }
          }
          else if (options[currentSelection] == "Go South")
          {
            if (game.player.movePlayer(Direction.SOUTH))
            {
              currentLocationDescription = game.worldMap.locations[game.player.x, game.player.y].getRandomDescription();
              Console.WriteLine("You wander south until your surroundings turn into those of a " + game.worldMap.locations[game.player.x, game.player.y].genericName);
              Console.WriteLine("...");
              Console.ReadKey();
            }
          }
        }
        else if (playerKey == "UpArrow")
        {
          currentSelection--;
          if (currentSelection < 0)
            currentSelection = options.Count;
        }
        else if (playerKey == "DownArrow")
        {
          currentSelection++;
          if (currentSelection >= options.Count)
            currentSelection = 0;
        }
      }
    }

    /**
     * Returns true if opponent was defeated, false if player died or opponent escaped
     */
    public static string combatMenu(Player player, Creature opponent)
    {
      int currentSelection = 0;
      bool exitThisMenu = false;

      while (!exitThisMenu)
      {
        List<string> options = new List<string>();
        Console.Clear();
        player.tick();
        Menu.drawPlayerStatus(player);

        options.Add("Attack");
        options.Add("Defend");
        if (player.potions.Count > 0)
        {
          options.Add("Throw Potion");
          options.Add("Drink Potion");
        }
        options.Add("Run away");

        Console.WriteLine("You find youself facing a vicious " + opponent.name + " wearing a " + opponent.armor.name + " and a " + opponent.helmet.name);
        if (opponent.shield != null)
          Console.WriteLine("It is carrying a shield");
        Console.WriteLine("The creature looks " + opponent.getGeneralHealth());
        Console.WriteLine();

        if (Program.debugModeEnabled)
        {
          Console.WriteLine("[Debug]" + opponent.health + "/" + opponent.maxHealth);
          Console.WriteLine("[Debug] Shielding: " + opponent.shielding);
        }

        for (int i = 0; i < options.Count; i++)
        {
          string prefix = "   ";
          if (i == currentSelection)
            prefix = Program.cursor;

          Console.WriteLine(prefix + options[i]);
        }

        string userKey = Console.ReadKey().Key.ToString();

        if (userKey == "Enter")
        {
          if (options[currentSelection] == "Attack")
          {
            player.shielding = false;
            Tuple<int, int, string> result = opponent.getReducedDamageAgainstArmor(Utility.rollDice(1 + player.strength) + player.getWeaponDamage(), player.dexterity);
            if (result.Item3 != "Miss")
            {
              Console.WriteLine("You swing your " + player.weapon.name + " at the creature and strike it's " + result.Item3 + " and do " + result.Item1 + " damage!");
              if (result.Item2 > 0)
                Console.WriteLine("It's armor absorbed " + result.Item2 + " damage.");
              Console.WriteLine("You do " + (result.Item1 - result.Item2) + " points of damage.");
              opponent.applyDamage(result.Item1 - result.Item2);
            }
            else
              Console.WriteLine("You swing your " + player.weapon.name + " at the creature but miss and tumble past it!");


            Console.WriteLine("...");
            Console.ReadKey();
          }
          else if (options[currentSelection] == "Defend")
          {
            player.shielding = true;
            Console.WriteLine("You raise your " + player.shield.name + " in front of you, hoping that your opponent will hit it instead of your face.");
            Console.WriteLine("...");
            Console.ReadKey();
          }
          else if (options[currentSelection] == "Run away")
          {
            int mySpeed = Utility.rollDice(1 + player.speed);
            int opponentSpeed = Utility.rollDice(1 + opponent.speed);

            if (mySpeed > opponentSpeed)
            {
              Console.WriteLine("You decide you're in trouble and start sprinting away from the " + opponent.name + " and keep going until you can no longer hear it behind you.");
              Console.WriteLine("...");
              Console.ReadKey();
              return "playerEscape";
            }
            else
            {
              Console.WriteLine("You decide the " + opponent.name + " is too much to handle and attempt a daring escape, dashing right past it you try to outrun it.");
              Console.WriteLine("You quickly realize it's faster than you and stop and turn to face it once more.");
              Console.WriteLine("It takes the opportunity to attack while you are turning around!");
              Console.WriteLine("...");
              Console.ReadKey();
            }

          }
          else if (options[currentSelection] == "Throw Potion")
          {
            int effect = 0;
            int potion = potionMenu(player.potions, "thow");
            if (potion >= 0)
            {
              effect = player.potions[potion].throwPotion(opponent);
              player.potions.RemoveAt(potion);
              if (effect != 0)
              {
                if (effect < 0)
                  Console.WriteLine("The bottle smashes against the " + opponent.name + " and a small magical explosion occurs causing " + effect + " damage!");
                else
                  Console.WriteLine("The bottle smashes against the " + opponent.name + " and some of it's wounds seem to heal...");
              }
              else
                Console.WriteLine("The bottle smashes against the " + opponent.name + " but nothing appears to happen...");
              Console.WriteLine("...");
              Console.ReadKey();
            }
          }
          else if (options[currentSelection] == "Drink Potion")
          {
            int effect = 0;
            int potion = potionMenu(player.potions, "drink");
            if (potion >= 0)
            {
              effect = player.potions[potion].drinkPotion(player);
              player.potions.RemoveAt(potion);
              if (effect != 0)
              {
                if (effect < 0)
                  Console.WriteLine("You chug the contents of the bottle and feel a sudden sharp pain in your stomach. You take " + effect + " damage!");
                else
                  Console.WriteLine("You chug the contents of the bottle and some of your wounds seem to heal.");
              }
              else
                Console.WriteLine("You drink the contents of the bottle, but nothing seems to happen...");
              Console.WriteLine("...");
              Console.ReadKey();
            }
          }

          if (opponent.health == 0)
          {
            player.gold += opponent.gold;
            Console.WriteLine("You find " + opponent.gold + " gold coins on the remains!");
            return "opponentDefeat";
          }
          else
            if (((Enemy)opponent).enemyTurn(player) == "escapeSuccess")
              return "opponentEscape";

          if (Program.debugModeEnabled && player.health == 0)
          {
            player.health = 1;
            Utility.debugMsg("Kept you from dying a horrible death.");
            Console.WriteLine("...");
            Console.ReadKey();
          }

          if (player.health == 0)
            return "playerDefeat";
        }
        else if (userKey == "UpArrow")
        {
          currentSelection--;
          if (currentSelection < 0)
            currentSelection = options.Count;
        }
        else if (userKey == "DownArrow")
        {
          currentSelection++;
          if (currentSelection >= options.Count)
            currentSelection = 0;
        }
      }

      //combat over
      Console.WriteLine("Combat has ended");
      Console.ReadKey();
      return "unknownOutcome";
    }

    public static void merchantMenu(Merchant merchant)
    {
      bool exitThisMenu = false;
      bool exitSubMenu = false;
      List<string> options = new List<string>();
      int currentSelection = 0;

      while (!exitThisMenu)
      {
        Console.Clear();
        options.Clear();
        drawPlayerStatus(Program.currentGame.player);

        Console.WriteLine("The merchant greets you as you enter the shop:");
        Console.WriteLine("\"Hello! I'm {0}! How can I help you?!", merchant.name);
        Console.WriteLine();
        Console.WriteLine("Current Weapon:  " + Program.currentGame.player.weapon.name);
        Console.WriteLine("Current Armor:   " + Program.currentGame.player.armor.name);
        Console.WriteLine("Current Helmet:  " + Program.currentGame.player.helmet.name);
        if (Program.currentGame.player.shield != null)
          Console.WriteLine("Current Shield: " + Program.currentGame.player.shield.name);
        Console.WriteLine();

        if (merchant.weapons.Count > 0)
          options.Add("Show Weapons");
        if (merchant.armor.Count > 0)
          options.Add("Show Bodywear");
        if (merchant.headwear.Count > 0)
          options.Add("Show Headwear");
        if (merchant.shields.Count > 0)
          options.Add("Show Shields");
        if (merchant.potions.Count > 0)
          options.Add("Show Potions");
        options.Add("Back");

        for (int i = 0; i < options.Count; i++)
        {
          if (currentSelection == i)
            Console.WriteLine(Program.cursor + options[i]);
          else
            Console.WriteLine("   " + options[i]);
        }

        string userKey = Console.ReadKey().Key.ToString();

        if (userKey == "Enter")
        {
          string choice = "";
          if (options[currentSelection] == "Show Weapons")
            choice = "weapon";
          else if (options[currentSelection] == "Show Bodywear")
            choice = "body";
          else if (options[currentSelection] == "Show Headwear")
            choice = "head";
          else if (options[currentSelection] == "Show Shields")
            choice = "shield";
          else if (options[currentSelection] == "Show Potions")
            choice = "potion";
          else if (options[currentSelection] == "Back")
            exitThisMenu = true;

          if (choice == "weapon" || choice == "body" || choice == "head" || choice == "shield" || choice == "potion")
          {
            List<Equipment> wares = new List<Equipment>();
            if (choice == "weapon")
              wares.InsertRange(0, merchant.weapons);
            else if (choice == "body")
              wares.InsertRange(0, merchant.armor);
            else if (choice == "head")
              wares.InsertRange(0, merchant.headwear);
            else if (choice == "shield")
              wares.InsertRange(0, merchant.shields);
            else if (choice == "potion")
              wares.InsertRange(0, merchant.potions);

            currentSelection = 0;
            exitSubMenu = false;
            while (!exitSubMenu)
            {
              Console.Clear();
              drawPlayerStatus(Program.currentGame.player);

              for (int f = 0; f < wares.Count; f++)
              {
                string prefix = "   ";
                if (currentSelection == f)
                  prefix = Program.cursor;

                string wareName = wares[f].name;
                string wareAttribute = "";
                switch (choice)
                {
                  case "weapon":
                    wareAttribute = ((Weapon)wares[f]).damage.ToString();
                    break;
                  case "body":
                  case "head":
                  case "shield":
                    wareAttribute = ((Armor)wares[f]).armorBonus.ToString();
                    break;
                  case "potion":
                    wareAttribute = ((Potion)wares[f]).effect.magnitude.ToString();
                    break;
                }
                int wareValue = wares[f].value;

                Console.WriteLine(prefix + wareName + " +" + wareAttribute + " (" + wareValue + "g)");
              }

              Console.WriteLine("\nPress Escape to go back.");

              userKey = Console.ReadKey().Key.ToString();

              if (userKey == "Enter")
              {
                if (wares[currentSelection].value <= Program.currentGame.player.gold)
                {
                  if (choice == "weapon")
                    Program.currentGame.player.weapon = merchant.purchaseWeapon(currentSelection);
                  else if (choice == "body")
                    Program.currentGame.player.armor = merchant.purchaseBody(currentSelection);
                  else if (choice == "head")
                    Program.currentGame.player.helmet = merchant.purchaseHead(currentSelection);
                  else if (choice == "shield")
                    Program.currentGame.player.shield = merchant.purchaseShield(currentSelection);
                  else if (choice == "potion")
                    if (Program.currentGame.player.potions.Count < Program.maxPotionCarry)
                      Program.currentGame.player.potions.Add(merchant.purchasePotion(currentSelection));
                  Console.WriteLine("You bought a " + wares[currentSelection].name + "!");
                  Console.WriteLine("...");
                  Console.ReadKey();
                  exitSubMenu = true;
                }
                else
                {
                  Console.WriteLine("You can't afford this.");
                  Console.WriteLine("...");
                  Console.ReadKey();
                }
              }
              else if (userKey == "DownArrow")
              {
                currentSelection++;
                if (currentSelection > wares.Count - 1)
                  currentSelection = 0;
              }
              else if (userKey == "UpArrow")
              {
                currentSelection--;
                if (currentSelection < 0)
                  currentSelection = wares.Count - 1;
              }
              else if (userKey == "Escape")
              {
                exitSubMenu = true;
              }
            }
          }
        }
        else if (userKey == "DownArrow")
        {
          currentSelection++;
          if (currentSelection > options.Count - 1)
            currentSelection = 0;
        }
        else if (userKey == "UpArrow")
        {
          currentSelection--;
          if (currentSelection < 0)
            currentSelection = options.Count - 1;
        }
      }
    }

    public static int potionMenu(List<Potion> potions, string action)
    {
      bool exitThisMenu = false;
      int currentSelection = 0;
      List<string> options = new List<string>();

      foreach (Potion potion in potions)
        options.Add("potion");

      options.Add("exit");

      while (!exitThisMenu)
      {
        Console.Clear();
        drawPlayerStatus(Program.currentGame.player);
        Console.WriteLine("\nChose a potion to " + action + ":\n");
        for (int i = 0; i < options.Count; i++)
        {
          string prefix = "   ";
          if (currentSelection == i)
            prefix = Program.cursor;

          if (options[i] == "potion")
            Console.WriteLine(prefix + potions[i].name + " +" + potions[i].effect.magnitude);
          else if (options[i] == "exit")
            Console.WriteLine(prefix + "Exit");
        }

        string userKey = Console.ReadKey().Key.ToString();

        if (userKey == "Enter")
        {
          if (options[currentSelection] == "potion")
            return currentSelection;
          else
            return -1;
        }
        else if (userKey == "UpArrow")
        {
          currentSelection--;
          if (currentSelection < 0)
            currentSelection = options.Count;
        }
        else if (userKey == "DownArrow")
        {
          currentSelection++;
          if (currentSelection >= options.Count)
            currentSelection = 0;
        }
      }
      return currentSelection;
    }
  }
}