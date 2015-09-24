using KillSomeMonsters.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Entities
{
  class Entity
  {
    //Name
    public string name;

    //level
    public int level = 1;

    //Stats
    public int health;
    public int maxHealth;
    public int strength;
    public int speed;
    public int dexterity;

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
