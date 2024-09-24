using UnityEngine;

namespace _Pattern_builder
{
	public class PizzaBuilder : MonoBehaviour, IPizzaBuilder
	{
		private Pizza _pizza = new ();
		
		public void AddSauce()
		{
			_pizza.AddIngredient(PizzaIngredient.Sauce);
		}

		public void AddCheese()
		{
			_pizza.AddIngredient(PizzaIngredient.Cheese);
		}

		public void AddPepperoni()
		{
			_pizza.AddIngredient(PizzaIngredient.Pepperoni);
		}

		public void AddMushrooms()
		{
			_pizza.AddIngredient(PizzaIngredient.Mushrooms);
		}

		public Pizza GetProduct() 
		{
			return _pizza;
		}

		public void ResetPizza()
		{
			_pizza = new ();
		}
	}
}