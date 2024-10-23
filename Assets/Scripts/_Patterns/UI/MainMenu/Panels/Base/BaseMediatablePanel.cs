namespace _Patterns.UI.MainMenu
{
	public class BaseMediatablePanel : BasePanel
	{
		protected IUIMediator _uiMediator;
		
		public void Initialize(IUIMediator uiMediator)
		{
			_uiMediator = uiMediator;
		}
	}
}