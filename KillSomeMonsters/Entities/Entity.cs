using KillSomeMonsters.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Entities
{
  public class Entity
  {
    //Name
    public string name;

    //level
    public int level = 1;

    //Stats
    public int health = 20;
    public int maxHealth = 20;
    public int strength = 1;
    public int speed = 1;
    public int dexterity = 1;

    //Equipment
    public List<Head> helmet = new List<Head>();
    public List<Body> armor = new List<Body>();
    public List<Shield> shield = new List<Shield>();
    public List<Weapon> weapon = new List<Weapon>();
    public List<Potion> potion = new List<Potion>();

    //misc
    public int gold;
  }
}
