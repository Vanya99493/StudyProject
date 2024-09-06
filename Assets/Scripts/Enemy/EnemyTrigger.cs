using System;
using StudyProj.Player;
using UnityEngine;

namespace DefaultNamespace
{
	public class EnemyTrigger : MonoBehaviour
	{
		public event Action<Player> TriggerEnterEvent;
		public event Action<Player> TriggerExitEvent;
		
		private void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent(out Player player))
			{
				TriggerEnterEvent?.Invoke(player);
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.TryGetComponent(out Player player))
			{
				TriggerExitEvent?.Invoke(player);
			}
		}
	}
}