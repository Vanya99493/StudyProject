using _Patterns.PauseController;
using UnityEngine;
using UnityEngine.UI;

namespace _Patterns.UI.MainMenu
{
	public class GameHudPanel : BaseMediatablePanel
	{
		[SerializeField] private Button _pauseButton;

		private void Start()
		{
			_pauseButton.onClick.AddListener(() => _uiMediator.Notify(this, MessageType.OpenOnTop, PanelType.PauseMenu));
		}

		public void Initialize(IPauseHandler pauseHandler)
		{
			_pauseButton.onClick.AddListener(pauseHandler.PauseSession);
		}
	}
}