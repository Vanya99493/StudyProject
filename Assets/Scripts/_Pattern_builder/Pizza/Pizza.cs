using System.Collections.Generic;
using System.Text;

namespace _Pattern_builder
{
	public class Pizza
	{
		private List<PizzaIngredient> _pizzaIngredients = new ();

		public void AddIngredient(PizzaIngredient ingredient)
		{
			_pizzaIngredients.Add(ingredient);
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