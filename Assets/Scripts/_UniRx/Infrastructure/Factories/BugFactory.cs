using _UniRx.BugModule;
using UnityEngine;

namespace _UniRx.Infrastructure.Factories
{
	public class BugFactory : MonoBehaviour
	{
		[Header("Prefabs")]
		[SerializeField] private Bug _bugPrefab;
		[Header("Spawn config")]
		[SerializeField] private Transform _bugParent;
		[SerializeField] private Vector3 _startPosition;
		[SerializeField] private float _moveAngle;
		
		public Bug InstantiateBug()
		{
			Bug bug = Object.Instantiate(_bugPrefab, _bugParent);
			bug.transform.position = _startPosition;
			
			InitializeBug(bug);
			return bug;
		}

		private void InitializeBug(Bug bug)
		{
			float randomAngle = Random.Range(-_moveAngle, _moveAngle);

			float directionX = Mathf.Cos(randomAngle * Mathf.Deg2Rad);
			float directionY = Mathf.Sin(randomAngle * Mathf.Deg2Rad);

			Vector2 movementDirection = new Vector2(directionX, directionY);
			bug.Initialize(movementDirection);
		}
	}
}