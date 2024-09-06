using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
	public class IdleState : EnemyState
	{
		private float _lowerDelayBoundary;
		private float _upperDelayBoundary;
		private Coroutine _waitingCoroutine;

		public IdleState(Enemy enemyStateMachine, float lowerDelayBoundary, float upperDelayBoundary) : base(enemyStateMachine)
		{
			_lowerDelayBoundary = lowerDelayBoundary;
			_upperDelayBoundary = upperDelayBoundary;
		}

		public override void Enter()
		{
			_waitingCoroutine = _enemyStateMachine.StartCoroutine(
				WaitingCoroutine(Random.Range(_lowerDelayBoundary, _upperDelayBoundary))
				);
		}

		public override void Exit()
		{
			_enemyStateMachine.KillCoroutine(ref _waitingCoroutine);
		}

		private IEnumerator WaitingCoroutine(float waitingTime)
		{
			yield return new WaitForSeconds(waitingTime);
			_enemyStateMachine.SwitchState<PatrolState>();
		}
	}
}