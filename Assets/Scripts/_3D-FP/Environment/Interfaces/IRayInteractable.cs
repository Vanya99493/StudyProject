namespace StudyProj.Environment
{
	public interface IRayInteractable
	{
		public bool IsActive { get; }

		void Activate();
		void Deactivate();
	}
}