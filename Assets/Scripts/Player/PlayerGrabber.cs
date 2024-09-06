using StudyProj.Environment;
using UnityEngine;

namespace StudyProj.Player
{
	public class PlayerGrabber : MonoBehaviour
	{
		[SerializeField] private Transform _grabPoint;

		private Transform _lastObjectParent;
		
		public IGrabbable ObjectInHands;

		public void PickUpObject(IGrabbable objectToPickUp)
		{
			if (ObjectInHands != null)
			{
				return;
			}
			ObjectInHands = objectToPickUp;
			_lastObjectParent = ObjectInHands.GetTransform().parent;
			ObjectInHands.GetTransform().SetParent(_grabPoint);
			ObjectInHands.DeactivateCollision();
			ObjectInHands.GetTransform().localPosition = Vector3.zero;
		}

		public void DropObject()
		{
			if (ObjectInHands == null)
			{
				return;
			}
			ObjectInHands.GetTransform().SetParent(_lastObjectParent);
			ObjectInHands.ActivateCollision();
			_lastObjectParent = null;
			ObjectInHands = null;
		}
	}
}