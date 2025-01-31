using System.Collections.Generic;
using TheGloryHunter.Configs;
using UnityEngine;

namespace TheGloryHunter
{
	public class EnemyTeamMaker : MonoBehaviour
	{
		[SerializeField] private EnemiesConfig _enemiesConfig;

		private List<EnemyData> _closestEnemyTeam;
		private int _closestEnemyWeight;
		
		public List<EnemyData> CalculateEnemyTeam(int globalWeight, int tolerance, int maxTeamCount, int maxEnemyWeight)
		{
			List<List<EnemyData>> enemiesTeams = GetEnemyCombinations(globalWeight, tolerance, maxTeamCount, maxEnemyWeight);

			if (enemiesTeams.Count == 0)
			{
				Debug.Log("None enemies match the level");
				return _closestEnemyTeam;
			}
			
			int enemyTeamIndex = Random.Range(0, enemiesTeams.Count);
			return enemiesTeams[enemyTeamIndex];
		}
		
		private List<List<EnemyData>> GetEnemyCombinations(int levelWeight, int tolerance, int maxTeamCount, int maxEnemyWeight)
		{
			var results = new List<List<EnemyData>>();
			var currentCombo = new List<EnemyData>();
        
			FindCombinations(0, currentCombo, 0, levelWeight, maxEnemyWeight, tolerance, maxTeamCount, results);
        
			return results;
		}
    
		private void FindCombinations(int index, List<EnemyData> currentCombo, int currentWeight, int levelWeight, int maxEnemyWeight, int tolerance, int maxTeamCount, List<List<EnemyData>> results)
		{
			if (currentWeight >= levelWeight - tolerance && currentWeight <= levelWeight + tolerance)
			{
				results.Add(new List<EnemyData>(currentCombo));
			}
			if (currentWeight > levelWeight + tolerance || currentCombo.Count >= maxTeamCount)
			{
				if (results.Count == 0 && Mathf.Abs(currentWeight - levelWeight) < Mathf.Abs(_closestEnemyWeight - levelWeight))
				{
					_closestEnemyTeam = new();
					foreach (var enemyData in currentCombo)
					{
						_closestEnemyTeam.Add(enemyData);
					}
					_closestEnemyWeight = currentWeight;
				}
				
				return;
			}
        
			for (int i = index; i < _enemiesConfig.Enemies.Count; i++)
			{
				if (_enemiesConfig.Enemies[i].Weight <= maxEnemyWeight)
				{
					currentCombo.Add(_enemiesConfig.Enemies[i]);
					FindCombinations(i, currentCombo, currentWeight + _enemiesConfig.Enemies[i].Weight, levelWeight, maxEnemyWeight, tolerance, maxTeamCount, results);
					currentCombo.RemoveAt(currentCombo.Count - 1);
				}
			}
		}
	}
}