using _Patterns.LevelImplementation;
using _Patterns.PauseController;
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

		public void Initialize(IPauseHandler pauseHandler, ILevelController levelController)
		{
			_resumeButton.onClick.AddListener(pauseHandler.UnpauseSession);
			_exitButton.onClick.AddListener(levelController.StopLevel);
			_exitButton.onClick.AddListener(pauseHandler.UnpauseSession);
		}
	}
}