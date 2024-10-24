namespace _Patterns.PauseController
{
	public interface IPausable
	{
		bool IsPaused { get; }
		
		void Pause();
		void Unpause();
	}
}