using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMakerText
{
    class DungeonLocation
    {
        public Breakable breakable;
        public Spawnable spawnable;

        private char visuals;
        private int x, y;
        private bool currentLocation;
        private bool spawned = false;

        public DungeonLocation(string input, int x, int y)
        {
            if (input.Equals("SoftBlock"))
            {
                breakable = new Breaking();
                spawnable = new CannotSpawn();
                visuals = '▒';
            }
            if (input.Equals("HardBlock"))
            {
                breakable = new UnBreaking();
                spawnable = new CannotSpawn();
                visuals = '▓';
            }

            if (input.Equals("LadderBlock"))
            {
                breakable = new UnBreaking();
                spawnable = new CannotSpawn();
                visuals = '║';
                currentLocation = true;
            }
        }

        public void Spawn()
        {
            if (spawnable.TryToSpawn())
            {
                spawned = true;
            }
        }

        public void Break() {

            if (breakable.Break())
            {
                visuals = ' ';
                breakable = new UnBreaking();
                spawnable = new CanSpawn();
            }
        }

        public void DisplayVisuals() {
            if (currentLocation)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;                
                Console.Out.Write(Player.orientation);
                Console.OutputEncoding = System.Text.Encoding.UTF8;
            }
            else if(spawned == true)
            {
                Console.Out.Write('#');
            }
            else
            {
                Console.Out.Write(visuals);
            }
            
        }

        public char GetGraphic()
        {
            return this.visuals;
        }

        public void ToggleCurrent()
        {
            if (currentLocation == true)
            {
                currentLocation = false;
            }
            else
            {
                currentLocation = true;
            }
        }

        public void ResetSpawn()
        {
            spawned = false;
        }

        public bool HasSomethingSpawned()
        {
            return spawned;
        }
    }
}
