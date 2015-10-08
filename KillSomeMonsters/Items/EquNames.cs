using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Items
{
  public class EquNames
  {
    public static List<string> namesBody = new List<string>();
    public static List<string> namesHead = new List<string>();
    public static List<string> namesShield = new List<string>();
    public static List<string> namesWeapon = new List<string>();
    public static List<string> namesPotionHeal = new List<string>();
    public static List<string> namesPotionDamage = new List<string>();

    static EquNames()
    {
      namesBody.Add("Curias of Valor");
      namesBody.Add("Hardened Tunic");
      namesBody.Add("Vest of Ultimate Power");
      namesBody.Add("Fancy Dress");
      namesBody.Add("Padded Coat");
      namesBody.Add("Plate eMail");
      namesBody.Add("Just a Tie");

      namesHead.Add("Helm of Bravery");
      namesHead.Add("Cap of Protection");
      namesHead.Add("Subtle Hat");
      namesHead.Add("Sleepy Racoon");
      namesHead.Add("Tinfoil Cap");
      namesHead.Add("Folded Paper Hat");
      namesHead.Add("Pointy Helmet");
      namesHead.Add("Horned Helmet");
      namesHead.Add("Shoe");

      namesShield.Add("Tectonic Plate");
      namesShield.Add("Shield of Shielding");
      namesShield.Add("The Great Deflector");
      namesShield.Add("Worn Plank");
      namesShield.Add("Old Pie Tin");

      namesWeapon.Add("Dagger of Stabbing");
      namesWeapon.Add("Pointed Stick");
      namesWeapon.Add("Wrath Hammer");
      namesWeapon.Add("Shoddy Mace");
      namesWeapon.Add("Frying Pan");
      namesWeapon.Add("Boomerang");
      namesWeapon.Add("Claymore");
      namesWeapon.Add("Crooked Shortsword");
      namesWeapon.Add("Magic Wand");

      namesPotionHeal.Add("Potion of Healing");
      namesPotionHeal.Add("Soothing Salve");
      namesPotionHeal.Add("Miracle Drink");
      namesPotionHeal.Add("Aloe Vera");

      namesPotionDamage.Add("Volatile Compound");
      namesPotionDamage.Add("Unstable Fluid");
      namesPotionDamage.Add("Explosive Concotion");
      namesPotionDamage.Add("Fiery Brew");
    }
  }
}
