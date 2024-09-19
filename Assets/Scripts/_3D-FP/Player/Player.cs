using StudyProj.Environment;
using UnityEngine;

namespace StudyProj.Player
{
	public class Player : MonoBehaviour
	{
		[SerializeField] private PlayerLookInteractor _playerLookInteractor;
		[SerializeField] private InputHandler _playerInputHandler;
		[SerializeField] private PlayerGrabber _playerGrabber;

		private void OnEnable()
		{
			SubscribeEvents();
		}

		private void OnDisable()
		{
			UnsubscribeEvents();
		}

		private void SubscribeEvents()
		{
			_playerInputHandler.EKeyPressAction += _playerLookInteractor.ThrowInteractableRay;
			_playerInputHandler.GKeyPressAction += _playerGrabber.DropObject;
			_playerLookInteractor.GrabObjectEvent += _playerGrabber.PickUpObject;
		}

		private void UnsubscribeEvents()
		{
			_playerInputHandler.EKeyPressAction -= _playerLookInteractor.ThrowInteractableRay;
			_playerInputHandler.GKeyPressAction -= _playerGrabber.DropObject;
			_playerLookInteractor.GrabObjectEvent -= _playerGrabber.PickUpObject;
		}
	}
}