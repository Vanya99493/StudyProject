using _Patterns.UI.MainMenu;
using UnityEngine;

namespace _Patterns
{
	public class GameSystemEntryPoint : MonoBehaviour
	{
		[SerializeField] private UIPanelsSwitcher _uiPanelsSwitcher;

		private void Awake()
		{
			InitializeUI();
		}

		private void InitializeUI()
		{
			// =====
			_uiPanelsSwitcher.StartLevelEvent += OnLevelStart;
			_uiPanelsSwitcher.EndLevelEvent += OnLevelReset;
			_uiPanelsSwitcher.PauseEvent += Onpause;
			_uiPanelsSwitcher.UnpauseEvent += OnUnpause;
			// =====
			
			_uiPanelsSwitcher.ActivateStartPanel(PanelType.MainMenu);
		}

		private void OnLevelStart()
		{
			Debug.Log("OnLevelStart");
		}

		private void OnLevelReset()
		{
			Debug.Log("OnLevelReset");
		}

		private void Onpause()
		{
			Debug.Log("Onpause");
		}

		private void OnUnpause()
		{
			Debug.Log("OnUnpause");
		}
	}
}