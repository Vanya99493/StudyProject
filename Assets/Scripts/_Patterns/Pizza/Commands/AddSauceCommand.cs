namespace _Patterns
{
	public class AddSauceCommand : ICommand
	{
		private readonly PizzaIngredient _pizzaIngredient = PizzaIngredient.Sauce;
		
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