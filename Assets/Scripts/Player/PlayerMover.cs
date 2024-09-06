using UnityEngine;

namespace StudyProj.Player
{
	public class PlayerMover : MonoBehaviour
	{
		[SerializeField] private float _speed;
		
		private float _horizontalInput;
		private float _verticalInput;
        
		private void Update()
		{
			_horizontalInput = Input.GetAxis("Horizontal");
			_verticalInput = Input.GetAxis("Vertical");
		}

		private void FixedUpdate()
		{
			Move();
		}

		private void Move()
		{
			Vector3 velocity = new Vector3(_horizontalInput, 0, _verticalInput) * (_speed * Time.fixedDeltaTime);
			transform.Translate(new Vector3(
				velocity.x,
				velocity.y,
				velocity.z
			));
		}
	}
}