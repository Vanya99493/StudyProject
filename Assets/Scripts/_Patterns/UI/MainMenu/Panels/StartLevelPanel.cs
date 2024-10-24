using _Patterns.LevelImplementation;
using UnityEngine;
using UnityEngine.UI;

namespace _Patterns.UI.MainMenu
{
	public class StartLevelPanel : BaseMediatablePanel
	{
		[SerializeField] private Button _mainMenuButton;
		[SerializeField] private Button _startButton;

		private void Start()
		{
			_mainMenuButton.onClick.AddListener(() => _uiMediator.Notify(this, MessageType.OpenNew, PanelType.MainMenu));
			_startButton.onClick.AddListener(() => _uiMediator.Notify(this, MessageType.OpenNew, PanelType.GameHud));
		}

		public void Initialize(ILevelController levelController)
		{
			_startButton.onClick.AddListener(levelController.StartLevel);
		}
	}
}