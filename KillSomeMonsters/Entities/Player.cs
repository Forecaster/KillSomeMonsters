using KillSomeMonsters.Equipment;
using KillSomeMonsters.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Entities
{
  public class Player : Entity
  {
    public Location currentplayerLocation;

    public Player(string name, int maxHealth, int health)
    {
      this.name = name;
      this.maxHealth = maxHealth;
      this.health = health;
    }

    public Player(string name, ref Town startHere) : this(name, ref startHere, 20) { }

    public Player(string name, ref Town startHere, int maxHealth) : this(name, ref startHere, maxHealth, 1, 1, 1) { }

    public Player(string name, ref Town startHere, int maxHealth, int strength, int speed, int dexterity)
    {
      this.name = name;
      this.maxHealth = maxHealth;
      this.health = maxHealth;
      this.strength = strength;
      this.speed = speed;
      this.dexterity = dexterity;

      this.currentplayerLocation = startHere;
    }
  }
}
