using UnityEngine;
using UnityEngine.Events;

namespace _1_NavMeshControl.Player
{
	public class PlayerInputHandler : MonoBehaviour
	{
		[Header("Mouse input events")]
		[SerializeField] private UnityEvent LeftMouseClickUnityEvent;
		
		[Header("Keyboard input events")]
		[SerializeField] private UnityEvent TabKeyPressedUnityEvent;

		public UnityAction TabKeyPressedAction;
		
		private void Update()
		{
			CheckMouseInput();
			CheckKeyboardInput();
		}

		private void CheckMouseInput()
		{
			if (Input.GetMouseButtonDown(0))
			{
				LeftMouseClickUnityEvent.Invoke();
			}
		}

		private void CheckKeyboardInput()
		{
			if (Input.GetKeyDown(KeyCode.Tab))
			{
				TabKeyPressedUnityEvent.Invoke();
			}
		}
	}
}