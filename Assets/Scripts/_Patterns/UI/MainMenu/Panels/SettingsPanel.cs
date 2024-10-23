using UnityEngine;
using UnityEngine.UI;

namespace _Patterns.UI.MainMenu
{
	public class SettingsPanel : BaseMediatablePanel
	{
		[SerializeField] private Button _returnButton;

		public void Start()
		{
			_returnButton.onClick.AddListener(() => _uiMediator.Notify(this, MessageType.CloseCurrent, PanelType.Settings));
		}
	}
}