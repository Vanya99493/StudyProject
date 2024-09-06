using UnityEngine;

namespace StudyProj.Environment.Generator.States.Base
{
	public abstract class GeneratorState
	{
		protected Generator _stateMachine;
		protected Animator _animator;

		public GeneratorState(Generator stateMachine, Animator animator)
		{
			_stateMachine = stateMachine;
			_animator = animator;
		}

		public abstract void Start();
		public abstract void Stop();
	}
}