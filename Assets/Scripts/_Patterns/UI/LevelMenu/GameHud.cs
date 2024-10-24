using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Patterns.UI.LevelMenu
{
	public class GameHud : MonoBehaviour
	{
		public event Action<int> ButtonPressedEvent;
		
		[SerializeField] private Button[] _spellButtons;

		private void Awake()
		{
			for (int i = 0; i < _spellButtons.Length; i++)
			{
				int index = i;
				_spellButtons[i].onClick.AddListener(() => HandleButtonPressed(index));
			}
		}

		private void HandleButtonPressed(int buttonIndex) => ButtonPressedEvent?.Invoke(buttonIndex);
	}
}