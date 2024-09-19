using UnityEngine;

namespace StudyProj.Environment
{
	public interface IGrabbable
	{
		Transform GetTransform();
		void ActivateCollision();
		void DeactivateCollision();
	}
}