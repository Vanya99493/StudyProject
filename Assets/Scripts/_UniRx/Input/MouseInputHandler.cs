using System;
using UnityEngine;

namespace _UniRx.Input
{
	public class MouseInputHandler : MonoBehaviour
	{
		public event Action LeftMouseButtonClickEvent;
		
		private void Update()
		{
			if (UnityEngine.Input.GetMouseButtonDown(0))
			{
				LeftMouseButtonClickEvent?.Invoke();
			}
		}
	}
}