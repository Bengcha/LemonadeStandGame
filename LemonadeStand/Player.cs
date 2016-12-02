using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Player
    {
        public string name;

        public void ChooseName()
        {
            Console.WriteLine("What will your character name be? \n");
            name = Console.ReadLine();
            if (name.Equals(""))
            {
                Console.WriteLine("Please enter a name for your characte." );
                ChooseName();
            }

            }
        }
        
    }


