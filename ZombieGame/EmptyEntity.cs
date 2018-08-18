using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    /// <summary>
    /// EmptyEntity is used if a empty Entity space is required.
    /// Inherits from Entity. <see cref="ZombieGame.Entity"/>
    /// </summary>
    class EmptyEntity : Entity
    {
        /// <summary>
        /// This function should never be called by an EmptyEntity.
        /// </summary>
        public override void Display(ConsoleColor locationColor)
        {
            throw new IllegialStateException();
        }

        /// <summary>
        /// This function should never be called by an EmptyEntity.
        /// </summary>
        public override ConsoleColor GetColor()
        {
            throw new IllegialStateException();
        }

        /// <summary>
        /// This function should never be called by an EmptyEntity.
        /// </summary>
        public override char GetSymbol()
        {
            throw new IllegialStateException();
        }
    }
}
