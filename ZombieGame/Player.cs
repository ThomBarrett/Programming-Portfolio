using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    class Player : Entity
    {
        private Direction direction;
        public Player(int x, int y, Direction direction)
        {
            this.x = x;
            this.y = y;
            SetDirection(direction);
            this.color = ConsoleColor.Black;
        }

        public override void Display(ConsoleColor locationColor)
        {
            Console.BackgroundColor = locationColor;
            Console.ForegroundColor = color;

            Console.Out.Write(symbol);
        }

        public override ConsoleColor GetColor()
        {
            return this.color;
        }

        public override char GetSymbol()
        {
            return this.symbol;
        }

        public Direction GetDirection()
        {
            return direction;
        }

        public void SetDirection(Direction direction)
        {
            this.direction = direction;

            switch (direction)
            {
                case Direction.UP:
                    this.symbol = '^';
                    break;
                case Direction.RIGHT:
                    this.symbol = '>';
                    break;
                case Direction.DOWN:
                    this.symbol = 'v';
                    break;
                case Direction.LEFT:
                    this.symbol = '<';
                    break;
            }
            
        }
    }
}
