using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    public class RecipesSingleton
    {
        private static RecipesSingleton instance;
        private Dictionary<int, Recipe> recipes;

        private RecipesSingleton()
        {
            recipes = new Dictionary<int, Recipe>();
            LoadRecipes();
        }

        private void LoadRecipes()
        {
            //recipes.Add(0, new WoodFrameRecipe());
            recipes.Add(10, new StoneAxeRecipe());
        }

        public void DisplayRecipes()
        {
            foreach (KeyValuePair<int, Recipe> kv in recipes)
            {
                Console.Out.WriteLine($"  ({ kv.Key }) {kv.Value.name}");
            }
            Console.Out.WriteLine();
            Console.Out.Write(" > ");
            try
            {
                int input = int.Parse(Console.In.ReadLine());
                Console.In.Close();
                if (recipes.ContainsKey(input))
                {
                    recipes[input].AttemptCrafting();
                }
            }
            catch (FormatException fe)
            {
                Console.In.Close();
            }


        }

        public static RecipesSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RecipesSingleton();
                }
                return instance;
            }
        }
    }


}
