using UnityEngine;

namespace _1_NavMeshControl.CameraModule
{
	public class StaticState : CameraState
	{
		public override CameraStateType CameraStateType => CameraStateType.Static;

		public StaticState(CameraController cameraController, Vector3 offset) : base(cameraController, offset) { }

		public override void Enter()
		{
			_cameraController.SetCameraPosition(_offset);
		}

		public override void Update()
		{
			_cameraController.SetCameraPosition(_offset);
		}

		public override void Exit() { }
	}
}