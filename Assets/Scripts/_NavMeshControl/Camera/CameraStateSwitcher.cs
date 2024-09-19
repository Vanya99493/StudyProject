using UnityEngine;

namespace _1_NavMeshControl.CameraModule
{
	public class CameraStateSwitcher : MonoBehaviour
	{
		[SerializeField] private CameraController _cameraController;

		public void SwitchCameraState()
		{
			CameraStateType currentCameraStateType = _cameraController.CurrentCameraStateType;
			
			_cameraController.SetState(currentCameraStateType switch
			{
				CameraStateType.Static => CameraStateType.Follow,
				CameraStateType.Follow => CameraStateType.Static,
				_ => currentCameraStateType
			});
		}
	}
}