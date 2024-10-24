using _Patterns.PlayerImplementation.Spells.Base;
using UnityEngine;

namespace _Patterns.PlayerImplementation.Spells
{
	[CreateAssetMenu(fileName="ShieldSpellStrategy", menuName="Spells/ShieldSpellStrategy")]
	public class ShieldSpellStrategy : SpellStrategy
	{
		[SerializeField] private GameObject _shieldPrefab;
		[SerializeField] private float _duration;
		
		public float Duration => _duration;
		
		public override void CastSpell(Transform origin)
		{
			var shield = Instantiate(_shieldPrefab, origin.position, Quaternion.identity, origin);
			Destroy(shield, _duration);
		}
	}
}