namespace _Patterns
{
	public class AddCheeseCommand : ICommand
	{
		private readonly PizzaIngredient _pizzaIngredient = PizzaIngredient.Cheese;
		
		public void Execute(Pizza pizza)
		{
			pizza.AddIngredient(_pizzaIngredient);
		}

		public void Undo(Pizza pizza)
		{
			pizza.RemoveIngredient(_pizzaIngredient);
		}
	}
}