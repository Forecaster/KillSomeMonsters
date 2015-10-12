using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillSomeMonsters.Exceptions
{
  public class EffectException : Exception
  {
    public EffectException(string message) : base(message) { }
  }
}
