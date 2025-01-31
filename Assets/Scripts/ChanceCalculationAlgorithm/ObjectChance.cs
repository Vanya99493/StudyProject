using UnityEngine;
using Utilities;

namespace ChanceCalculationAlgorithm
{
	[CreateAssetMenu(fileName = "ObjectChance", menuName = "TheGloryHunter/Configs/ObjectChance")]
	public class ObjectChance : ScriptableObject
	{
		public float Chance;
		public Sprite Object;
		public SerializableDictionary<ConditionRule, float> RulesChancesMultipliers = new();
	}
}