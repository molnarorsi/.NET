using RecipesMVCProject.Models;

namespace RecipesMVCProject.Data
{
    public class Recipes
    {
        readonly List<Recipe> recipes = new()
        {
            new()
            {
                Name = "Hortobágyi Palacsinta Recipe",
                Ingredients = @"Filling
½ cup chopped onions
450 grams of ground veal, chicken, or beef
300 g chopped tomatoes
¼ teaspoon caraway seeds
1 cup water
4 teaspoons paprika
2 tablespoons freshly chopped parsley
½ cup sour cream
¼ cup olive oil
salt and pepper as needed

Crepe
1 cup flour
1 cup milk
4 eggs
Oil as needed

Sauce
Meat broth
1/4 cup flour
1 cup sour cream
Tomatoes
Salt, paprika, and pepper as needed",
                Instructions = @"
Step One
Take a large pan and place it on medium heat. Add olive oil and let it get a little hot. Wash and chop the onion. Add it to the oil and fry until it becomes soft and golden.

Step Two: How to Prepare the Filling?
At this stage, add the minced meat with a bit of water to the pan where you fried the onion. Fry the minced meat with onions until it becomes completely brown. We do not want the whole water to evaporate because the meat broth is needed to make a more delicious sauce.

Step Three: How to prepare the sauce?
Take another pan, and add chopped tomatoes to the pan along with water. Add half a cup of sour cream, paprika, black cumin, and parsley and start mixing. Do this until the sauce is completely thick. Now, sieve the sauce to remove all the extra ingredients from it.

Step Four: How to prepare the Crepe?
Whisk together the eggs, flour, and milk in a medium bowl until smooth. Take a pan and put some oil in it and grease its bottom. Pour about 1/4 spoon of sauce into the pan and rotate it to spread the ingredients. When bubbles form on the Crepe, flip it over and cook the other side until golden brown.
After the dough is ready, take a spoon full of minced meat and put it in the dough. Wrap the dough in the desired way and set it aside. Pour the remaining sauce over the Hortobágyi Palacsinta."
            }
        };

        public IEnumerable<Recipe> List()
        => recipes;

        public Recipe FindById(Guid recipeId)
        => recipes.Single(recipe => recipe.ID == recipeId);

        public void Add(Recipe recipe)
        => recipes.Add(recipe);

        public void Update(Recipe newRecipe)
        {
            var oldRecipe = recipes.Single(r => r.ID == newRecipe.ID);

            oldRecipe.Name = newRecipe.Name;
            oldRecipe.Ingredients = newRecipe.Ingredients;
            oldRecipe.Instructions = newRecipe.Instructions;
        }

        public void Remove(Guid recipeId)
        => recipes.Remove(FindById(recipeId));
    }
}
