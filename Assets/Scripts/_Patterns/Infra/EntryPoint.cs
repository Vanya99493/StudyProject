using UnityEngine;

namespace _Patterns
{
	public class EntryPoint : MonoBehaviour
	{
		[SerializeField] private PizzaBuilder _pizzaBuilder;

		public void PrintPizzaIngredients()
		{
			Debug.Log(_pizzaBuilder.GetProduct().GetPizza());
			_pizzaBuilder.ResetPizza();
		}
	}
}