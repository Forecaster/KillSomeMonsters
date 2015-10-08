using KillSomeMonsters.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Items
{
  public class Merchant
  {
    public string name;
    public List<Weapon> weapons;
    public List<Head> headwear;
    public List<Body> armor;
    public List<Shield> shields;
    public List<Potion> potions;

    public int gold;

    public Merchant(int level)
    {
      Random rand = new Random();
      int weaponCount = rand.Next(0, 4);
      int headwearCount = rand.Next(0, 4);
      int armorCount = rand.Next(0, 4);
      int shieldCount = rand.Next(0, 4);
      int potionCount = rand.Next(0, 4);

      this.weapons = new List<Weapon>();
      this.headwear = new List<Head>();
      this.armor = new List<Body>();
      this.shields = new List<Shield>();
      this.potions = new List<Potion>();

      for (int i = 0; i < weaponCount; i++)
      {
        this.weapons.Add(Items.Equipment.generateRandomWeapon(level));
      }

      for (int i = 0; i < headwearCount; i++)
      {
        this.headwear.Add(Items.Equipment.generateRandomHead(level));
      }

      for (int i = 0; i < armorCount; i++)
      {
        this.armor.Add(Items.Equipment.generateRandomBody(level));
      }

      for (int i = 0; i < shieldCount; i++)
      {
        this.shields.Add(Items.Equipment.generateRandomShield(level));
      }

      for (int i = 0; i < potionCount; i++)
      {
        this.potions.Add(Items.Equipment.generateRandomPotion(level));
      }

      this.name = CharacterNames.namesMerhcants[rand.Next(0, CharacterNames.namesMerhcants.Count - 1)];
      this.gold = rand.Next(10, 50);
    }

    public Weapon purchaseWeapon(int index)
    {
      Weapon item = this.weapons[index];
      this.weapons.RemoveAt(index);
      Program.currentGame.player.gold -= item.value;
      return item;
    }

    public Body purchaseBody(int index)
    {
      Body item = this.armor[index];
      this.armor.RemoveAt(index);
      return item;
    }

    public Head purchaseHead(int index)
    {
      Head item = this.headwear[index];
      this.headwear.RemoveAt(index);
      Program.currentGame.player.gold -= item.value;
      return item;
    }

    public Shield purchaseShield(int index)
    {
      Shield item = this.shields[index];
      this.shields.RemoveAt(index);
      Program.currentGame.player.gold -= item.value;
      return item;
    }

    public Potion purchasePotion(int index)
    {
      Potion item = this.potions[index];
      this.potions.RemoveAt(index);
      Program.currentGame.player.gold -= item.value;
      return item;
    }
  }
}
