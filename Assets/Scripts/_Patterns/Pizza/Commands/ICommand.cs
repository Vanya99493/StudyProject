namespace _Patterns
{
	public interface ICommand
	{
		void Execute(Pizza pizza);
		void Undo(Pizza pizza);
	}
}