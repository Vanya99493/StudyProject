using _Patterns.LevelImplementation;
using _Patterns.PlayerImplementation.Spells.Base;
using UnityEngine;

namespace _Patterns.PlayerImplementation.Spells
{
	[CreateAssetMenu(fileName = "WaterBallSpellStrategy", menuName = "Spells/WaterBallSpellStrategy")]
	public class WaterBallSpellStrategy : SpellStrategy
	{
		[SerializeField] private GameObject _waterBallPrefab;
		[SerializeField] private float _speed;
		[SerializeField] private float _lifeTime;
		
		public override void CastSpell(Transform origin)
		{
			Vector3 spawnPosition = origin.position + origin.forward;
			
			var waterBall = Instantiate(_waterBallPrefab, spawnPosition, origin.rotation);
			if (waterBall.TryGetComponent(out ObjectMover waterBallMover))
			{
				waterBallMover.Initialize(_speed);
			}
			else
			{
				waterBall.AddComponent<ObjectMover>().Initialize(_speed);
			}
			
			Destroy(waterBall, _lifeTime);
		}
	}
}