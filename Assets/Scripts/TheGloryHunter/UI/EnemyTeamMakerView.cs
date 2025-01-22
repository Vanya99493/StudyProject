using TMPro;
using UnityEngine;

namespace TheGloryHunter.UI
{
	public class EnemyTeamMakerView : MonoBehaviour
	{
		[SerializeField] private TMP_Text _enemyTeamText;
		[SerializeField] private EnemyTeamMaker _enemyTeamMaker;
		[Space(5)] 
		[SerializeField] private int _enemyTeamWeight;
		[SerializeField] private int _tolerance;
		[SerializeField] private int _maxEnemyTeamCount;
		[SerializeField] private int _maxEnemyWeight;

		[ContextMenu("Calculate enemy team")]
		public void CalculateEnemyTeam()
		{
			var enemyTeam = _enemyTeamMaker.CalculateEnemyTeam(_enemyTeamWeight, _tolerance, _maxEnemyTeamCount, _maxEnemyWeight);

			_enemyTeamText.text = "";
			foreach (var enemyData in enemyTeam)
			{
				_enemyTeamText.text += $"{enemyData.Name} ({enemyData.Weight})\n";
			}
		}
	}
}