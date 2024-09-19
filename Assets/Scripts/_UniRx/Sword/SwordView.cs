using TMPro;
using UnityEngine;

namespace _UniRx.SwordModule
{
	public class SwordView : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _swordHealthPointsText;

		public void UpdateSwordHealthPointsText(int newHealthPointsValue)
		{
			_swordHealthPointsText.text = newHealthPointsValue.ToString();
		}
	}
}