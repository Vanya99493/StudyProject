using UnityEngine;

namespace _Patterns.UI.MainMenu
{
	public class BaseMediatablePanel : MonoBehaviour
	{
		protected IUIMediator _uiMediator;
		
		public void Initialize(IUIMediator uiMediator)
		{
			_uiMediator = uiMediator;
		}
	}
}