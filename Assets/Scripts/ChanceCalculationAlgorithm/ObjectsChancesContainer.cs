using System.Collections.Generic;
using UnityEngine;

namespace ChanceCalculationAlgorithm
{
	[CreateAssetMenu(fileName = "ObjectsChancesContainer", menuName = "TheGloryHunter/Configs/ObjectsChancesContainer")]
	public class ObjectsChancesContainer : ScriptableObject
	{
		public List<ObjectChance> ObjectsChances = new ();
	}
}