using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing
{
    public abstract class ConsoleMethods
    {
        public void ClearConData(int offset)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(30, offset + i);
                Console.WriteLine("                                                                                                      ");
            }
        }

    }
}
