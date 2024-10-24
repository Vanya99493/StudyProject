using _Patterns.PlayerImplementation.Spells.Base;
using _Patterns.UI.LevelMenu;
using UnityEngine;

namespace _Patterns.PlayerImplementation
{
	public class Player : MonoBehaviour
	{
		[SerializeField] private SpellStrategy[] _spellStrategies;
		[SerializeField] private GameHud _gameHud;

		private void OnEnable()
		{
			_gameHud.ButtonPressedEvent += CastSpell;
		}

		private void OnDisable()
		{
			_gameHud.ButtonPressedEvent -= CastSpell;
		}

		private void CastSpell(int index)
		{
			_spellStrategies[index].CastSpell(transform);
		}
	}
}