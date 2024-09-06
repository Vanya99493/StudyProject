using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
	public class Enemy : MonoBehaviour
	{
		[SerializeField] private EnemyTrigger _enemyTrigger;
		[SerializeField] private float _speed;
		
		private Dictionary<Type, EnemyState> _states;
		private EnemyState _currentState;

		private void Awake()
		{
			_states = new Dictionary<Type, EnemyState>();
			//{
			//	
			//};
		}

		public void SwitchState<T>() where T : EnemyState
		{
			_currentState?.Exit();
			_currentState = _states[typeof(T)];
			_currentState?.Enter();
		}

		public void Move(Vector3 destinationPosition)
		{
			
		}
	}
}