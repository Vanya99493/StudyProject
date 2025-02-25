using UnityEngine;
using TMPro;

namespace RemoteConfig
{
	public class RemoteConfigView : MonoBehaviour
	{
		[SerializeField] private TMP_Text _nameText;
		[SerializeField] private TMP_Text _rulesText;

		public void Initialize(string name, string rules)
		{
			_nameText.text = name;
			_rulesText.text = rules;
		}

		
	}
}