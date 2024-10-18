using UnityEngine;

namespace StudyProj.Environment
{
	public class FogSpace : MonoBehaviour
	{
		[SerializeField] private LayerMask _interactiveLayerMask;

		private void OnTriggerEnter(Collider other)
		{
			if ((_interactiveLayerMask.value & (1 << other.gameObject.layer)) != 0)
			{
				RenderSettings.fog = true;
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if ((_interactiveLayerMask.value & (1 << other.gameObject.layer)) != 0)
			{
				RenderSettings.fog = false;
			}
		}
	}
}