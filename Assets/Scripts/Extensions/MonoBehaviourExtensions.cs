using UnityEngine;

namespace Extensions
{
	public static class MonoBehaviourExtensions
	{
		public static void Activate(this MonoBehaviour monoBehaviour)
		{
			monoBehaviour.gameObject.SetActive(true);
		}

		public static void Deactivate(this MonoBehaviour monoBehaviour)
		{
			monoBehaviour.gameObject.SetActive(false);
		}
	}
}