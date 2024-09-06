using StudyProj.Environment.Generator.States.Base;
using UnityEngine;

namespace StudyProj.Environment.Generator.States
{
	public class WaitingState : GeneratorState
	{
		private const string ACTIVE_BOOL_NAME = "IsActive";

		public WaitingState(Generator stateMachine, Animator animator) : base(stateMachine, animator) {}

		public override void Start()
		{
			_animator.SetBool(ACTIVE_BOOL_NAME, false);
		}

		public override void Stop() {}
	}
}