using UnityEngine;

namespace _1_NavMeshControl.Environment
{
	public class DestinationPointSpawner : MonoBehaviour
	{
		[SerializeField] private GameObject _destinationPointPrefab;
		[SerializeField] private Transform _parentToSpawn;
		
		private GameObject _spawnedDestinationPoint;

		private void OnEnable()
		{
			SpawnDestinationPoint();
		}

		private void OnDisable()
		{
			DestroyDestinationPoint();
		}

		public void ActivateDestinationPoint(Vector3 destinationPointPosition)
		{
			_spawnedDestinationPoint.transform.position = destinationPointPosition;
			_spawnedDestinationPoint.gameObject.SetActive(true);
		}

		public void DeactivateDestinationPoint()
		{
			_spawnedDestinationPoint.SetActive(false);
		}

		private void SpawnDestinationPoint()
		{
			_spawnedDestinationPoint = Instantiate(_destinationPointPrefab, _parentToSpawn);
			DeactivateDestinationPoint();
		}

		private void DestroyDestinationPoint()
		{
			Destroy(_spawnedDestinationPoint);
		}
	}
}