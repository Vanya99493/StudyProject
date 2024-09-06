using UnityEngine;

namespace _1_NavMeshControl.CameraModule
{
	public abstract class CameraState
	{
		protected CameraController _cameraController;
		protected Vector3 _offset;

		public abstract CameraStateType CameraStateType { get; }
		
		public CameraState(CameraController cameraController, Vector3 offset)
		{
			_cameraController = cameraController;
			_offset = offset;
		}
		
		public abstract void Enter();
		public abstract void Update();
		public abstract void Exit();
	}
}