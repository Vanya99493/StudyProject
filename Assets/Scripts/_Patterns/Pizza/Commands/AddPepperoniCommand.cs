namespace _Patterns
{
	public class AddPepperoniCommand : ICommand
	{
		private readonly PizzaIngredient _pizzaIngredient = PizzaIngredient.Pepperoni;
		
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