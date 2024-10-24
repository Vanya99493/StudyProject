using UnityEngine;

namespace _Patterns.LevelImplementation
{
	public class ObjectMover : MonoBehaviour
	{
		[SerializeField] private float _speed;
		[SerializeField] private bool _isMoving = false;

		public void Initialize(float speed)
		{
			_speed = speed;
			_isMoving = true;
		}

		private void FixedUpdate()
		{
			if (!_isMoving)
			{
				return;
			}
			
			transform.Translate(transform.forward * (_speed * Time.fixedDeltaTime), Space.World);
		}
	}
}