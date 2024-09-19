using UnityEngine;
using UnityEngine.Events;

namespace StudyProj.Player
{
	public class InputHandler : MonoBehaviour
	{
		[SerializeField] private UnityEvent EKeyPressEvent;
		[SerializeField] private UnityEvent GKeyPressEvent;

		public event UnityAction EKeyPressAction
		{
			add
			{
				EKeyPressEvent.AddListener(value);
			}
			remove
			{
				EKeyPressEvent.RemoveListener(value);
			}
		}
		
		public event UnityAction GKeyPressAction
		{
			add
			{
				GKeyPressEvent.AddListener(value);
			}
			remove
			{
				GKeyPressEvent.RemoveListener(value);
			}
		}
		
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				EKeyPressEvent?.Invoke();
			}
			if (Input.GetKeyDown(KeyCode.G))
			{
				GKeyPressEvent?.Invoke();
			}
		}
	}
}