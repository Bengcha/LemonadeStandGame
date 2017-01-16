using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    interface iFill
    {
        void Fill(Inventory inventory, Player player);
    }
}
