using UnityEngine;
using UnityEngine.UI;

namespace _Patterns.UI.MainMenu
{
	public class PausePanel : BaseMediatablePanel
	{
		[SerializeField] private Button _resumeButton;
		[SerializeField] private Button _settingsButton;
		[SerializeField] private Button _exitButton;

		private void Start()
		{
			_resumeButton.onClick.AddListener(() => _uiMediator.Notify(this, MessageType.CloseCurrent, PanelType.PauseMenu));
			_settingsButton.onClick.AddListener(() => _uiMediator.Notify(this, MessageType.OpenOnTop, PanelType.Settings));
			_exitButton.onClick.AddListener(() => _uiMediator.Notify(this, MessageType.OpenNew, PanelType.MainMenu));
		}
	}
}