namespace DefaultNamespace
{
	public abstract class EnemyState
	{
		protected Enemy _enemyStateMachine;

		public EnemyState(Enemy enemyStateMachine)
		{
			_enemyStateMachine = enemyStateMachine;
		}

		public abstract void Enter();
		public abstract void Exit();
	}
}