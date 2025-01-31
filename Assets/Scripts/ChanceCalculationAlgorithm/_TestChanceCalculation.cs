using UnityEngine;

namespace ChanceCalculationAlgorithm
{
	public class _TestChanceCalculation : MonoBehaviour
	{
		[SerializeField] private ObjectsChancesContainer _chancesContainer;
		[SerializeField] private ConditionRule _currentConditionRule;
		
		private ChanceCalculator _chanceCalculator;

		private void Awake()
		{
			_chanceCalculator = new ChanceCalculator(_chancesContainer);
		}

		[ContextMenu("Calculate chance")]
		public void CalculateChance()
		{
			_chanceCalculator.CalculateChance(_currentConditionRule);
			//Debug.Log(_chanceCalculator.CalculateChance().name);
		}
	}
}