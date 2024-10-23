namespace _Patterns
{
	public class AddMushroomsCommand : ICommand
	{
		private readonly PizzaIngredient _pizzaIngredient = PizzaIngredient.Mushrooms;
		
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