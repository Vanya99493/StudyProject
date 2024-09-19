using _1_NavMeshControl.Environment;
using _1_NavMeshControl.Player;
using UnityEngine;

namespace _1_NavMeshControl.Infrastructure
{
	public class EntryPoint : MonoBehaviour
	{
		[SerializeField] private NavMeshPlayerController _navMeshPlayerController;
		[SerializeField] private DestinationPointSpawner _destinationPointSpawner;

		private void OnEnable()
		{
			SubscribeEvents();
		}

		private void OnDisable()
		{
			UnsubscribeEvents();
		}

		private void SubscribeEvents()
		{
			_navMeshPlayerController.SetDestinationUnityEvent += _destinationPointSpawner.ActivateDestinationPoint;
			_navMeshPlayerController.AchieveDestinationUnityEvent += _destinationPointSpawner.DeactivateDestinationPoint;
		}

		private void UnsubscribeEvents()
		{
			_navMeshPlayerController.SetDestinationUnityEvent -= _destinationPointSpawner.ActivateDestinationPoint;
			_navMeshPlayerController.AchieveDestinationUnityEvent -= _destinationPointSpawner.DeactivateDestinationPoint;
		}
	}
}