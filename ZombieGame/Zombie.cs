using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    class Zombie : Entity
    {
        private char symbol = 'Z';
        private ConsoleColor foregroundColor = ConsoleColor.Red;
        private uint x, y;

        private int MaxHP = 5;
        private int HP;

        private ZombieState state;

        public Zombie(uint x, uint y)
        {
            this.x = x;
            this.y = y;
            this.HP = MaxHP;
            this.state = ZombieState.ALERT;
        }

        public Zombie(uint x, uint y, int HP, ZombieState state)
        {
            this.x = x;
            this.y = y;
            this.HP = HP;
            this.state = state;
        }

        public override void Display(ConsoleColor locationColor)
        {
            Console.BackgroundColor = locationColor;
            Console.ForegroundColor = foregroundColor;

            Console.Out.Write(symbol);
        }

        public override ConsoleColor GetColor()
        {
            throw new NotImplementedException();
        }

        public override char GetSymbol()
        {
            throw new NotImplementedException();
        }

        public int GetHP()
        {
            return HP;
        }

        public void SetHP(int HP)
        {
            this.HP = HP;
        }

        public ZombieState GetState()
        {
            return state;
        }

        public void ToAlert()
        {
            this.state = ZombieState.ALERT;
        }

        public void ToHunting()
        {
            this.state = ZombieState.HUNTING;
        }

        public void ToStunned()
        {
            this.state = ZombieState.STUNNED;
        }
    }
}
