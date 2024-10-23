using UnityEngine;
using UnityEngine.UI;

namespace _Patterns.UI.MainMenu
{
	public class StartLevelPanel : BaseMediatablePanel
	{
		[SerializeField] private Button _mainMenuButton;
		[SerializeField] private Button _startButton;

		public void Start()
		{
			_mainMenuButton.onClick.AddListener(() => _uiMediator.Notify(this, MessageType.OpenNew, PanelType.MainMenu));
			_startButton.onClick.AddListener(() => _uiMediator.Notify(this, MessageType.OpenNew, PanelType.GameHud));
		}
	}
}