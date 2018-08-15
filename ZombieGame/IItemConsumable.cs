using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    public interface IItemConsumable
    {
        bool TrueOrFalse();
        int? GetAmmount();
        void AddAmmount(int ammount);
        void MinusAmmount(int ammount);
    }
}
