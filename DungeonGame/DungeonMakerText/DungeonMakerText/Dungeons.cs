using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMakerText
{
    class Dungeons : Place
    {
        private Town town;
        private Player player;

        private int rownum;
        private int columnum;
        private int entryrow, entrycol;

        private bool generated = false;
        DungeonLocation[,] dungeon;
        public Dungeons() {
            
        }
        private void GenerateDungeon(int row, int col) 
        {
            
            this.rownum = row;
            this.columnum = col;
            dungeon = new DungeonLocation[rownum, columnum];

            int randrow, randcol;

            Random rand = new Random();

            randrow = rand.Next(1, rownum - 1);
            randcol = rand.Next(1, columnum - 1);

            for (int r = 0; r < rownum; r++)
            {
                for (int c = 0; c < columnum; c++)
                {
                    if (r == 0 || r == rownum - 1)
                    {
                        dungeon[r, c] = new DungeonLocation("HardBlock", r,c);
                    }
                    else if (c == 0 || c == columnum - 1)
                    {
                        dungeon[r, c] = new DungeonLocation("HardBlock", r, c);
                    }
                    else
                    {
                        dungeon[r, c] = new DungeonLocation("SoftBlock", r, c);
                    }

                    if (r == randrow && c == randcol)
                    {
                        this.entryrow = r; this.entrycol = c;
                        Player.row = r; Player.col = c;
                        dungeon[r, c] = new DungeonLocation("LadderBlock", r, c);
                    }
                }
            }
            this.generated = true;
        }
        public void DrawDungeon(Player player)
        {
            this.player = player;
            int count = 0;
            //19 Space Required.
            Console.Out.Write("                   ");
            for (int r = 0; r < this.rownum; r++)
            {
                for (int c = 0; c < this.columnum; c++)
                {
                    this.dungeon[r, c].DisplayVisuals();

                }
                Console.Out.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                int length;
                int whitespace = 19;
                switch (count)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Out.Write("  " + Player.playerName);
                        length = player.GetName().Length + 2;
                        whitespace -= length;

                        for (int i = 0; i < whitespace; i++)
                        {
                            Console.Write(" ");
                        }
                        break;
                    case 1:

                        Console.Out.Write("  HP:  ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Out.Write(player.GetStat("HP").ToString());
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Out.Write("/");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Out.Write(player.GetStat("MaxHP").ToString());

                        length = player.GetStat("HP").ToString().Length + 8 + player.GetStat("MaxHP").ToString().Length;
                        whitespace -= length;

                        for (int i = 0; i < whitespace; i++)
                        {
                            Console.Write(" ");
                        }

                        break;

                    case 2:
                        Console.Out.Write("  MP:  ");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Out.Write(player.GetStat("MP").ToString());
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Out.Write("/");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Out.Write(player.GetStat("MaxMP").ToString());
                        length = player.GetStat("MP").ToString().Length + 8 + player.GetStat("MaxMP").ToString().Length;
                        whitespace -= length;

                        for (int i = 0; i < whitespace; i++)
                        {
                            Console.Write(" ");
                        }
                        break;

                    case 3:
                        Console.Out.Write("  ATK: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Out.Write(player.GetStat("ATK").ToString());
                        length = player.GetStat("ATK").ToString().Length + 7;
                        whitespace -= length;

                        for (int i = 0; i < whitespace; i++)
                        {
                            Console.Write(" ");
                        }
                        break;

                    case 4:
                        Console.Out.Write("  DEF: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Out.Write(player.GetStat("DEF").ToString());
                        length = player.GetStat("DEF").ToString().Length + 7;
                        whitespace -= length;

                        for (int i = 0; i < whitespace; i++)
                        {
                            Console.Write(" ");
                        }
                        break;

                    case 5:
                        Console.Out.Write("  STR: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Out.Write(player.GetStat("STR").ToString());
                        length = player.GetStat("STR").ToString().Length + 7;
                        whitespace -= length;

                        for (int i = 0; i < whitespace; i++)
                        {
                            Console.Write(" ");
                        }
                        break;

                    case 6:
                        Console.Out.Write("  SPD: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Out.Write(player.GetStat("SPD").ToString());
                        length = player.GetStat("SPD").ToString().Length + 7;
                        whitespace -= length;

                        for (int i = 0; i < whitespace; i++)
                        {
                            Console.Write(" ");
                        }
                        break;

                    case 7:
                        Console.Out.Write("  CON: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Out.Write(player.GetStat("CON").ToString());
                        length = player.GetStat("CON").ToString().Length + 7;
                        whitespace -= length;

                        for (int i = 0; i < whitespace; i++)
                        {
                            Console.Write(" ");
                        }
                        break;

                    case 8:
                        Console.Out.Write("  WIS: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Out.Write(player.GetStat("WIS").ToString());
                        length = player.GetStat("WIS").ToString().Length + 7;
                        whitespace -= length;

                        for (int i = 0; i < whitespace; i++)
                        {
                            Console.Write(" ");
                        }
                        break;

                    case 10:
                        Console.Out.Write("  SMP:  ");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Out.Write(player.GetStat("SMP").ToString());
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Out.Write("/");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Out.Write(player.GetStat("MaxSMP").ToString());
                        length = player.GetStat("SMP").ToString().Length + 9 + player.GetStat("MaxSMP").ToString().Length;
                        whitespace -= length;

                        for (int i = 0; i < whitespace; i++)
                        {
                            Console.Write(" ");
                        }
                        break;

                    default:
                        Console.Out.Write("                   ");
                        break;
                }
                count++;
                Console.ForegroundColor = ConsoleColor.Green;
            }
            CheckIfEnemyLocation();
            GetPlayerInput();

        }

        public void GetPlayerInput() {
            while (true)
            {
                ConsoleKeyInfo playerinput = Console.ReadKey(true);
                if (playerinput.Key == ConsoleKey.UpArrow)
                {
                    if (Player.orientation.Equals('▴'))
                    {
                        if(dungeon[Player.row-1, Player.col].GetGraphic() == '▒' || dungeon[Player.row - 1, Player.col].GetGraphic() == '▓')
                        {

                        }else
                        {
                            dungeon[Player.row, Player.col].ToggleCurrent();
                            dungeon[Player.row-1, Player.col].ToggleCurrent();
                            Player.row -= 1;
                            Update(player);
                            break;

                        }
                        
                    }
                    else
                    {
                        Player.orientation = '▴';
                        Update(player);
                        break;
                    }
                    
                    
                }
                if (playerinput.Key == ConsoleKey.DownArrow)
                {
                    if (Player.orientation.Equals('▾'))
                    {
                        if (dungeon[Player.row + 1, Player.col].GetGraphic() == '▒' || dungeon[Player.row + 1, Player.col].GetGraphic() == '▓')
                        {

                        }
                        else
                        {
                            dungeon[Player.row, Player.col].ToggleCurrent();
                            dungeon[Player.row + 1, Player.col].ToggleCurrent();
                            Player.row += 1;
                            Update(player);
                            break;

                        }
                    }
                    else
                    {
                        Player.orientation = '▾';
                        Update(player);
                        break;
                    }
                     
                }
                if (playerinput.Key == ConsoleKey.RightArrow)
                {
                    if (Player.orientation.Equals('▸'))
                    {
                        if (dungeon[Player.row, Player.col+1].GetGraphic() == '▒' || dungeon[Player.row, Player.col+1].GetGraphic() == '▓')
                        {

                        }
                        else
                        {
                            dungeon[Player.row, Player.col].ToggleCurrent();
                            dungeon[Player.row, Player.col+1].ToggleCurrent();
                            Player.col += 1;
                            Update(player);
                            break;

                        }
                    }
                    else
                    {
                        Player.orientation = '▸';
                        Update(player);
                        break;
                    }

                }
                if (playerinput.Key == ConsoleKey.LeftArrow)
                {
                    if (Player.orientation.Equals('◂'))
                    {
                        if (dungeon[Player.row, Player.col - 1].GetGraphic() == '▒' || dungeon[Player.row, Player.col - 1].GetGraphic() == '▓')
                        {

                        }
                        else
                        {
                            dungeon[Player.row, Player.col].ToggleCurrent();
                            dungeon[Player.row, Player.col - 1].ToggleCurrent();
                            Player.col -= 1;
                            Update(player);
                            break;

                        }
                    }
                    else
                    {
                        Player.orientation = '◂';
                        Update(player);
                        break;
                    }

                }

                if (playerinput.Key == ConsoleKey.D)
                {
                    if(player.GetStat("SMP") > 0)
                    {
                        
                        switch (Player.orientation)
                        {
                            case '▴':
                                if(dungeon[Player.row - 1, Player.col].breakable.GetBreakable())
                                {
                                    player.SMPuse();
                                    dungeon[Player.row - 1, Player.col].Break();
                                    Update(player);
                                }
                                break;
                            case '▾':
                                if (dungeon[Player.row + 1, Player.col].breakable.GetBreakable())
                                {
                                    player.SMPuse();
                                    dungeon[Player.row + 1, Player.col].Break();
                                    Update(player);
                                }
                                
                                break;
                            case '▸':
                                if (dungeon[Player.row, Player.col+1].breakable.GetBreakable())
                                {
                                    player.SMPuse();
                                    dungeon[Player.row, Player.col + 1].Break();
                                    Update(player);
                                }
                                
                                break;
                            case '◂':
                                
                                if (dungeon[Player.row, Player.col-1].breakable.GetBreakable())
                                {
                                    player.SMPuse();
                                    dungeon[Player.row, Player.col - 1].Break();
                                    Update(player);
                                }
                                
                                break;
                            default:
                                break;
                        }
                    }
                    
                }

                if(playerinput.Key == ConsoleKey.E)
                {
                    if(Player.row == entryrow && Player.col == entrycol)
                    {
                        Console.Clear();
                        Leave();
                        break;
                    }
                    
                }

            }
        }

        public void CheckIfEnemyLocation() {
            if (dungeon[Player.row, Player.col].HasSomethingSpawned())
            {
                GameUtils.AnimateLine("OH NO A MONSTER");
            }
        }

        public void Update(Player player) {
            Console.Clear();
            DrawDungeon(player);
        }

        public void PrepareForNextDay() {
            for (int r = 0; r < this.rownum; r++)
            {
                for (int c = 0; c < this.columnum; c++)
                {
                    if(r == Player.row && c == Player.col)
                    {
                        
                    }
                    else
                    {
                        this.dungeon[r, c].Spawn();
                    }

                }
            }
        }

        public void ResetForNextDay()
        {
            for (int r = 0; r < this.rownum; r++)
            {
                for (int c = 0; c < this.columnum; c++)
                {
                    if (r == Player.row && c == Player.col)
                    {

                    }
                    else
                    {
                        this.dungeon[r, c].ResetSpawn();
                    }

                }
            }
        }

        public void Visit(Player player, Town town)
        {
            this.town = town;
            if (generated == false) {
                GenerateDungeon(25,50);
                DrawDungeon(player);
            }
            else
            {
                DrawDungeon(player);
            }
        }

        public void Leave()
        {
            player.HPToMax();
            player.MPToMax();
            player.SMPToMax();
            ResetForNextDay();
            GameUtils.AnimateAwait("You left the dungeon the sun is now setting...");
            Console.Clear();
            PrepareForNextDay();
            town.WhereDoYouWantToVisit();
        }

        public void PassTheTown(Town town) {
            this.town = town;
        }
    }


}
