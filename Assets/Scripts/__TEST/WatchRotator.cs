using UnityEngine;

namespace __TEST
{
	public class WatchRotator : MonoBehaviour
	{
		[Tooltip("An object that will rotate. Root must be in Vector3.zero local coordinates")]
		[SerializeField] private Transform _root;
		
		[Tooltip("Limits by three axis on object rotation")]
		[SerializeField] private Vector3 _rotationLimitAngles;
		
		[Tooltip("The plane from which the forward vector will be calculated")]
		[SerializeField] private Transform _contentPlaneTransform;
		
		[SerializeField] private float _rotationSpeed = 5f;
		[SerializeField] private Transform _followTarget;
		
		private Vector3 _initialRotation = Vector3.zero;

		private void Update()
		{
			RotateWatch();
		}

		private void RotateWatch()
		{
			Vector3 directionToSecondObject2 = (_followTarget.position - _root.position).normalized;

			Quaternion currentGlobalRotation = _root.rotation;
			Quaternion targetRotation = Quaternion.FromToRotation(-_contentPlaneTransform.forward, directionToSecondObject2) * currentGlobalRotation;
			Quaternion localTargetRotation = Quaternion.Inverse(_root.parent.rotation) * targetRotation;

			Vector3 clampedEulerAngles = new Vector3(
				Mathf.Clamp(
					TransformRotationAngle(localTargetRotation.eulerAngles.x),
					_initialRotation.x - _rotationLimitAngles.x,
					_initialRotation.x + _rotationLimitAngles.x
				),
				Mathf.Clamp(
					TransformRotationAngle(localTargetRotation.eulerAngles.y),
					_initialRotation.y - _rotationLimitAngles.y,
					_initialRotation.y + _rotationLimitAngles.y
				),
				Mathf.Clamp(
					TransformRotationAngle(localTargetRotation.eulerAngles.z),
					_initialRotation.z - _rotationLimitAngles.z,
					_initialRotation.z + _rotationLimitAngles.z
				)
			);

			_root.localRotation = Quaternion.Lerp(_root.localRotation, Quaternion.Euler(clampedEulerAngles), _rotationSpeed * Time.deltaTime);
		}
		
		private float TransformRotationAngle(float currentRotationAngle)
		{
			if (currentRotationAngle > 360f / 2f)
			{
				return -(360f - currentRotationAngle);
			}

			return currentRotationAngle;
		}

		private void RotateByProjects()
		{
			Vector3 directionToSecondObject = (_followTarget.position - transform.position).normalized;

			Vector3 horizontalDirection = Vector3.ProjectOnPlane(directionToSecondObject, transform.up).normalized;
			float horizontalAngle = Vector3.SignedAngle(-transform.forward, horizontalDirection, transform.up);

			Vector3 verticalDirection = Vector3.ProjectOnPlane(directionToSecondObject, transform.right).normalized;
			float verticalAngle = Vector3.SignedAngle(-transform.forward, verticalDirection, transform.right);
			
			transform.localRotation = Quaternion.Euler(
				Mathf.Clamp(_initialRotation.x + verticalAngle, _initialRotation.x - _rotationLimitAngles.x, _initialRotation.x + _rotationLimitAngles.x),
				Mathf.Clamp(_initialRotation.y + horizontalAngle, _initialRotation.x - _rotationLimitAngles.y, _initialRotation.x + _rotationLimitAngles.y),
				_initialRotation.z
			);
		}

		private void RotateByLookRotation()
		{
			var x = Quaternion.LookRotation(_followTarget.transform.position - transform.position, transform.up).x;
			transform.rotation = new Quaternion(x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
		}
	}
}