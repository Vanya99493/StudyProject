namespace _Patterns.UI.MainMenu
{
	public interface IUIMediator
	{
		void Notify(object sender, MessageType messageType, PanelType panelType);
	}
}