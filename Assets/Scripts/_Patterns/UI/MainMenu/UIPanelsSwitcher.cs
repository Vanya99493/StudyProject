using System.Collections.Generic;
using _Patterns.LevelImplementation;
using _Patterns.PauseController;
using Extensions;
using UnityEngine;

namespace _Patterns.UI.MainMenu
{
	public class UIPanelsSwitcher : MonoBehaviour, IUIMediator
	{
		[SerializeField] private MainMenuPanel _mainMenuPanel;
		[SerializeField] private SettingsPanel _settingsPanel;
		[SerializeField] private StartLevelPanel _startLevelPanel;
		[SerializeField] private PausePanel _pausePanel;
		[SerializeField] private GameHudPanel _gameHudPanel;
		
		private Dictionary<PanelType, BaseMediatablePanel> _mediatablePanels;
		private readonly Dictionary<PanelType, BaseMediatablePanel> _currentOpenPanels = new ();

		public void Initialize(IPauseHandler pauseHandler, ILevelController levelController)
		{
			_mediatablePanels = new Dictionary<PanelType, BaseMediatablePanel>()
			{
				{ PanelType.MainMenu, _mainMenuPanel },
				{ PanelType.Settings, _settingsPanel },
				{ PanelType.StartLevel, _startLevelPanel },
				{ PanelType.PauseMenu, _pausePanel },
				{ PanelType.GameHud, _gameHudPanel }
			};
			
			foreach (var panel in _mediatablePanels)
			{
				panel.Value.Initialize(this);
			}
			
			_startLevelPanel.Initialize(levelController);
			_gameHudPanel.Initialize(pauseHandler);
			_pausePanel.Initialize(pauseHandler, levelController);
		}

		public void ActivateStartPanel(PanelType startPanelType)
		{
			foreach (var panel in _mediatablePanels)
			{
				panel.Value.Deactivate();
			}
			
			var startPanel = _mediatablePanels[startPanelType];
			startPanel.Activate();
			_currentOpenPanels.Add(startPanelType, startPanel);
		}

		public void Notify(object sender, MessageType messageType, PanelType panelType)
		{
			switch (messageType)
			{
				case MessageType.OpenNew:
					CloseAllPanels();
					OpenNewPanel(panelType);
					break;
				case MessageType.OpenOnTop:
					OpenNewPanel(panelType);
					break;
				case MessageType.CloseCurrent:
					ClosePanel(panelType);
					break;
			}
		}

		private void CloseAllPanels()
		{
			foreach (var currentOpenPanel in _currentOpenPanels)
			{
				currentOpenPanel.Value.Deactivate();
			}
			_currentOpenPanels.Clear();
		}

		private void OpenNewPanel(PanelType panelType)
		{
			var panel = _mediatablePanels[panelType];
			panel.Activate();
			_currentOpenPanels.Add(panelType, panel);
		}

		private void ClosePanel(PanelType panelType)
		{
			 _currentOpenPanels[panelType].Deactivate();
			 _currentOpenPanels.Remove(panelType);
		}
	}
}