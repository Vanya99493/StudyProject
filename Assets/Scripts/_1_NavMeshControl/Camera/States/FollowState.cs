using UnityEngine;

namespace _1_NavMeshControl.CameraModule
{
	public class FollowState : CameraState
	{
		private Transform _targetTransform;

		public override CameraStateType CameraStateType => CameraStateType.Follow;
		
		public FollowState(CameraController cameraController, Transform targetTransform, Vector3 offset) : base(cameraController, offset)
		{
			_targetTransform = targetTransform;
		}

		public override void Enter()
		{
			_cameraController.SetCameraPosition(_targetTransform.position + _offset);
		}

		public override void Update()
		{
			_cameraController.SetCameraPosition(_targetTransform.position + _offset);
		}

		public override void Exit() { }
	}
}