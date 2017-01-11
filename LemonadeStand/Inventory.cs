using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Inventory
    {
        public List<Lemon> lemonStorage;
        public List<Ice> iceStorage;
        public List<Cup> cupStorage;
        public List<Sugar> sugarStorage;
        Random RandomStorage = new Random();
        public Dictionary<string, int> Storage = new Dictionary<string, int>();

        public Inventory()
        {
            lemonStorage = new List<Lemon>();
            iceStorage = new List<Ice>();
            cupStorage = new List<Cup>();
            sugarStorage = new List<Sugar>();
        }

        public void DisplayInventory()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nYour Current Supplies");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("You have {0} lemon, {1} Sugar bags, {2} Cup, {3} Ice", lemonStorage.Count(), sugarStorage.Count(), cupStorage.Count(), iceStorage.Count());
            Console.ResetColor();
        }
        public void AddLemon(Lemon lemon)
        {
            lemonStorage.Add(lemon);
        }
        public void AddLemons(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Lemon addLemon = new Lemon();
                AddLemon(addLemon);
            }
        }
        public int RetrieveLemon()
        {
            return lemonStorage.Count();
        }
        public void RemoveLemon()
        {
            lemonStorage.RemoveAt(0);
        }
        public void ResetLemons()
        {
            lemonStorage.Clear();
        }
        public void RemoveCup()
        {
            cupStorage.RemoveAt(0);
        }

        public void RemoveSugar()
        {
            sugarStorage.RemoveAt(0);
        }
        public void RemoveIce()
        {
            iceStorage.RemoveAt(0);
        }
        public int RetrieveCup()
        {
            return cupStorage.Count();
        }

        public int RetreieveSugar()
        {
            return sugarStorage.Count();
        }
        public int RetrieveIce()
        {
            return iceStorage.Count();
        }

        public void AddSugar(Sugar sugar)
        {
            sugarStorage.Add(sugar);
        }
        public void AddCup(Cup cup)
        {
            cupStorage.Add(cup);
        }
        public void AddIce(Ice ice)
        {
            iceStorage.Add(ice);
        }

        public void ResetIce()
        {
            iceStorage.Clear();
        }
        public void ResetSugar()
        {
            sugarStorage.Clear();
        }
        public void ResetCups()
        {
            cupStorage.Clear();
        }
        public void Reset()
        {
            ResetLemons();
            ResetSugar();
            ResetIce();
            ResetCups();
        }
        public void MeltIce()
        {
            Console.WriteLine("All your ice supplies have melted away.");
            ResetIce();
        }

        public void AddIces(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Ice addIce = new Ice();
                AddIce(addIce);
            }
        }
        public void AddCups(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Cup addCup = new Cup();
                AddCup(addCup);
            }
        }
        public void AddSugars(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Sugar addSugar = new Sugar();
                AddSugar(addSugar);
            }
        }

    }
}

