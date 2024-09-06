using UnityEngine;
using UnityEngine.AI;

namespace _1_NavMeshControl.Player
{
	public class NavMeshPlayerController : MonoBehaviour
	{
		[SerializeField] private PlayerAnimationController _playerAnimationController;
		[SerializeField] private Camera _mainCamera;
		[SerializeField] private NavMeshAgent _navMeshAgent;

		[SerializeField] private float _rotateAnglePerSecond = 180;
		[SerializeField] private float _stoppingDistance;

		private void Update()
		{
			CheckMouseClick();
			
			if(_navMeshAgent.hasPath)
			{
				var animationDirection = CalculateDirection();

				_playerAnimationController.SetSpeed(animationDirection.x, animationDirection.z, 0.75f);

				if (Vector3.Distance(transform.position, _navMeshAgent.destination) < _navMeshAgent.radius)
				{
					_navMeshAgent.ResetPath();
				}
			}
			else
			{
				_playerAnimationController.SetSpeed(0, 0, 0.25f);
				_playerAnimationController.SetTurnAngle(0f);
			}
		}

		private void CheckMouseClick()
		{
			if (Input.GetMouseButtonDown(0))
			{
				Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

				if (Physics.Raycast(ray, out var hit))
				{
					_navMeshAgent.SetDestination(hit.point);
				}
			}
		}

		private Vector3 CalculateDirection()
		{
			return transform.InverseTransformDirection((_navMeshAgent.steeringTarget - transform.position).normalized);
		}
	}
}