using UnityEngine;

namespace _Patterns.PlayerImplementation.Spells.Base
{
	public abstract class SpellStrategy : ScriptableObject
	{
		public abstract void CastSpell(Transform origin);
	}
}