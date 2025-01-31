using UnityEngine;

namespace ChanceCalculationAlgorithm
{
	public class ChanceCalculator
	{
		private ObjectsChancesContainer _chancesContainer;
		
		public ChanceCalculator(ObjectsChancesContainer chancesContainer)
		{
			_chancesContainer = chancesContainer;
		}

		public Sprite CalculateChance(ConditionRule conditionRule)
		{
			float globalChance = 0f;
			float currentChance = 0f;
			
			foreach (var objectChance in _chancesContainer.ObjectsChances)
			{
				globalChance += CalculateChance(objectChance, conditionRule);
			}

			float randomChance = Random.Range(0f, globalChance);

			foreach (var objectChance in _chancesContainer.ObjectsChances)
			{
				currentChance += CalculateChance(objectChance, conditionRule);
				if (randomChance <= currentChance)
				{
					Debug.Log($"{objectChance.Object.name} (glob. {globalChance}, curr. {randomChance})");
					return objectChance.Object;
				}
			}

			Debug.Log($"{_chancesContainer.ObjectsChances[^1].Object.name} (glob. {globalChance}, curr. {randomChance})");
			return _chancesContainer.ObjectsChances[^1].Object;
		}

		private float CalculateChance(ObjectChance objectChance, ConditionRule conditionRule)
		{
			if (objectChance.RulesChancesMultipliers.TryGetValue(conditionRule, out var multiplier))
			{
				return objectChance.Chance * multiplier;
			}
			return objectChance.Chance;
		}
	}
}