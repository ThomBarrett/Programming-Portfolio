using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace ZombieGame
{
    public static class SoundSystem
    {
        private static SoundPlayer Menusound = new SoundPlayer(@"C:\Users\Thomas Barrett\source\repos\ZombieGame\ZombieGame\Sound\Clunk.wav");
        private static SoundPlayer bitesound = new SoundPlayer(@"C:\Users\Thomas Barrett\source\repos\ZombieGame\ZombieGame\Sound\Bite.wav");
        public static void PlayEnterSound()
        {
            Menusound.Play();
        }

        public static void PlayBiteSound()
        {
            bitesound.Play();
        }
    }
}
