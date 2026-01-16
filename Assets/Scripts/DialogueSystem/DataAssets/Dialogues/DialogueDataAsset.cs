using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
	[CreateAssetMenu(fileName = "DialogueDataAsset", menuName = "Data Assets/Dialogues/Dialogue Data Asset")]
	public class DialogueDataAsset : ScriptableObject
	{
		public string Name = "";
		public List<DialogueLine> DialogueLines = new();

		public DialogueData ToData()
		{
			return new DialogueData(Name, DialogueLines);
		}
	}
}