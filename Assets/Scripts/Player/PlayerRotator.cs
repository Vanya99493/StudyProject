using UnityEngine;

namespace StudyProj.Player
{
	public class PlayerRotator : MonoBehaviour
	{
		[SerializeField] private GameObject _head;
		[SerializeField] private float _rotationSpeed;

		private float _currentRotationInputX;
		private float _currentRotationY;

        private void Awake()
        {
	        _currentRotationInputX = transform.rotation.eulerAngles.y;
        }
        
		private void Update()
		{
			_currentRotationInputX = Input.GetAxis("Mouse X");
			_currentRotationY += Input.GetAxis("Mouse Y");
			_currentRotationY = Mathf.Clamp(_currentRotationY, -90f, 90f);
		}

		private void LateUpdate()
		{
			transform.Rotate(Vector3.up * (_currentRotationInputX * _rotationSpeed * Time.fixedDeltaTime));
			
			_head.transform.localRotation = Quaternion.Euler(-_currentRotationY * _rotationSpeed * Time.fixedDeltaTime, 0, 0);
		}
	}
}