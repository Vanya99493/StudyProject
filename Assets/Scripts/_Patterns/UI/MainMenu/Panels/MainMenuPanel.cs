using UnityEngine;
using UnityEngine.UI;

namespace _Patterns.UI.MainMenu
{
	public class MainMenuPanel : BaseMediatablePanel
	{
		[SerializeField] private Button _startLevelButton;
		[SerializeField] private Button _settingsButton;

		public void Start()
		{
			_startLevelButton.onClick.AddListener(() => _uiMediator.Notify(this, MessageType.OpenNew, PanelType.StartLevel));
			_settingsButton.onClick.AddListener(() => _uiMediator.Notify(this, MessageType.OpenOnTop, PanelType.Settings));
		}
	}
}