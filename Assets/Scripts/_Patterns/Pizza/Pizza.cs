using System.Collections.Generic;
using System.Text;

namespace _Patterns
{
	public class Pizza
	{
		private List<PizzaIngredient> _pizzaIngredients = new ();

		public void AddIngredient(PizzaIngredient ingredient)
		{
			_pizzaIngredients.Add(ingredient);
		}

		public void RemoveIngredient(PizzaIngredient ingredient)
		{
			int ingredientIndex = _pizzaIngredients.LastIndexOf(ingredient);
			_pizzaIngredients.RemoveAt(ingredientIndex);
		}

		public string GetPizza()
		{
			StringBuilder stringBuilder = new StringBuilder();

			stringBuilder.Append("Pizza ingredients:\n");
			foreach (var pizzaIngredient in _pizzaIngredients)
			{
				stringBuilder.Append($"\t{pizzaIngredient.ToString()}\n");
			}
			
			return stringBuilder.ToString();
		}
	}
}