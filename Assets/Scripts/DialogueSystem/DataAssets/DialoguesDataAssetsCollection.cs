using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DialogueSystem
{
	[CreateAssetMenu(fileName = "DialoguesDataAssetsCollection", menuName = "Data Assets/Dialogues/Dialogues Data Assets Collection")]
	public class DialoguesDataAssetsCollection : ScriptableObject
	{
		[SerializeField]
		private List<DialogueDataAsset> _dialogues = new();

		public DialogueData GetDialogueDataByName(string dialogueName)
		{
			var dialogue = _dialogues.FirstOrDefault(x => x.Name == dialogueName);
			if (dialogue is null)
			{
				return new DialogueData();
			}

			return dialogue.ToData();
		}
	}
}