using System;
using System.Collections.Generic;
using System.Text;

namespace Objective1._4CreateAndImplementEventsAndCallbacks
{
   public class Methods
   {
      public string CalculateAgeEra(int year)
      {
         int currentyear = DateTime.Now.Year - year;

         if (currentyear < 2)
            return "PS4 XBOXONE Era";
         else if (currentyear < 10)
            return "PS3 XBOX Era";
         else if (currentyear < 17)
            return "PS2 GameCube Era";
         else if (currentyear < 21)
            return "PS1 Nintentdo 64 Era";
         else if (currentyear < 31)
            return "Nes Amiga Era";
         else
            return "Pegasus Era";
      }

      public string UpperCaseName(string s)
      {
         return s.ToUpperInvariant();
      }

      public string LowerCaseName(string s)
      {
         return s.ToLowerInvariant();
      }

      public void Show(string p1, string p2)
      {
         Console.ForegroundColor = ConsoleColor.White;
         Console.Write(p1);
         Console.ForegroundColor = ConsoleColor.Yellow;
         Console.Write(" : ");
         Console.ForegroundColor = ConsoleColor.Green;
         Console.Write(p2);
         Console.ForegroundColor = ConsoleColor.Gray;

      }

      public void Show2(string p1, string p2)
      {
         Console.ForegroundColor = ConsoleColor.Yellow;
         Console.Write(p1);
         Console.ForegroundColor = ConsoleColor.DarkGreen;
         Console.Write(" : ");
         Console.ForegroundColor = ConsoleColor.Magenta;
         Console.Write(p2);
         Console.ForegroundColor = ConsoleColor.Gray;
      }
   }
}
