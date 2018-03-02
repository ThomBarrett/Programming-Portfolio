using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<String, List<Object>> Colors = new Dictionary<string, List<object>>();


            List<Object> unsorted = new List<Object>();
             


            int input = int.Parse(Console.In.ReadLine());
            Random rand = new Random();
            for (int i = 0; i < input; i++)
            {
                int gens = rand.Next(1, 10);

                switch (gens) {
                    case 0:
                        unsorted.Add(new Black());
                        break;

                    case 1:
                        unsorted.Add(new Blue());
                        break;

                    case 2:
                        unsorted.Add(new Brown());
                        break;

                    case 3:
                        unsorted.Add(new Gray());
                        break;

                    case 4:
                        unsorted.Add(new Green());
                        break;

                    case 5:
                        unsorted.Add(new Orange());
                        break;

                    case 6:
                        unsorted.Add(new Purple());
                        break;

                    case 7:
                        unsorted.Add(new Red());
                        break;

                    case 8:
                        unsorted.Add(new Yellow());
                        break;
                }
            }


            bool red = false;
            bool blue = false;
            bool yellow = false;
            bool green = false;
            bool gray = false;
            bool brown = false;
            bool orange = false;
            bool purple = false;
            bool black = false;

            foreach (object e in unsorted) {
                switch (e.GetType().Name) {
                    case "Red":
                        List<object> RedList;
                        if (!red) {                        
                            RedList = new List<Object>();
                            RedList.Add(new Red());
                            Colors.Add("Red", RedList);
                            red = true; 
                        }
                        else
                        {
                            Colors["Red"].Add(new Red());
                        }
                        break;

                    case "Blue":
                        List<object> BlueList;
                        if (!blue)
                        {
                            BlueList = new List<Object>();
                            BlueList.Add(new Blue());
                            Colors.Add("Blue", BlueList);
                            blue = true;
                        }
                        else
                        {
                            Colors["Blue"].Add(new Blue());
                        }
                        break;

                    case "Green":
                        List<object> GreenList;
                        if (!green)
                        {
                            GreenList = new List<Object>();
                            GreenList.Add(new Green());
                            Colors.Add("Green", GreenList);
                            green = true;
                        }
                        else
                        {
                            Colors["Green"].Add(new Green());
                        }
                        break;

                    case "Yellow":
                        List<object> YellowList;
                        if (!yellow)
                        {
                            YellowList = new List<Object>();
                            YellowList.Add(new Yellow());
                            Colors.Add("Yellow", YellowList);
                            yellow = true;
                        }
                        else
                        {
                            Colors["Yellow"].Add(new Yellow());
                        }
                        break;

                    case "Brown":
                        List<object> BrownList;
                        if (!brown)
                        {
                            BrownList = new List<Object>();
                            BrownList.Add(new Brown());
                            Colors.Add("Brown", BrownList);
                            brown = true;
                        }
                        else
                        {
                            Colors["Brown"].Add(new Brown());
                        }
                        break;

                    case "Purple":
                        List<object> PurpleList;
                        if (!purple)
                        {
                            PurpleList = new List<Object>();
                            PurpleList.Add(new Purple());
                            Colors.Add("Purple", PurpleList);
                            purple = true;
                        }
                        else
                        {
                            Colors["Purple"].Add(new Purple());
                        }
                        break;

                    case "Orange":
                        List<object> OrangeList;
                        if (!orange)
                        {
                            OrangeList = new List<Object>();
                            OrangeList.Add(new Orange());
                            Colors.Add("Orange", OrangeList);
                            orange = true;
                        }
                        else
                        {
                            Colors["Orange"].Add(new Orange());
                        }
                        break;

                    case "Gray":
                        List<object> GrayList;
                        if (!gray)
                        {
                            GrayList = new List<Object>();
                            GrayList.Add(new Gray());
                            Colors.Add("Gray", GrayList);
                            gray = true;
                        }
                        else
                        {
                            Colors["Gray"].Add(new Gray());
                        }
                        break;

                    case "Black":
                        List<object> BlackList;
                        if (!black)
                        {
                            BlackList = new List<Object>();
                            BlackList.Add(new Black());
                            Colors.Add("Black", BlackList);
                            black = true;
                        }
                        else
                        {
                            Colors["Black"].Add(new Black());
                        }
                        break;
                }
            }

            if (Colors.ContainsKey("Red"))
            {
                foreach(Red e in Colors["Red"])
                {
                    e.Print();
                }
            }

            if (Colors.ContainsKey("Blue"))
            {
                foreach (Blue e in Colors["Blue"])
                {
                    e.Print();
                }
            }

            if (Colors.ContainsKey("Orange"))
            {
                foreach (Orange e in Colors["Orange"])
                {
                    e.Print();
                }
            }

            if (Colors.ContainsKey("Green"))
            {
                foreach (Green e in Colors["Green"])
                {
                    e.Print();
                }
            }

            if (Colors.ContainsKey("Yellow"))
            {
                foreach (Yellow e in Colors["Yellow"])
                {
                    e.Print();
                }
            }

            if (Colors.ContainsKey("Brown"))
            {
                foreach (Brown e in Colors["Brown"])
                {
                    e.Print();
                }
            }

            if (Colors.ContainsKey("Black"))
            {
                foreach (Black e in Colors["Black"])
                {
                    e.Print();
                }
            }

            if (Colors.ContainsKey("Purple"))
            {
                foreach (Purple e in Colors["Purple"])
                {
                    e.Print();
                }
            }

            if (Colors.ContainsKey("Gray"))
            {
                foreach (Gray e in Colors["Gray"])
                {
                    e.Print();
                }
            }


            foreach (KeyValuePair<string, List<object>> entry in Colors)
            {
                Console.Out.WriteLine(entry.Key + ": " + entry.Value.Count().ToString());
            }

            Console.ReadKey();

        }
    }
}
