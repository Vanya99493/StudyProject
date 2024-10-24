using _Patterns.LevelImplementation;
using _Patterns.PauseController;
using _Patterns.UI.MainMenu;
using UnityEngine;

namespace _Patterns
{
	public class GameSystemEntryPoint : MonoBehaviour
	{
		[SerializeField] private UIPanelsSwitcher _uiPanelsSwitcher;
		[SerializeField] private PauseHandler _pauseHandler;
		[SerializeField] private Level _level;

		private void Awake()
		{
			InitializeUI();
			InitializePauseHandler();
		}

		private void OnDisable()
		{
			DeinitializePauseHandler();
		}

		private void InitializeUI()
		{
			_uiPanelsSwitcher.Initialize(_pauseHandler, _level);
			_uiPanelsSwitcher.ActivateStartPanel(PanelType.MainMenu);
		}

		private void InitializePauseHandler()
		{
			_pauseHandler.AddSubscriber(_level);
		}

		private void DeinitializePauseHandler()
		{
			_pauseHandler.RemoveSubscriber(_level);
		}
	}
}