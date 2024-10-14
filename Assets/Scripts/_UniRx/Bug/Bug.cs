using _UniRx.Interfaces;
using UnityEngine;

namespace _UniRx.BugModule
{
	public class Bug : MonoBehaviour, IClickable, IDestroyable
	{
		[SerializeField] private float _speed = 5f;

		private Vector2 _moveDirection;
		
		public void Initialize(Vector2 moveDirection)
		{
			_moveDirection = moveDirection.normalized;
		}

		private void FixedUpdate()
		{
			Move();
		}

		private void Move()
		{
			transform.position += new Vector3(_moveDirection.x, _moveDirection.y, 0f) * (_speed * Time.fixedDeltaTime);
		}

		public void Click()
		{
			Destroy();
		}

		public void Destroy()
		{
			Object.Destroy(gameObject);
		}
	}
}