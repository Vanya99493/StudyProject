using _Patterns.PauseController;
using UnityEngine;

namespace _Patterns.LevelImplementation
{
	public class CubeMover : MonoBehaviour, IPausable
	{
		[SerializeField] private float _speed;
		
		public bool IsPaused { get; private set; }

		public void FixedUpdate()
		{
			Rotate();
		}

		public void Reset()
		{
			transform.rotation = Quaternion.identity;
		}

		public void Pause()
		{
			IsPaused = true;
		}

		public void Unpause()
		{
			IsPaused = false;
		}

		private void Rotate()
		{
			if (IsPaused)
			{
				return;
			}
			
			transform.RotateAround(transform.position, Vector3.up, _speed * Time.fixedDeltaTime);
		}
	}
}