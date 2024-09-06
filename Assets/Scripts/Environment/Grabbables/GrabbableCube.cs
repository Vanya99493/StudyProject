using System;
using UnityEngine;

namespace StudyProj.Environment.Grabbables
{
	[RequireComponent(typeof(Rigidbody), typeof(Collider))]
	public class GrabbableCube : MonoBehaviour, IGrabbable
	{
		[SerializeField] private Rigidbody _rigidbody;
		[SerializeField] private Collider _collider;

		private void Awake()
		{
			_rigidbody ??= GetComponent<Rigidbody>();
			_collider ??= GetComponent<Collider>();
		}

		public Transform GetTransform()
		{
			return transform;
		}

		public void ActivateCollision()
		{
			_rigidbody.isKinematic = false;
			_collider.isTrigger = false;
		}

		public void DeactivateCollision()
		{
			_rigidbody.isKinematic = true;
			_collider.isTrigger = true;
		}
	}
}