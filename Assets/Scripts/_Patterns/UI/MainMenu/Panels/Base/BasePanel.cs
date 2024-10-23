using UnityEngine;

namespace _Patterns.UI.MainMenu
{
	public class BasePanel : MonoBehaviour
	{
		public virtual void Activate()
		{
			gameObject.SetActive(true);
		}

		public virtual void Deactivate()
		{
			gameObject.SetActive(false); 
		}
	}
}