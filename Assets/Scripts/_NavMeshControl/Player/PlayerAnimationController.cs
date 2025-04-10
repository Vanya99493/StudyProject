﻿using UnityEngine;

namespace _1_NavMeshControl.Player
{
	public class PlayerAnimationController : MonoBehaviour
	{
		private const string ANIMATOR_HORIZONTAL_SPEED_NAME = "HorizontalSpeed";
		private const string ANIMATOR_VERTICAL_SPEED_NAME = "VerticalSpeed";
		
		[SerializeField] private Animator _animator;

		public void SetSpeed(float newHorizontalSpeed, float newVerticalSpeed, float dampTime)
		{
			SetHorizontalSpeed(newHorizontalSpeed, dampTime);
			SetVerticalSpeed(newVerticalSpeed, dampTime);
		}

		public void SetHorizontalSpeed(float newHorizontalSpeed, float dampTime)
		{
			_animator.SetFloat(ANIMATOR_HORIZONTAL_SPEED_NAME, newHorizontalSpeed, dampTime, Time.deltaTime);
		}

		public void SetVerticalSpeed(float newVerticalSpeed, float dampTime)
		{
			_animator.SetFloat(ANIMATOR_VERTICAL_SPEED_NAME, newVerticalSpeed, dampTime, Time.deltaTime);
		}
	}
}