using System;
using System.Collections.Generic;
using Utilities;
using UnityEngine;

namespace _Patterns.UI.MainMenu
{
	public class UIPanelsSwitcher : MonoBehaviour, IUIMediator
	{
		// TODO implement some system to invoke this event
		// =====
		public event Action StartLevelEvent;
		public event Action EndLevelEvent;
		public event Action PauseEvent;
		public event Action UnpauseEvent;
		// =====
		
		[SerializeField] private SerializableDictionary<PanelType, BaseMediatablePanel> _panels;
		
		private readonly Dictionary<PanelType, BaseMediatablePanel> _currentOpenPanels = new ();
		
		private void Awake()
		{
			foreach (var panel in _panels)
			{
				panel.Value.Initialize(this);
			}
		}

		public void ActivateStartPanel(PanelType startPanelType)
		{
			foreach (var panel in _panels)
			{
				panel.Value.Deactivate();
			}
			
			var startPanel = _panels[startPanelType];
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
			var panel = _panels[panelType];
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