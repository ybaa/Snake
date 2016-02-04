using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    class Input
    {
        //list of avaliable keyboard buttons
        private static Hashtable keyTable = new Hashtable();

        //check if particular button is pressed
        public static bool KeyPressed(Keys key)
        {
            if (keyTable[key] == null)
                return false;
            else
                return true;
        }

        //check if button is pressed (necessery fo keyup and keydown
        public static void ChangeState(Keys key, bool state)
        {
            keyTable[key] = state;
        }
    }
}
