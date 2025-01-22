using System.Collections.Generic;
using UnityEngine;

namespace TheGloryHunter.Configs
{
	[CreateAssetMenu(fileName = "EnemiesConfig", menuName = "TheGloryHunter/Configs/EnemiesConfig")]
	public class EnemiesConfig : ScriptableObject
	{
		public List<EnemyData> Enemies;
	}
}