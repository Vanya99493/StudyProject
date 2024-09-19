using System;
using System.Collections.Generic;
using StudyProj.Environment.Generator.States;
using StudyProj.Environment.Generator.States.Base;
using UnityEngine;

namespace StudyProj.Environment.Generator
{
	public class Generator : MonoBehaviour
	{
		[SerializeField] private Animator _animator;

		private Dictionary<Type, GeneratorState> _generatorStates = new Dictionary<Type, GeneratorState>();
		private GeneratorState _currentState;

		private void Awake()
		{
			_generatorStates = new Dictionary<Type, GeneratorState>()
			{
				{ typeof(WaitingState), new WaitingState(this, _animator) },
				{ typeof(ActiveState), new ActiveState(this, _animator) }
			};
		}

		public void SwitchState<T>() where T : GeneratorState
		{
			_currentState?.Stop();
			_currentState = _generatorStates[typeof(T)];
			_currentState.Start();
		}
	}
}