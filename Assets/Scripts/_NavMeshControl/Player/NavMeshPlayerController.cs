using System;
using UnityEngine;
using UnityEngine.AI;

namespace _1_NavMeshControl.Player
{
	public class NavMeshPlayerController : MonoBehaviour
	{
		public event Action<Vector3> SetDestinationUnityEvent;
		public event Action AchieveDestinationUnityEvent;
		
		[SerializeField] private PlayerAnimationController _playerAnimationController;
		[SerializeField] private Camera _mainCamera;
		[SerializeField] private NavMeshAgent _navMeshAgent;

		private bool _isMoved = false;

		private void Update()
		{
			if(_navMeshAgent.hasPath)
			{
				_isMoved = true;
				var animationDirection = CalculateDirection();
				_playerAnimationController.SetSpeed(animationDirection.x, animationDirection.z, 0.75f);
				CheckDistance();
			}
			else
			{
				_playerAnimationController.SetSpeed(0, 0, 0.25f);
				
				if (_isMoved)
				{
					_isMoved = false;
					AchieveDestinationUnityEvent?.Invoke();
				}
			}
		}

		public void ThrowRayAndTryBuildRoute()
		{
			Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out var hit))
			{
				_navMeshAgent.SetDestination(hit.point);
				SetDestinationUnityEvent?.Invoke(hit.point);
			}
		}

		private Vector3 CalculateDirection()
		{
			return transform.InverseTransformDirection((_navMeshAgent.steeringTarget - transform.position).normalized);
		}

		private void CheckDistance()
		{
			if (Vector3.Distance(transform.position, _navMeshAgent.destination) < _navMeshAgent.radius)
			{
				_navMeshAgent.ResetPath();
			}
		}
	}
}