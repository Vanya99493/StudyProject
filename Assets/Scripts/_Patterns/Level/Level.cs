using _Patterns.PauseController;
using Extensions;
using UnityEngine;

namespace _Patterns.LevelImplementation
{
	public class Level : MonoBehaviour, IPausable, ILevelController
	{
		[SerializeField] private CubeMover _cubeMover;

		public bool IsPaused { get; private set; }

		private void Start()
		{
			_cubeMover.Deactivate();
		}

		public void StartLevel()
		{
			ResetLevel();
			_cubeMover.Activate();
		}

		public void ResetLevel()
		{
			_cubeMover.Reset();
		}

		public void StopLevel()
		{
			_cubeMover.Deactivate();
		}

		public void Pause()
		{
			IsPaused = true;
			
			_cubeMover.Pause(); // is it good or I need to subscribe all IPausable to PauseHandler 
		}

		public void Unpause()
		{
			IsPaused = false;
			
			_cubeMover.Unpause(); // is it good or I need to subscribe all IPausable to PauseHandler 
		}
	}
}