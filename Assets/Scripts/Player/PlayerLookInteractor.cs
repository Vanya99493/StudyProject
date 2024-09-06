using System;
using StudyProj.Environment;
using UnityEngine;

namespace StudyProj.Player
{
	public class PlayerLookInteractor : MonoBehaviour
	{
		public event Action<IGrabbable> GrabObjectEvent;
		
		[SerializeField] private Camera _playerCamera;
		
		private IRayInteractable _currentInteractedObject = null;

		private void Update()
		{
			ThrowRay();
		}

		public void ThrowInteractableRay()
		{
			Ray ray = ThrowRayFromCameraCenter();
			if(Physics.Raycast(ray, out var hit))
			{
				if (hit.collider.gameObject.TryGetComponent(out IGrabbable grabbable))
				{
					GrabObjectEvent?.Invoke(grabbable);
					return;
				}
				if (hit.collider.gameObject.TryGetComponent(out IInteractable interactable))
				{
					interactable.Interact();
					return;
				}
			}
		}

		private void ThrowRay()
		{
			Ray ray = ThrowRayFromCameraCenter();
			if (Physics.Raycast(ray, out var hit))
			{
				if (hit.collider.gameObject.TryGetComponent<IRayInteractable>(out var rayInteractable))
				{
					if (!rayInteractable.IsActive)
					{
						if (_currentInteractedObject != null)
						{
							_currentInteractedObject.Deactivate();
						}

						_currentInteractedObject = rayInteractable;
						_currentInteractedObject.Activate();
					}
				}
				else
				{
					DeactivateCurrentInteractableObject();
				}
			}
			else
			{
				DeactivateCurrentInteractableObject();
			}
		}

		private Ray ThrowRayFromCameraCenter()
		{
			return new Ray(_playerCamera.transform.position, _playerCamera.transform.forward);
		}

		private void DeactivateCurrentInteractableObject()
		{
			_currentInteractedObject?.Deactivate();
			_currentInteractedObject = null;
		}
	}
}