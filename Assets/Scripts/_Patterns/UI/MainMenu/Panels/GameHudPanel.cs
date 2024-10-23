using UnityEngine;
using UnityEngine.UI;

namespace _Patterns.UI.MainMenu
{
	public class GameHudPanel : BaseMediatablePanel
	{
		[SerializeField] private Button _pauseButton;

		public void Start()
		{
			_pauseButton.onClick.AddListener(() => _uiMediator.Notify(this, MessageType.OpenOnTop, PanelType.PauseMenu));
		}
	}
}