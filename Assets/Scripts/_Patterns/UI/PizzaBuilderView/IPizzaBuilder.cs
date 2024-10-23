namespace _Patterns.UI.PizzaBuilderView
{
	public interface IPizzaBuilder
	{
		void AddSauce();
		void AddCheese();
        void AddPepperoni();
        void AddMushrooms();
        void Undo();
	}
}