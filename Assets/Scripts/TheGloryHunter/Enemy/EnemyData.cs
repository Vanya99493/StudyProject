using UnityEngine;

namespace TheGloryHunter
{
	[CreateAssetMenu(fileName = "EnemyData", menuName = "TheGloryHunter/Configs/EnemyData")]
	public class EnemyData : ScriptableObject
	{
		public string Name;
		public int Weight;
	}
}