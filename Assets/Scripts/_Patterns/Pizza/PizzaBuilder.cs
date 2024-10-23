using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Patterns
{
	public class PizzaBuilder : MonoBehaviour, IPizzaBuilder
	{
		private Pizza _pizza = new ();
		private List<ICommand> _commands = new ();
		
		public void AddSauce()
		{
			ICommand command = new AddSauceCommand();
			command.Execute(_pizza);
			_commands.Add(command);
		}

		public void AddCheese()
		{
			ICommand command = new AddCheeseCommand();
			command.Execute(_pizza);
			_commands.Add(command);
		}

		public void AddPepperoni()
		{
			ICommand command = new AddPepperoniCommand();
			command.Execute(_pizza);
			_commands.Add(command);
		}

		public void AddMushrooms()
		{
			ICommand command = new AddMushroomsCommand();
			command.Execute(_pizza);
			_commands.Add(command);
		}

		public void Undo()
		{
			var command = _commands.Last();
			command.Undo(_pizza);
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