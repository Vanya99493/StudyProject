using System.Collections.Generic;
using UnityEngine;

namespace _1_NavMeshControl.CameraModule
{
	public class CameraController : MonoBehaviour
	{
		[SerializeField] private Camera _camera;
		[SerializeField] private Transform _targetTransform;
		[SerializeField] private Vector3 _followOffset;
		[SerializeField] private Vector3 _staticOffset;
		[SerializeField] private float _cameraMoveTime; 
		[SerializeField] private CameraStateType _cameraStateByDefault;

		private Dictionary<CameraStateType, CameraState> _states;
		private CameraState _currentState;

		private float _currentCameraMoveTime;
		
		public CameraStateType CurrentCameraStateType => _currentState.CameraStateType;
		
		private void Awake()
		{
			_states = new Dictionary<CameraStateType, CameraState>()
			{
				{ CameraStateType.Static, new StaticState(this, _staticOffset) },
				{ CameraStateType.Follow, new FollowState(this, _targetTransform, _followOffset) }
			};
			
			SetState(_cameraStateByDefault);
		}

		private void LateUpdate()
		{
			_currentState?.Update();
		}

		public void SetState(CameraStateType cameraStateType)
		{
			_currentCameraMoveTime = 0f;
			_currentState?.Exit();
			_currentState = _states[cameraStateType];
			_currentState.Enter();
		}

		public void SetCameraPosition(Vector3 newPosition)
		{
			_camera.transform.position = Vector3.Lerp(_camera.transform.position, newPosition, _currentCameraMoveTime);
			_currentCameraMoveTime = Mathf.Min(_currentCameraMoveTime + Time.deltaTime, _cameraMoveTime);
		}
	}
}