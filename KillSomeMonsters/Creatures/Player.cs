using KillSomeMonsters.Equipment;
using KillSomeMonsters.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Creatures
{
  public class Player : Creature
  {
    public Location currentplayerLocation;
    public int experience;

    public Player(string name, ref Town startHere) : this(name, ref startHere, 1, 1, 1, 1) { }

    public Player(string name, ref Town startHere, int fortitude, int strength, int speed, int dexterity)
    {
      this.name = name;
      this.maxHealth = Math.Max((fortitude * 5), 5);
      this.health = this.maxHealth;
      this.fortitude = fortitude;
      this.strength = strength;
      this.speed = speed;
      this.dexterity = dexterity;

      this.currentplayerLocation = startHere;
      this.experience = 0;
    }

    public void movePlayer(ref Location target)
    {
      target.generateSurroundings(Program.enemiesPerLocation);
      this.currentplayerLocation = target;
    }
  }
}
