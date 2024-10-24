using System.Collections.Generic;
using UnityEngine;

namespace _Patterns.PauseController
{
	public class PauseHandler : MonoBehaviour, IPauseHandler
	{
		private List<IPausable> _pausableElements = new();

		public void AddSubscriber(IPausable pausableElement)
		{
			_pausableElements.Add(pausableElement);
		}

		public void RemoveSubscriber(IPausable pausableElement)
		{
			_pausableElements.Remove(pausableElement);
		}

		public void PauseSession()
		{
			foreach (var pausableElement in _pausableElements)
			{
				pausableElement.Pause();
			}
		}

		public void UnpauseSession()
		{
			foreach (var pausableElement in _pausableElements)
			{
				pausableElement.Unpause();
			}
		}
	}
}